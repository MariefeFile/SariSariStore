using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;  
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using store.Constants;
using store.Models;

namespace store.Repositories
{
    internal class ProductRepository
    {
        private string connectionString;

        public ProductRepository()
        {
            
            connectionString = Data.ConnectionString;
        }

        public int GetProductStock(string itemName)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = $"SELECT Stock FROM {TableQuery.QueryProducts} WHERE Item = @Item;";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Item", itemName);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving product stock: {ex.Message}");
            }

            return -1;
        }


        public int GetProductStock(int productID)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = $"SELECT Stock FROM {TableQuery.QueryProducts} WHERE ProductID = @ProductID;";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", productID);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving product stock: {ex.Message}");
            }

            return -1;
        }


        public bool UpdateProduct(Product product)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = $"UPDATE {TableNames.Products} " +
                                   $"SET Item = @Item, Unit = @Unit, OrigPrice = @OrigPrice, SellingPrice = @SellingPrice, " +
                                   $"Stock = @Stock, Categories = @Categories, ItemSold = @ItemSold, MarkUp = @MarkUp " +
                                   $"WHERE ProductID = @ProductID";

                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@Item", product.Item);
                    command.Parameters.AddWithValue("@Unit", product.Unit);
                    command.Parameters.AddWithValue("@OrigPrice", product.OrigPrice);
                    command.Parameters.AddWithValue("@SellingPrice", product.SellingPrice);
                    command.Parameters.AddWithValue("@Stock", product.Stock);
                    command.Parameters.AddWithValue("@Categories", product.Categories);
                    command.Parameters.AddWithValue("@ItemSold", product.ItemSold);
                    command.Parameters.AddWithValue("@MarkUp", product.MarkUp);
                    command.Parameters.AddWithValue("@ProductID", product.ProductID);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating product: {ex.Message}");
            }
        }


        public bool InsertProduct(Product product)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = $"INSERT INTO {TableNames.Products} (Item, Unit, OrigPrice, SellingPrice, Stock, Categories, ItemSold, MarkUp) " +
                                   $"VALUES (@Item, @Unit, @OrigPrice, @SellingPrice, @Stock, @Categories, @ItemSold, @MarkUp)";

                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@Item", product.Item);
                    command.Parameters.AddWithValue("@Unit", product.Unit);
                    command.Parameters.AddWithValue("@OrigPrice", product.OrigPrice);
                    command.Parameters.AddWithValue("@SellingPrice", product.SellingPrice);
                    command.Parameters.AddWithValue("@Stock", product.Stock);
                    command.Parameters.AddWithValue("@Categories", product.Categories);
                    command.Parameters.AddWithValue("@ItemSold", product.ItemSold);
                    command.Parameters.AddWithValue("@MarkUp", product.MarkUp);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting product: {ex.Message}");
            }
        }


        public List<Product> GetAllProducts()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = $"SELECT * FROM {TableQuery.QueryProducts};";
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable.AsEnumerable()
                            .Select(row => new Product(
                                Convert.ToInt32(row["ProductID"]),
                                row["Item"].ToString(),
                                row["Unit"].ToString(),
                                Convert.ToDouble(row["OrigPrice"]),
                                Convert.ToDouble(row["SellingPrice"]),
                                Convert.ToInt32(row["Stock"]),
                                row["Categories"].ToString(),
                                Convert.ToInt32(row["ItemSold"]),
                                Convert.ToDouble(row["MarkUp"])
                            ))
                            .ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving products: {ex.Message}");
            }
        }
    }
}
