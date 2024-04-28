using store.Constants;
using store.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.Repositories
{
    public class OrderRepository
    {
        private readonly string connectionString;

        public OrderRepository()
        {
            connectionString = Data.ConnectionString;
        }


        public void AddOrder(Order order)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = $"INSERT INTO {TableNames.Orders} (OrderDate, CustomerName, TotalPrice, Status, PriorityNumber) VALUES (@OrderDate, @CustomerName, @TotalPrice, @Status, @PriorityNumber)";
                    OleDbCommand command = new OleDbCommand(query, connection);

                    command.Parameters.AddWithValue("@OrderDate", order.OrderDate.ToString("MM/dd/yyyy"));
                    command.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                    command.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                    command.Parameters.AddWithValue("@Status", order.Status);
                    command.Parameters.AddWithValue("@PriorityNumber", order.PriorityNumber);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            } catch (Exception ex)
            {
                throw new Exception($"Error adding an order: {ex.Message}");
            }
        }
    }
}
