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
    public class OrderItemRepository
    {
        private readonly string connectionString;

        public OrderItemRepository()
        {
            connectionString = Data.ConnectionString;
        }

        public void AddOrderItems(int orderID, List<OrderItem> orderItems)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    foreach (OrderItem item in orderItems)
                    {
                        string query = $"INSERT INTO {TableNames.OrderItems} (OrderID, ProductID, Item, Categories, Unit, Quantity, SellingPrice, TotalPrice) " +
                                       $"VALUES (@OrderID, @ProductID, @Item, @Categories, @Unit, @Quantity, @SellingPrice, @TotalPrice)";
                        OleDbCommand command = new OleDbCommand(query, connection);

                        command.Parameters.AddWithValue("@OrderID", orderID);
                        command.Parameters.AddWithValue("@ProductID", item.ProductID);
                        command.Parameters.AddWithValue("@Item", item.Item);
                        command.Parameters.AddWithValue("@Categories", item.Categories);
                        command.Parameters.AddWithValue("@Unit", item.Unit);
                        command.Parameters.AddWithValue("@Quantity", item.Quantity);
                        command.Parameters.AddWithValue("@SellingPrice", item.SellingPrice);
                        command.Parameters.AddWithValue("@TotalPrice", item.TotalPrice);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding order items: {ex.Message}");
            }
        }

        public List<OrderItem> GetOrderItemsByOrderID(int orderID)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = $"SELECT * FROM {TableQuery.QueryOrderItems} WHERE OrderID = @OrderID";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@OrderID", orderID);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        try
                        {
                            OrderItem item = new OrderItem(
                                Convert.ToInt32(reader["ProductID"]),
                                reader["Item"].ToString(),
                                reader["Categories"].ToString(),
                                reader["Unit"].ToString(),
                                Convert.ToInt32(reader["Quantity"]),
                                Convert.ToDouble(reader["SellingPrice"]),
                                Convert.ToDouble(reader["TotalPrice"])
                            );
                            orderItems.Add(item);
                        } catch(Exception ex)
                        {
                            throw new Exception($"Error in adding ordered items in the list: {ex.Message}");
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting order items by OrderID: {ex.Message}");
            }

            return orderItems;
        }


    }
}
