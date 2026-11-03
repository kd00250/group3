using MySqlConnector;

namespace HealthcareSystem.Model.DAL;

public class TestEditDal
{
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
                double? testResult = null;
                if (!reader.IsDBNull(dateTimeOrderedOrdinal))
                {
                    dateTimePreformed = reader.GetDateTime(dateTimeOrderedOrdinal);
                }
                if (!reader.IsDBNull(testResultOrdinal))
                {
                    testResult = reader.GetDouble(testResultOrdinal);
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
                return new Test
                {
                    TestCode = reader.GetString("test_code"),
                    TestName = reader.GetString("test_name"),
                    LowValue = reader.GetDouble("low_value"),
                    HighValue = reader.GetDouble("high_value"),
                    UnitName = reader.GetString("unit_name")
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

    public void updateOrderedTest(int labOrderId, string testCode, DateTime? datetimePerformed, double? testResult, bool isAbnormal)
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