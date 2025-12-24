using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Tests
{
    public class FilmService
    {
        private readonly string connStr;

        public FilmService(string connectionString)
        {
            connStr = connectionString;
        }

        public int AddFilm(string title, string genre, int duration, string age)
        {
            using var conn = new MySqlConnection(connStr);
            conn.Open();

            var cmd = new MySqlCommand(
                @"INSERT INTO Film(title, genre, duration, age_rating)
              VALUES (@t, @g, @d, @a);
              SELECT LAST_INSERT_ID();", conn);

            cmd.Parameters.AddWithValue("@t", title);
            cmd.Parameters.AddWithValue("@g", genre);
            cmd.Parameters.AddWithValue("@d", duration);
            cmd.Parameters.AddWithValue("@a", age);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public bool FilmExists(int filmId)
        {
            using var conn = new MySqlConnection(connStr);
            conn.Open();

            var cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM Film WHERE film_id=@id", conn);
            cmd.Parameters.AddWithValue("@id", filmId);

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
    }
}
