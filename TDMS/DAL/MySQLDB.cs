using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDMS.DAL
{
    class MySQLDB
    {
        private readonly string connectionString = "Server=localhost;Database=tdms;Uid=root;Pwd=1234;";

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new();
            using (MySqlConnection connection = new(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new(query, connection))
                {
                    using (MySqlDataAdapter adapter = new(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                connection.Close();
            }
            return dataTable;
        }

        public void ExecuteNonQuery(string query)
        {
            using (MySqlConnection connection = new(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public string CheckAccount(string email, string password)
        {
            string queryAdmin = "SELECT COUNT(*) FROM adminAccounts WHERE email = @Email AND password = @Password";
            string queryUser = "SELECT COUNT(*) FROM userAccounts WHERE email = @Email AND password = @Password";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand commandAdmin = new MySqlCommand(queryAdmin, connection))
                {
                    commandAdmin.Parameters.AddWithValue("@Email", email);
                    commandAdmin.Parameters.AddWithValue("@Password", password);
                    int countAdmin = Convert.ToInt32(commandAdmin.ExecuteScalar());

                    if (countAdmin > 0)
                        return "admin"; // Return "admin" if admin account found
                }

                using (MySqlCommand commandUser = new MySqlCommand(queryUser, connection))
                {
                    commandUser.Parameters.AddWithValue("@Email", email);
                    commandUser.Parameters.AddWithValue("@Password", password);
                    int countUser = Convert.ToInt32(commandUser.ExecuteScalar());

                    if (countUser > 0)
                        return "user"; // Return "user" if user account found
                }
            }

            return null; // Return null if no account found
        }
    }
}

