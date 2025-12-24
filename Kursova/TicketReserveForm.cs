using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Kursova
{
    public partial class TicketReserveForm : Form
    {
        string connStr = "server=localhost;user=root;password=Marshmello135;database=cinema_db;";
        private int sessionId;
        private int seatNumber;

        public TicketReserveForm(int sessionId, int seatNumber)
        {
            InitializeComponent();
            this.sessionId = sessionId;
            this.seatNumber = seatNumber;
            LoadSessions();
            txtRow.Text = ((seatNumber - 1) / 5 + 1).ToString();
            txtSeat.Text = seatNumber.ToString();
        }

        private void LoadSessions()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT session_id FROM Session", conn);
                var r = cmd.ExecuteReader();
                while (r.Read())
                    cmbSession.Items.Add(r.GetInt32(0));
            }
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            if (cmbSession.SelectedItem == null)
            {
                MessageBox.Show("Оберіть сеанс!");
                return;
            }

            int sessionId = (int)cmbSession.SelectedItem;
            int row, seatNum;

            if (!int.TryParse(txtRow.Text, out row) || row < 1 || row > 4)
            {
                MessageBox.Show("Ряд повинен бути від 1 до 4.");
                return;
            }

            if (!int.TryParse(txtSeat.Text, out seatNum))
            {
                MessageBox.Show("Неправильний номер місця.");
                return;
            }

            int min = (row - 1) * 5 + 1;
            int max = row * 5;

            if (seatNum < min || seatNum > max)
            {
                MessageBox.Show($"В {row}-м ряду може бути від {min} до {max} місць.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                int hallId;
                MySqlCommand cmdHall = new MySqlCommand(
                    "SELECT hall_id FROM Session WHERE session_id = @id", conn);
                cmdHall.Parameters.AddWithValue("@id", sessionId);
                hallId = Convert.ToInt32(cmdHall.ExecuteScalar());

                MySqlCommand cmdCount = new MySqlCommand(
                    "SELECT COUNT(*) FROM Ticket WHERE session_id IN " +
                    "(SELECT session_id FROM Session WHERE hall_id = @h)", conn);
                cmdCount.Parameters.AddWithValue("@h", hallId);

                int count = Convert.ToInt32(cmdCount.ExecuteScalar());
                if (count >= 20)
                {
                    MessageBox.Show("В цьому залі всі місця заброньовані!");
                    return;
                }

                MySqlCommand cmdCheck = new MySqlCommand(
                    "SELECT COUNT(*) FROM Ticket WHERE session_id = @s AND seat_number = @n", conn);
                cmdCheck.Parameters.AddWithValue("@s", sessionId);
                cmdCheck.Parameters.AddWithValue("@n", seatNum);

                int exists = Convert.ToInt32(cmdCheck.ExecuteScalar());
                if (exists > 0)
                {
                    MessageBox.Show($"Місце №{seatNum} заброньовано!");
                    return;
                }

                string sql = "INSERT INTO Ticket (session_id, seat_row, seat_number, status, customer_name) " +
                             "VALUES (@s, @r, @n, 'Заброньовано', @c)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@s", sessionId);
                cmd.Parameters.AddWithValue("@r", row);
                cmd.Parameters.AddWithValue("@n", seatNum);
                cmd.Parameters.AddWithValue("@c", txtName.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Місце успішно заброньовано!");
            this.Close();
        }
    }
}
