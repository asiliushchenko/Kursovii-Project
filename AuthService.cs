using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Tests
{
    public class AuthService
    {
        private readonly string connStr;

        public AuthService(string connectionString)
        {
            connStr = connectionString;
        }

        public string Login(string username, string password)
        {
            using var conn = new MySqlConnection(connStr);
            conn.Open();

            var cmd = new MySqlCommand(
                "SELECT role FROM users WHERE username=@u AND password=@p",
                conn);

            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", password);

            object result = cmd.ExecuteScalar();
            return result?.ToString();
        }
    }
}
