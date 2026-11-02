using MySqlConnector;

namespace HealthcareSystem.Model.DAL;

public class ViewOrdersDal
{
    public List<LabOrder> GetOrdersByVisitId(int visitId)
    {
        var orders = new List<LabOrder>();
        using var connection = new MySqlConnection(Connection.ConnectionString());
        connection.Open();
        string query = "SELECT * FROM lab_order WHERE VisitId = @VisitId";
        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@VisitId", visitId);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    LabOrder order = new LabOrder
                    {
                        LabOrderId = reader.GetInt32("LabOrderId"),
                        DateTimeOrdered = reader.GetDateTime("DateTimeOrdered"),
                        visitId = reader.GetInt32("VisitId")
                    };
                    orders.Add(order);
                }
            }
        }
        return orders;
    }
}