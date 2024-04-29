using store.Constants;
using store.Constants.Orders;
using store.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace store.Repositories
{
    public class OrderRepository
    {
        private readonly string connectionString;

        public OrderRepository()
        {
            connectionString = Data.ConnectionString;
        }

        public List<Order> GetOrdersPending()
        {
            List<Order> pendingOrders = new List<Order>();

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = $"SELECT * FROM {TableQuery.QueryOrders} WHERE Status = '{OrderStatus.Pending}'";
                    OleDbCommand command = new OleDbCommand(query, connection);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Convert.ToInt32(reader["OrderID"]);
                        Convert.ToDateTime(reader["OrderDate"]);
                        Convert.ToString(reader["CustomerName"]);
                        Convert.ToDouble(reader["TotalPrice"]);
                        Convert.ToString(reader["Status"]);
                        Convert.ToInt32(reader["PriorityNumber"]);
                        Convert.ToInt32(reader["TotalItems"]);

                        Order order = new Order
                        {
                            OrderID = Convert.ToInt32(reader["OrderID"]),
                            OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                            CustomerName = Convert.ToString(reader["CustomerName"]),
                            TotalPrice = Convert.ToDouble(reader["TotalPrice"]),
                            Status = Convert.ToString(reader["Status"]),
                            PriorityNumber = Convert.ToInt32(reader["PriorityNumber"]),
                            TotalItems = Convert.ToInt32(reader["TotalItems"])
                        };
                        pendingOrders.Add(order);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving pending orders: {ex.Message}");
            }

            return pendingOrders;
        }

        public List<Order> GetOrdersCompleted()
        {
            List<Order> completedOrders = new List<Order>();

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = $"SELECT * FROM {TableQuery.QueryOrders} WHERE Status = '{OrderStatus.Completed}'";
                    OleDbCommand command = new OleDbCommand(query, connection);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Order order = new Order
                        {
                            OrderID = Convert.ToInt32(reader["OrderID"]),
                            OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                            CustomerName = Convert.ToString(reader["CustomerName"]),
                            TotalPrice = Convert.ToDouble(reader["TotalPrice"]),
                            Status = Convert.ToString(reader["Status"]),
                            PriorityNumber = Convert.ToInt32(reader["PriorityNumber"]),
                            TotalItems = Convert.ToInt32(reader["TotalItems"])
                        };
                        completedOrders.Add(order);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving completed orders: {ex.Message}");
            }

            return completedOrders;
        }

        public int AddOrder(Order order)
        {
            int newOrderID = 0;

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string insertQuery = $"INSERT INTO {TableNames.Orders} (OrderDate, CustomerName, TotalPrice, Status, PriorityNumber, TotalItems) VALUES (@OrderDate, @CustomerName, @TotalPrice, @Status, @PriorityNumber, @TotalItems)";
                    string fetchIDQuery = $"SELECT @@IDENTITY AS NewOrderID";

                    OleDbCommand insertCommand = new OleDbCommand(insertQuery, connection);
                    OleDbCommand fetchIDCommand = new OleDbCommand(fetchIDQuery, connection);

                    insertCommand.Parameters.AddWithValue("@OrderDate", order.OrderDate.ToString("MM/dd/yyyy"));
                    insertCommand.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                    insertCommand.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                    insertCommand.Parameters.AddWithValue("@Status", order.Status);
                    insertCommand.Parameters.AddWithValue("@PriorityNumber", order.PriorityNumber);
                    insertCommand.Parameters.AddWithValue("@TotalItems", order.TotalItems);

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

        public void UpdateOrderStatus(int orderID)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string updateQuery = $"UPDATE {TableNames.Orders} SET Status = '{OrderStatus.Completed}' WHERE OrderID = @OrderID";
                    OleDbCommand updateCommand = new OleDbCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@OrderID", orderID);

                    connection.Open();
                    updateCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating order status: {ex.Message}");
            }
        }


    }
}
