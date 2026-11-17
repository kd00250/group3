using MySqlConnector;

namespace HealthcareSystem.Model.DAL;

public class TestEditDal
{
    private const string GetTestProcedure = "get_test_by_code";
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

    public Test getTestById(string testCode)
    {
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();
        try
        {
            MySqlCommand command = new MySqlCommand(TestEditDal.GetTestProcedure, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("t_test_code", MySqlDbType.VarChar).Value = testCode;
            MySqlParameter testCodeParam = new MySqlParameter("test_code", MySqlDbType.VarChar)
            {
                Direction = System.Data.ParameterDirection.Output,
            };
            MySqlParameter testNameParam = new MySqlParameter("test_name", MySqlDbType.VarChar)
            {
                Direction = System.Data.ParameterDirection.Output,
            };
            MySqlParameter lowValueParam = new MySqlParameter("low_value", MySqlDbType.Double)
            {
                Direction = System.Data.ParameterDirection.Output,
            };
            MySqlParameter highValueParam = new MySqlParameter("high_value", MySqlDbType.Double)
            {
                Direction = System.Data.ParameterDirection.Output,
            };
            MySqlParameter unitsParam = new MySqlParameter("unit_name", MySqlDbType.VarChar)
            {
                Direction = System.Data.ParameterDirection.Output,
            };
            command.Parameters.Add(testCodeParam);
            command.Parameters.Add(testNameParam);
            command.Parameters.Add(lowValueParam);
            command.Parameters.Add(highValueParam);
            command.Parameters.Add(unitsParam);
            command.ExecuteNonQuery();
            return new Test
            {
                TestCode = testCodeParam.Value.ToString(),
                TestName = testNameParam.Value.ToString(),
                LowValue = lowValueParam.Value.ToString(),
                HighValue = highValueParam.Value.ToString(),
                UnitName = unitsParam.Value.ToString()
            };
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