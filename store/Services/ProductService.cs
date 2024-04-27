using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using store.Constants;
using store.Models;

namespace store.Services
{
    internal class ProductService
    {
        private string connectionString;

        public ProductService(string databasePath)
        {
            
            connectionString = $@"Provider=Microsoft.JET.OLEDB.4.0;Data Source={databasePath};Persist Security Info=False;";
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
