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
    public class PaymentRepository
    {
        private readonly string connectionString;

        public PaymentRepository()
        {
            connectionString = Data.ConnectionString;
        }

        public bool InsertPayment(Payment payment)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = $"INSERT INTO {TableNames.Payments} (OrderID, EmployeeName, TotalCash, TotalChange) VALUES (@OrderID, @EmployeeName, @TotalCash, @TotalChange)";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@OrderID", payment.Order.OrderID);
                    command.Parameters.AddWithValue("@EmployeeName", payment.EmployeeName);
                    command.Parameters.AddWithValue("@TotalCash", payment.TotalCash);
                    command.Parameters.AddWithValue("@TotalChange", payment.TotalChange);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                return false;
            }
        }
    }
}
