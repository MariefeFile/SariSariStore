using store.Constants;
using store.Models;
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
        
        private readonly string connectionString;

        public CustomerService()
        {
            connectionString = $"Provider=Microsoft.JET.OLEDB.4.0;Data Source={Data.ConnectionPath}";
        }

        public bool InsertCustomer(Customer customer)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = $"INSERT INTO {TableNames.Customers} (CustomerName, CustomerPhone, CustomerEmail) VALUES (@CustomerName, @CustomerPhone, @CustomerEmail)";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                command.Parameters.AddWithValue("@CustomerPhone", customer.CustomerPhone);
                command.Parameters.AddWithValue("@CustomerEmail", customer.CustomerEmail);

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
