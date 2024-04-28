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

        /*
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
        */

        public int AddOrder(Order order)
        {
            int newOrderID = 0;

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string insertQuery = $"INSERT INTO {TableNames.Orders} (OrderDate, CustomerName, TotalPrice, Status, PriorityNumber) VALUES (@OrderDate, @CustomerName, @TotalPrice, @Status, @PriorityNumber)";
                    string fetchIDQuery = $"SELECT @@IDENTITY AS NewOrderID";

                    OleDbCommand insertCommand = new OleDbCommand(insertQuery, connection);
                    OleDbCommand fetchIDCommand = new OleDbCommand(fetchIDQuery, connection);

                    insertCommand.Parameters.AddWithValue("@OrderDate", order.OrderDate.ToString("MM/dd/yyyy"));
                    insertCommand.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                    insertCommand.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                    insertCommand.Parameters.AddWithValue("@Status", order.Status);
                    insertCommand.Parameters.AddWithValue("@PriorityNumber", order.PriorityNumber);

                    connection.Open();
                    insertCommand.ExecuteNonQuery();

                    object result = fetchIDCommand.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        newOrderID = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding an order: {ex.Message}");
            }

            return newOrderID;
        }

    }
}
