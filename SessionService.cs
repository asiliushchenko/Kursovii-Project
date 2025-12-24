using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Tests
{
    public class SessionService
    {
        private readonly string connStr;

        public SessionService(string connectionString)
        {
            connStr = connectionString;
        }

        public bool CanAddSession(int hallId, DateTime startTime, int durationMinutes)
        {
            using var conn = new MySqlConnection(connStr);
            conn.Open();

            DateTime endTime = startTime.AddMinutes(durationMinutes);

            string sql = @"
                SELECT COUNT(*)
                FROM Session s
                JOIN Film f ON s.film_id = f.film_id
                WHERE s.hall_id = @h
                AND (
                    @start < DATE_ADD(s.start_time, INTERVAL f.duration MINUTE)
                    AND @end > s.start_time
                )";

            var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@h", hallId);
            cmd.Parameters.AddWithValue("@start", startTime);
            cmd.Parameters.AddWithValue("@end", endTime);

            return Convert.ToInt32(cmd.ExecuteScalar()) == 0;
        }

        public int AddSession(int filmId, int hallId, DateTime startTime, decimal price)
        {
            using var conn = new MySqlConnection(connStr);
            conn.Open();

            string sql = @"INSERT INTO Session (film_id, hall_id, start_time, price)
                           VALUES (@f, @h, @t, @p);
                           SELECT LAST_INSERT_ID();";

            var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@f", filmId);
            cmd.Parameters.AddWithValue("@h", hallId);
            cmd.Parameters.AddWithValue("@t", startTime);
            cmd.Parameters.AddWithValue("@p", price);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}
