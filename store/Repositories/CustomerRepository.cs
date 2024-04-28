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
    internal class CustomerRepository
    {
        
        private readonly string connectionString;

        public CustomerRepository()
        {
            connectionString = Data.ConnectionString;
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

        public int GetTotalCustomers()
        {
            int totalCustomers = 0;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = $"SELECT COUNT(*) FROM {TableNames.Customers}";
                OleDbCommand command = new OleDbCommand(query, connection);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        totalCustomers = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error getting total customers: " + ex.Message);
                }
            }

            return totalCustomers;
        }
    }
}
