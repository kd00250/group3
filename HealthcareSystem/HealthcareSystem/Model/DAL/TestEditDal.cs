using MySqlConnector;

namespace HealthcareSystem.Model.DAL;

/// <summary>
///     The test edit data access layer.
/// </summary>
public class TestEditDal
{
    /// <summary>
    ///     Gets all ordered tests.
    /// </summary>
    /// <param name="labOrderId">The lab order identifier.</param>
    /// <returns>A list of ordered tests from a given lab order id.</returns>
    public List<OrderedTest> GetAllOrderedTests(int labOrderId)
    {
        var tests = new List<OrderedTest>();
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();
 
        using var command = new MySqlCommand("SELECT * FROM ordered_test WHERE lab_order_id = @labOrderId", connection);
        command.Parameters.AddWithValue("@labOrderId", labOrderId);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            int dateTimeOrderedOrdinal = reader.GetOrdinal("datetime_performed");
            int testResultOrdinal = reader.GetOrdinal("test_result");
            DateTime? dateTimePreformed = null;
            string? testResult = null;
            if (!reader.IsDBNull(dateTimeOrderedOrdinal))
            { 
                dateTimePreformed = reader.GetDateTime(dateTimeOrderedOrdinal);
            }
            if (!reader.IsDBNull(testResultOrdinal))
            {
                testResult = reader.GetString(testResultOrdinal);
            }
            var test = new OrderedTest
            {
                labOrderId = reader.GetInt32("lab_order_id"),
                testCode = reader.GetString("test_code"),
                dateTimePreformed = dateTimePreformed,
                testResult = testResult,
                isAbnormal = reader.GetBoolean("is_abnormal")
            };
            tests.Add(test);
        }
        return tests;
    }

    /// <summary>
    ///     Gets the test by identifier.
    /// </summary>
    /// <param name="testCode">The test code.</param>
    /// <returns>Test the test that corresponds to the testCode or null if not found.</returns>
    public Test? getTestById(string testCode)
    {
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();

        using var command = new MySqlCommand("SELECT * FROM lab_test WHERE test_code = @testCode", connection);
        command.Parameters.AddWithValue("@testCode", testCode);
        using var reader = command.ExecuteReader();

        if (!reader.Read())
        {
            return null;
        }

        var lowValueOrdinal = reader.GetOrdinal("low_value");
        var highValueOrdinal = reader.GetOrdinal("high_value");
        var unitNameOrdinal = reader.GetOrdinal("unit_name");
        return new Test
        {
            TestCode = reader.GetString("test_code"),
            TestName = reader.GetString("test_name"),
            LowValue = reader.IsDBNull(lowValueOrdinal) ? string.Empty : reader.GetDecimal(lowValueOrdinal).ToString(),
            HighValue = reader.IsDBNull(highValueOrdinal) ? string.Empty : reader.GetDecimal(highValueOrdinal).ToString(),
            UnitName = reader.IsDBNull(unitNameOrdinal) ? string.Empty : reader.GetString(unitNameOrdinal)
        };
    }

    /// <summary>
    ///     Updates the ordered test.
    /// </summary>
    /// <param name="labOrderId">The lab order identifier.</param>
    /// <param name="testCode">The test code.</param>
    /// <param name="datetimePerformed">The datetime performed.</param>
    /// <param name="testResult">The test result.</param>
    /// <param name="isAbnormal">if set to <c>true</c> [is abnormal].</param>
    public void updateOrderedTest(int labOrderId, string testCode, DateTime? datetimePerformed, string? testResult, bool isAbnormal)
    {
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();

        using var command = new MySqlCommand("UPDATE ordered_test SET datetime_performed = @datetimePerformed, test_result = @testResult, is_abnormal = @isAbnormal WHERE lab_order_id = @labOrderId AND test_code = @testCode", connection);
        command.Parameters.AddWithValue("@labOrderId", labOrderId);
        command.Parameters.AddWithValue("@testCode", testCode);
        command.Parameters.AddWithValue("@datetimePerformed", datetimePerformed);
        command.Parameters.AddWithValue("@testResult", string.IsNullOrWhiteSpace(testResult) ? DBNull.Value : testResult.Trim());
        command.Parameters.AddWithValue("@isAbnormal", isAbnormal);
        command.ExecuteNonQuery();
    }

}