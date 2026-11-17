using System.Data;
using MySqlConnector;

namespace HealthcareSystem.Model.DAL;

/// <summary>
///     The orderTest data access layer.
/// </summary>
public class OrderTestDal
{
    private const string MostPerformedTestsProcedure = "get_most_performed_tests_duringdates";

    /// <summary>
    ///     Completes the lab order.
    /// </summary>
    /// <param name="tests">The tests.</param>
    /// <param name="visit_id">The visit identifier.</param>
    /// <exception cref="Exception">Database error occurred while ordering the test.</exception>
    public void CompleteLabOrder(IList<Test> tests, int visit_id)
    {
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();
        using var transaction = connection.BeginTransaction();
        try
        {
            const string insertLabOrderQuery =
                "INSERT INTO lab_order (order_datetime, visit_id) VALUES (@order_datetime, @visit_id)";
            const string insertOrderTestQuery =
                "INSERT INTO ordered_test (lab_order_id, test_code, datetime_performed, test_result, is_abnormal) VALUES (@lab_order_id, @test_code, @datetime_performed, @test_result, @is_abnormal)";
            var labCommand = new MySqlCommand(insertLabOrderQuery, connection, transaction);
            labCommand.Parameters.AddWithValue("@order_datetime", DateTime.Now);
            labCommand.Parameters.AddWithValue("@visit_id", visit_id);
            labCommand.ExecuteNonQuery();
            var labOrderId = (int)labCommand.LastInsertedId;

            foreach (Test test in tests)
            {
                var orderedTestCommand = new MySqlCommand(insertOrderTestQuery, connection, transaction);
                orderedTestCommand.Parameters.AddWithValue("@lab_order_id", labOrderId);
                orderedTestCommand.Parameters.AddWithValue("@test_code", test.TestCode);
                orderedTestCommand.Parameters.AddWithValue("@datetime_performed", null);
                orderedTestCommand.Parameters.AddWithValue("@test_result", null);
                orderedTestCommand.Parameters.AddWithValue("@is_abnormal", false);
                orderedTestCommand.ExecuteNonQuery();
            }

            transaction.Commit();
        }
        catch (MySqlException ex)
        {
            transaction.Rollback();
            throw new Exception("Database error occurred while ordering the test.", ex);
        }

        connection.Close();
    }

    /// <summary>
    /// Gets the statistics of the tests performed at least twice during the specified date range
    /// by calling the stored procedure 'get_most_performed_tests_duringdates'.
    /// </summary>
    /// <param name="startDate">The start date (inclusive).</param>
    /// <param name="endDate">The end date (inclusive).</param>
    /// <returns>The statistics of the most performed tests from most to least performed.</returns>
    public List<TestStatistic> GetMostPerformedTestsDuringDates(DateTime startDate, DateTime endDate)
    {
        var testStatistics = new List<TestStatistic>();

        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();

        using var command = new MySqlCommand(MostPerformedTestsProcedure, connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@start_date", MySqlDbType.Date);
        command.Parameters["@start_date"].Value = startDate.Date;
        command.Parameters["@start_date"].Direction = ParameterDirection.Input;

        command.Parameters.Add("@end_date", MySqlDbType.Date);
        command.Parameters["@end_date"].Value = endDate.Date;
        command.Parameters["@end_date"].Direction = ParameterDirection.Input;

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            testStatistics.Add(readTestStatistic(reader));
        }

        return testStatistics;
    }

    private static TestStatistic readTestStatistic(MySqlDataReader reader)
    {
        return new TestStatistic
        {
            TestCode = reader.GetString(reader.GetOrdinal("test_code")),
            TestName = reader.GetString(reader.GetOrdinal("test_name")),
            TimesPerformed = (int)reader.GetInt64(reader.GetOrdinal("times_performed")),
            TotalTestsPerformed = (int)reader.GetInt64(reader.GetOrdinal("total_tests_performed")),
            PercentagePerformed = (double)reader.GetDecimal(reader.GetOrdinal("percentage_performed")),
            NormalResults = (int)reader.GetInt64(reader.GetOrdinal("normal_results")),
            AbnormalResults = (int)reader.GetInt64(reader.GetOrdinal("abnormal_results"))
        };
    }

    /// <summary>
    /// Gets the codes of the tests ordered for a specific visit across all of its lab orders.
    /// </summary>
    /// <param name="visitId">The visit identifier.</param>
    /// <returns>The list of test codes already ordered for the visit.</returns>
    public List<string> GetOrderedTestCodesForVisit(int visitId)
    {
        var testCodes = new List<string>();

        const string query = """
                             SELECT ot.test_code
                             FROM ordered_test ot
                             JOIN lab_order lo ON ot.lab_order_id = lo.lab_order_id
                             WHERE lo.visit_id = @visitId
                             """;

        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();

        using var command = new MySqlCommand(query, connection);
        command.Parameters.Add("@visitId", MySqlDbType.Int32);
        command.Parameters["@visitId"].Value = visitId;

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            testCodes.Add(reader.GetString(reader.GetOrdinal("test_code")));
        }

        return testCodes;
    }

    /// <summary>
    /// Gets the available tests for visit that have not been ordered yet.
    /// </summary>
    /// <param name="visitId">The visit identifier.</param>
    /// <returns>The list of available tests for the visit.</returns>
    public List<Test> GetAvailableTestsForVisit(int visitId)
    {
        var availableTests = new List<Test>();

        const string query = """
                             SELECT lt.test_code, lt.test_name, lt.low_value, lt.high_value, lt.unit_name
                             FROM lab_test lt
                             WHERE NOT EXISTS (
                                 SELECT 1
                                 FROM ordered_test ot
                                 JOIN lab_order lo ON ot.lab_order_id = lo.lab_order_id
                                 WHERE lo.visit_id = @visitId
                                 AND ot.test_code = lt.test_code
                             )
                             ORDER BY lt.test_name
                             """;

        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();

        using var command = new MySqlCommand(query, connection);
        command.Parameters.Add("@visitId", MySqlDbType.Int32);
        command.Parameters["@visitId"].Value = visitId;

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var test = new Test
            {
                TestCode = reader.GetString(reader.GetOrdinal("test_code")),
                TestName = reader.GetString(reader.GetOrdinal("test_name")),
                LowValue = reader.IsDBNull(reader.GetOrdinal("low_value"))
                    ? string.Empty
                    : reader.GetDecimal(reader.GetOrdinal("low_value")).ToString(),
                HighValue = reader.IsDBNull(reader.GetOrdinal("high_value"))
                    ? string.Empty
                    : reader.GetDecimal(reader.GetOrdinal("high_value")).ToString(),
                UnitName = reader.IsDBNull(reader.GetOrdinal("unit_name"))
                    ? string.Empty
                    : reader.GetString(reader.GetOrdinal("unit_name"))
            };
            availableTests.Add(test);
        }

        return availableTests;
    }
}