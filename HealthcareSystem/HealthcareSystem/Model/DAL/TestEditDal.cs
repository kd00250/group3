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
    /// <exception cref="Exception">Database error occurred while retrieving tests.</exception>
    public List<OrderedTest> GetAllOrderedTests(int labOrderId)
    {
        var tests = new List<OrderedTest>();
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();
        try
        {   
            var command = new MySqlCommand("SELECT * FROM ordered_test WHERE lab_order_id = @labOrderId", connection);
            command.Parameters.AddWithValue("@labOrderId", labOrderId);
            var reader = command.ExecuteReader();
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

    /// <summary>
    ///     Gets the test by identifier.
    /// </summary>
    /// <param name="testCode">The test code.</param>
    /// <returns>Test the test that corresponds to the testCode.</returns>
    /// <exception cref="Exception">
    /// Test with code {testCode} not found.
    /// or
    /// Database error occurred while retrieving the test.
    /// </exception>
    public Test getTestById(string testCode)
    {
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();
        try
        {
            var command = new MySqlCommand("SELECT * FROM lab_test WHERE test_code = @testCode", connection);
            command.Parameters.AddWithValue("@testCode", testCode);
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
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
            else
            {
                throw new Exception($"Test with code {testCode} not found.");
            }

        }
        catch (MySqlException ex)
        {
            throw new Exception("Database error occurred while retrieving the test.", ex);
        }
        finally
        {
            connection.Close();
        }
    }

    /// <summary>
    ///     Updates the ordered test.
    /// </summary>
    /// <param name="labOrderId">The lab order identifier.</param>
    /// <param name="testCode">The test code.</param>
    /// <param name="datetimePerformed">The datetime performed.</param>
    /// <param name="testResult">The test result.</param>
    /// <param name="isAbnormal">if set to <c>true</c> [is abnormal].</param>
    /// <exception cref="Exception">Database error occurred while updating the ordered test.</exception>
    public void updateOrderedTest(int labOrderId, string testCode, DateTime? datetimePerformed, string? testResult, bool isAbnormal)
    {
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();
        try
        {
            var command = new MySqlCommand("UPDATE ordered_test SET datetime_performed = @datetimePerformed, test_result = @testResult, is_abnormal = @isAbnormal WHERE lab_order_id = @labOrderId AND test_code = @testCode", connection);
            command.Parameters.AddWithValue("@labOrderId", labOrderId);
            command.Parameters.AddWithValue("@testCode", testCode);
            command.Parameters.AddWithValue("@datetimePerformed", datetimePerformed);
            command.Parameters.AddWithValue("@testResult", testResult);
            command.Parameters.AddWithValue("@isAbnormal", isAbnormal);
            command.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            throw new Exception("Database error occurred while updating the ordered test.", ex);
        }
        finally
        {
            connection.Close();
        }
    }

}