using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Tests
{
    public class TicketService
    {
        private readonly string connStr;
        private const int MaxSeats = 20;

        public TicketService(string connectionString)
        {
            connStr = connectionString;
        }

        public bool IsSeatFree(int sessionId, int seatNumber)
        {
            using var conn = new MySqlConnection(connStr);
            conn.Open();

            var cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM Ticket WHERE session_id=@s AND seat_number=@n",
                conn);

            cmd.Parameters.AddWithValue("@s", sessionId);
            cmd.Parameters.AddWithValue("@n", seatNumber);

            return Convert.ToInt32(cmd.ExecuteScalar()) == 0;
        }

        public int ReservedSeatsCount(int sessionId)
        {
            using var conn = new MySqlConnection(connStr);
            conn.Open();

            var cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM Ticket WHERE session_id=@s",
                conn);

            cmd.Parameters.AddWithValue("@s", sessionId);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public bool ReserveSeat(int sessionId, int seatNumber, string customer)
        {
            if (seatNumber < 1 || seatNumber > MaxSeats)
                return false;

            using var conn = new MySqlConnection(connStr);
            conn.Open();

            if (!IsSeatFree(sessionId, seatNumber))
                return false;

            if (ReservedSeatsCount(sessionId) >= MaxSeats)
                return false;

            int row = (seatNumber - 1) / 5 + 1;

            string sql = @"INSERT INTO Ticket
                (session_id, seat_row, seat_number, status, customer_name)
                VALUES (@s, @r, @n, 'Заброньовано', @c)";

            var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@s", sessionId);
            cmd.Parameters.AddWithValue("@r", row);
            cmd.Parameters.AddWithValue("@n", seatNumber);
            cmd.Parameters.AddWithValue("@c", customer);

            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
