using MySqlConnector;

namespace HealthcareSystem.Model.DAL;

public class ViewOrdersDal
{
    public List<LabOrder> GetOrdersByVisitId(int visitId)
    {
        var orders = new List<LabOrder>();
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();
        string query = "SELECT * FROM lab_order WHERE visit_id = @VisitId";
        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@VisitId", visitId);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    LabOrder order = new LabOrder
                    {
                        LabOrderId = reader.GetInt32("lab_order_id"),
                        DateTimeOrdered = reader.GetDateTime("order_datetime"),
                        visitId = reader.GetInt32("visit_id")
                    };
                    orders.Add(order);
                }
            }
        }
        return orders;
    }
}