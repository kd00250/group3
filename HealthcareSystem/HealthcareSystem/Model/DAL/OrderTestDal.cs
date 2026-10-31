using MySqlConnector;

namespace HealthcareSystem.Model.DAL;

public class OrderTestDal
{
    private readonly MySqlConnection connection;
    public OrderTestDal(MySqlConnection connection)
    {
        this.connection = connection;
    }
    public List<Test> GetAllTests()
    {
        var tests = new List<Test>();
        try
        {
            this.connection.Open();
            var command = new MySqlCommand("SELECT * FROM lab_test", this.connection);
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
            this.connection.Close();
        }
        return tests;
    }
    
    public void OrderTest(int labOrderId, string testCode, DateTime? datetimePerformed, double? testResult, bool isAbnormal)
    {
        try
        {
            this.connection.Open();
            var command = new MySqlCommand("INSERT INTO ordered_tests (lab_order_id, test_code, datetime_performed," +
                "test_result, is_abnormal) VALUES (@labOrderId, @testCode, @datetimePerformed, @testResult, @isAbnormal)", this.connection);
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
            this.connection.Close();
        }
    }

    public int LabOrder(DateTime order_datetime, int visit_id)
    {
        int labOrderId = -1;
        try
        {
            this.connection.Open();
            var command = new MySqlCommand("INSERT INTO lab_order (order_datetime, visit_id) " +
                "VALUES (@order_datetime, @visit_id)", this.connection);
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
            this.connection.Close();
        }
        return labOrderId;
    }
}