using store.Constants;
using store.Constants.Users;
using store.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace store.Repositories
{
    public class UserRepository
    {
        private readonly string connectionString;

        public UserRepository()
        {
            connectionString = Data.ConnectionString;
        }

        public bool UpdateUser(User user)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = $"UPDATE {TableNames.Users} SET UserName = @UserName, UserPassword = @UserPassword, UserAddress = @UserAddress, UserImage = @UserImage, UserPhone = @UserPhone WHERE UserID = @UserID";
                OleDbCommand command = new OleDbCommand(query, connection);

                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@UserPassword", user.UserPassword);
                command.Parameters.AddWithValue("@UserAddress", user.UserAddress);
                command.Parameters.AddWithValue("@UserImage", user.UserImage);
                command.Parameters.AddWithValue("@UserPhone", user.UserPhone);
                command.Parameters.AddWithValue("@UserID", user.UserID);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating user: " + ex.Message);
                    return false;
                }
            }
        }


        public List<User> GetAllEmployee()
        {
            List<User> employees = new List<User>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = $"SELECT * FROM {TableQuery.QueryUsers} WHERE UserType = '{UserTypes.Employee}'";
                OleDbCommand command = new OleDbCommand(query, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User employee = new User
                    {
                        UserID = Convert.ToInt32(reader["UserID"]),
                        UserName = Convert.ToString(reader["UserName"]),
                        UserPassword = Convert.ToString(reader["UserPassword"]),
                        UserAddress = Convert.ToString(reader["UserAddress"]),
                        UserImage = reader["UserImage"] as byte[],
                        UserPhone = Convert.ToInt32(reader["UserPhone"])
                    };
                    employees.Add(employee);
                }

                reader.Close();
            }

            return employees;
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
