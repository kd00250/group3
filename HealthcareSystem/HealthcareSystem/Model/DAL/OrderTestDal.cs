using System.Data;
using MySqlConnector;

namespace HealthcareSystem.Model.DAL;

public class OrderTestDal
{
    private const string MostPerformedTestsProcedure = "get_most_performed_tests_duringdates";

    public List<Test> GetAllTests()
    {
        var tests = new List<Test>();
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();
        try
        {   
            var command = new MySqlCommand("SELECT * FROM lab_test", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var test = new Test
                {
                    TestCode = reader.GetString("test_code"),
                    TestName = reader.GetString("test_name"),
                    UnitName = reader.GetString("unit_name"),
                    LowValue = reader.GetDouble("low_value"),
                    HighValue = reader.GetDouble("high_value")
                };
                tests.Add(test);
            }
        }
        catch (MySqlException ex)
        {
            throw new Exception("Database error occurred while retrieving tests.", ex);
        }
        finally
        {
            connection.Close();
        }
        return tests;
    }
    
    public void OrderTest(int labOrderId, string testCode, DateTime? datetimePerformed, double? testResult, bool isAbnormal)
    {
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();
        try
        {
            var command = new MySqlCommand("INSERT INTO ordered_test (lab_order_id, test_code, datetime_performed," +
                "test_result, is_abnormal) VALUES (@labOrderId, @testCode, @datetimePerformed, @testResult, @isAbnormal)", connection);
            command.Parameters.AddWithValue("@labOrderId", labOrderId);
            command.Parameters.AddWithValue("@testCode", testCode);
            command.Parameters.AddWithValue("@datetimePerformed", datetimePerformed);
            command.Parameters.AddWithValue("@testResult", testResult);
            command.Parameters.AddWithValue("@isAbnormal", isAbnormal);
            command.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            throw new Exception("Database error occurred while ordering the test.", ex);
        }
        finally
        {
            connection.Close();
        }
    }

    public int LabOrder(DateTime order_datetime, int visit_id)
    {
        int labOrderId = -1;
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();
        try
        {
            var command = new MySqlCommand("INSERT INTO lab_order (order_datetime, visit_id) " +
                "VALUES (@order_datetime, @visit_id)", connection);
            command.Parameters.AddWithValue("@order_datetime", order_datetime);
            command.Parameters.AddWithValue("@visit_id", visit_id);
            command.ExecuteNonQuery();
            labOrderId = (int)command.LastInsertedId;
        }
        catch (MySqlException ex)
        {
            throw new Exception("Database error occurred while creating the lab order.", ex);
        }
        finally
        {
            connection.Close();
        }
        return labOrderId;
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
}