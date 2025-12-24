using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Kursova
{
    public partial class HallSchemeForm : Form
    {
        string connStr = "server=localhost;user=root;password=Marshmello135;database=cinema_db;";
        int currentSessionId;
        private string currentUserRole;

        Dictionary<int, string> seats = new Dictionary<int, string>();

        public HallSchemeForm(int sessionId, string userRole)
        {
            InitializeComponent();
            currentSessionId = sessionId;
            currentUserRole = userRole;
            LoadSeats();
        }

        private void LoadSeats()
        {
            seats.Clear();
            panelSeats.Controls.Clear();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string sql = "SELECT seat_number, status FROM Ticket WHERE session_id = @s";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@s", currentSessionId);

                var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    seats[r.GetInt32(0)] = r.GetString(1);
                }
            }

            CreateSeatButtons();
        }

        private void CreateSeatButtons()
        {
            int seatNumber = 1;

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    Button btn = new Button();
                    btn.Width = 45;
                    btn.Height = 45;
                    btn.Left = col * 50;
                    btn.Top = row * 50;

                    btn.Text = seatNumber.ToString();
                    btn.Tag = seatNumber;
                    btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    btn.Click += Seat_Click;

                    if (!seats.ContainsKey(seatNumber))
                        btn.BackColor = Color.LightGreen;
                    else
                    {
                        string status = seats[seatNumber];
                        if (status == "Вільно")
                            btn.BackColor = Color.LightGreen;
                        else if (status == "Заброньовано")
                            btn.BackColor = Color.Red;
                        else
                            btn.BackColor = Color.LightGreen;

                    }

                    panelSeats.Controls.Add(btn);
                    seatNumber++;
                }
            }
        }

        private void Seat_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int seatNumber = (int)btn.Tag;

            if (btn.BackColor == Color.Gold)
            {
                MessageBox.Show("Місце вже заброньовано!");
                return;
            }

            if (currentUserRole != "cashier")
            {
                MessageBox.Show("Тільки касир може бронювати місця.");
                return;
            }

            TicketReserveForm reserveForm = new TicketReserveForm(currentSessionId, seatNumber);
            reserveForm.ShowDialog();

            LoadSeats();
        }


        private void ReserveSeat(int seatNumber)
        {
            int row = (seatNumber - 1) / 5 + 1;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string checkSql = @"SELECT COUNT(*) 
                                    FROM Ticket 
                                    WHERE session_id=@s AND seat_number=@n";

                MySqlCommand checkCmd = new MySqlCommand(checkSql, conn);
                checkCmd.Parameters.AddWithValue("@s", currentSessionId);
                checkCmd.Parameters.AddWithValue("@n", seatNumber);

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                string sql;
                if (count == 0)
                {
                    sql = @"INSERT INTO Ticket 
                            (session_id, seat_row, seat_number, status)
                            VALUES (@s, @r, @n, 'reserved')";
                }
                else
                {
                    sql = @"UPDATE Ticket 
                            SET status='reserved'
                            WHERE session_id=@s AND seat_number=@n";
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@s", currentSessionId);
                cmd.Parameters.AddWithValue("@r", row);
                cmd.Parameters.AddWithValue("@n", seatNumber);

                cmd.ExecuteNonQuery();
            }
        }
    }
}