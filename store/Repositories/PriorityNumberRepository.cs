using store.Constants;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.Repositories
{
    public class PriorityNumberRepository
    {
        private string connectionString;

        public PriorityNumberRepository()
        {

            connectionString = Data.ConnectionString;
        }

        public int GetLatestPriorityNumber()
        {
            int latestPriorityNumber = 0;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = $"SELECT TOP 1 PriorityNumber FROM {TableQuery.QueryPriorityNumber} ORDER BY PriorityNumberID DESC";
                OleDbCommand command = new OleDbCommand(query, connection);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    latestPriorityNumber = Convert.ToInt32(result);
                    latestPriorityNumber++;
                }
                else
                {
                    latestPriorityNumber = 1;
                }
            }

            return latestPriorityNumber;
        }



        public void AddLatestPriorityNumber()
        {
            int newPriorityNumber = GetLatestPriorityNumber();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = $"INSERT INTO {TableQuery.QueryPriorityNumber} (PriorityNumber) VALUES (@PriorityNumber)";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@PriorityNumber", newPriorityNumber);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
