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

        public bool UpdateTotalPayment(string customerName, double newTotalPayment)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = $"UPDATE {TableNames.Customers} SET TotalPayment = @TotalPayment WHERE CustomerName = @CustomerName";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@TotalPayment", newTotalPayment);
                command.Parameters.AddWithValue("@CustomerName", customerName);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating total payment: " + ex.Message);
                    return false;
                }
            }
        }



        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = $"SELECT * FROM {TableQuery.QueryCustomer}";
                OleDbCommand command = new OleDbCommand(query, connection);

                try
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Customer customer = new Customer
                        {
                            CustomerID = Convert.ToInt32(reader["CostumerID"]),
                            CustomerName = Convert.ToString(reader["CustomerName"]),
                            CustomerPhone = Convert.ToString(reader["CustomerPhone"]),
                            CustomerEmail = Convert.ToString(reader["CustomerEmail"]),
                            TotalPayment = Convert.ToDouble(reader["TotalPayment"]),
                            DateRecorded = Convert.ToDateTime(reader["DateRecorded"])
                        };
                        customers.Add(customer);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error getting all customers: " + ex.Message);
                }
            }

            return customers;
        }


        public bool InsertCustomer(Customer customer)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = $"INSERT INTO {TableNames.Customers} (CustomerName, CustomerPhone, CustomerEmail, TotalPayment, DateRecorded) VALUES (@CustomerName, @CustomerPhone, @CustomerEmail, @TotalPayment, @DateRecorded)";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                command.Parameters.AddWithValue("@CustomerPhone", customer.CustomerPhone);
                command.Parameters.AddWithValue("@CustomerEmail", customer.CustomerEmail);
                command.Parameters.AddWithValue("@TotalPayment", customer.TotalPayment);
                command.Parameters.AddWithValue("@DateRecorded", customer.DateRecorded.ToString("MM/dd/yyyy"));

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
