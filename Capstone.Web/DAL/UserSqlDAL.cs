using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class UserSqlDAL
    {
        private readonly string connectionString;

        public UserSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Saves the user to the database.
        /// </summary>

        public void CreateUser(UserProfile user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO users VALUES (@userEmail, @userPassword, @firstName, @lastName, @phoneNumber, @salt, @role);", conn);
                    cmd.Parameters.AddWithValue("@userEmail", user.UserEmail);
                    cmd.Parameters.AddWithValue("@userPassword", user.UserPassword);
                    cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", user.LastName);
                    cmd.Parameters.AddWithValue("@phoneNumber", user.PhoneNumber);
                    cmd.Parameters.AddWithValue("@salt", user.Salt);
                    cmd.Parameters.AddWithValue("@role", user.Role);

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes the user from the database.
        /// </summary>
        /// <param name = "user" ></ param >

        public void DeleteUser(UserProfile user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM users WHERE userEmail = @userEmail;", conn);
                    cmd.Parameters.AddWithValue("@userEmail", user.UserEmail);

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the user from the database.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public UserProfile GetUser(string userEmail)
        {
            UserProfile user = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE userEmail = @userEmail;", conn);
                    cmd.Parameters.AddWithValue("@userEmail", userEmail);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        user = MapRowToUser(reader);
                    }
                }

                return user;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Updates the user in the database.
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(UserProfile user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE users SET userPassword = @userPassword, salt = @salt, role = @role WHERE userEmail = @userEmail;", conn);
                    cmd.Parameters.AddWithValue("@password", user.UserPassword);
                    cmd.Parameters.AddWithValue("@salt", user.Salt);
                    cmd.Parameters.AddWithValue("@role", user.Role);
                    cmd.Parameters.AddWithValue("@id", user.UserEmail);

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private UserProfile MapRowToUser(SqlDataReader reader)
        {
            return new UserProfile()
            {
                UserEmail = Convert.ToString(reader["userEmail"]),
                UserPassword = Convert.ToString(reader["userPassword"]),
                FirstName = Convert.ToString(reader["firstName"]),
                LastName = Convert.ToString(reader["lastName"]),
                PhoneNumber = Convert.ToString(reader["phoneNumber"]),
                Salt = Convert.ToString(reader["salt"]),
                Role = Convert.ToString(reader["role"])
            };
        }

    }
}

