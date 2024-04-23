using store.Constants;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.Services
{
    internal class CustomerService
    {
        private const string ConnectionPath = "C:\\Users\\Nivanz Aricayos\\Documents\\Codes\\Projects\\SariSariStore\\store.mdb";
        private readonly string connectionString;

        public CustomerService()
        {
            connectionString = $"Provider=Microsoft.JET.OLEDB.4.0;Data Source={ConnectionPath}";
        }

        public bool InsertCustomer(string name, string phone, string email)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = $"INSERT INTO {TableNames.Customers} (CustomerName, CustomerPhone, CustomerEmail) VALUES (@CustomerName, @CustomerPhone, @CustomerEmail)";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerName", name);
                command.Parameters.AddWithValue("@CustomerPhone", phone);
                command.Parameters.AddWithValue("@CustomerEmail", email);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inserting customer: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
