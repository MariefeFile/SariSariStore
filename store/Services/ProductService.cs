using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using store.Constants;

namespace store.Services
{
    internal class ProductService
    {
        private string connectionString;

        public ProductService(string databasePath)
        {
            
            connectionString = $@"Provider=Microsoft.JET.OLEDB.4.0;Data Source={databasePath};Persist Security Info=False;";
        }

        public DataTable GetAllProducts()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "SELECT * FROM QueryProducts;";
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
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
