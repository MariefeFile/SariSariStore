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

        public List<Order> GetOrdersCompletedThisWeek()
        {
            List<Order> completedOrdersThisWeek = new List<Order>();
            DateTime today = DateTime.Today;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            DateTime startOfNextWeek = startOfWeek.AddDays(7);

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = $"SELECT * FROM {TableQuery.QueryOrders} WHERE Status = '{OrderStatus.Completed}' AND OrderDate >= ? AND OrderDate < ?";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@StartDate", startOfWeek);
                    command.Parameters.AddWithValue("@EndDate", startOfNextWeek);

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
                        completedOrdersThisWeek.Add(order);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving completed orders for this week: {ex.Message}");
            }

            return completedOrdersThisWeek;
        }

        public List<Order> GetOrdersCompletedToday()
        {
            List<Order> completedOrdersToday = new List<Order>();
            DateTime today = DateTime.Today;

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = $"SELECT * FROM {TableQuery.QueryOrders} WHERE Status = '{OrderStatus.Completed}' AND OrderDate >= ? AND OrderDate < ?";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@StartDate", today);
                    command.Parameters.AddWithValue("@EndDate", today.AddDays(1));

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
                        completedOrdersToday.Add(order);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving completed orders for today: {ex.Message}");
            }

            return completedOrdersToday;
        }

        public List<Order> GetOrdersCompletedThisMonth()
        {
            List<Order> completedOrdersThisMonth = new List<Order>();
            DateTime startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime startOfNextMonth = startOfMonth.AddMonths(1);

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = $"SELECT * FROM {TableQuery.QueryOrders} WHERE Status = '{OrderStatus.Completed}' AND OrderDate >= ? AND OrderDate < ?";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@StartDate", startOfMonth);
                    command.Parameters.AddWithValue("@EndDate", startOfNextMonth);

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
                        completedOrdersThisMonth.Add(order);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving completed orders for this month: {ex.Message}");
            }

            return completedOrdersThisMonth;
        }

        public List<Order> GetOrdersCompletedThisYear()
        {
            List<Order> completedOrdersThisYear = new List<Order>();
            DateTime startOfYear = new DateTime(DateTime.Today.Year, 1, 1);
            DateTime startOfNextYear = startOfYear.AddYears(1);

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = $"SELECT * FROM {TableQuery.QueryOrders} WHERE Status = '{OrderStatus.Completed}' AND OrderDate >= ? AND OrderDate < ?";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@StartDate", startOfYear);
                    command.Parameters.AddWithValue("@EndDate", startOfNextYear);

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
                        completedOrdersThisYear.Add(order);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving completed orders for this year: {ex.Message}");
            }

            return completedOrdersThisYear;
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

        public void UpdateOrderStatusCompleted(int orderID)
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

        public void UpdateOrderStatusCancelled(int orderID)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string updateQuery = $"UPDATE {TableNames.Orders} SET Status = '{OrderStatus.Cancelled}' WHERE OrderID = @OrderID";
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
