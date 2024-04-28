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
    public class UserRepository
    {
        private readonly string connectionString;

        public UserRepository()
        {
            connectionString = Data.ConnectionString;
        }

        public bool IsUserExist(User user)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = $"SELECT COUNT(*) FROM {TableNames.Users} WHERE UserName = @UserName AND UserPassword = @UserPassword AND UserType = @UserType";
                OleDbCommand command = new OleDbCommand(query, connection);

                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@UserPassword", user.UserPassword);
                command.Parameters.AddWithValue("@UserType", user.UserType);

                connection.Open();
                int userCount = (int)command.ExecuteScalar();

                return userCount > 0;
            }
        }
    }
}
