using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursova
{
    public partial class TicketListForm : Form
    {
        string connStr = "server=localhost;user=root;password=Marshmello135;database=cinema_db;";
        public TicketListForm()
        {
            InitializeComponent();
            LoadTickets();
            LoadStatuses();
        }

        private void LoadTickets()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = @"SELECT * FROM Ticket";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTickets.DataSource = dt;

                dgvTickets.Columns["ticket_id"].HeaderText = "ID квитка";
                dgvTickets.Columns["session_id"].HeaderText = "ID сеансу";
                dgvTickets.Columns["seat_row"].HeaderText = "Ряд";
                dgvTickets.Columns["seat_number"].HeaderText = "Номер місця";
                dgvTickets.Columns["status"].HeaderText = "Статус";
                dgvTickets.Columns["customer_name"].HeaderText = "Відвідувач";
            }
        }

        private void btnDeleteTicket_Click(object sender, EventArgs e)
        {
            if (LoginForm.CurrentUserRole != "manager")
            {
                MessageBox.Show(
                    "У вас немає прав на видалення даних",
                    "Доступ заборонено",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (dgvTickets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть квиток");
                return;
            }

            int ticketId = Convert.ToInt32(
                dgvTickets.SelectedRows[0].Cells["ticket_id"].Value);

            if (MessageBox.Show(
                "Видалити квиток?",
                "Підтвердження",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(
                    "DELETE FROM Ticket WHERE ticket_id=@id", conn);
                cmd.Parameters.AddWithValue("@id", ticketId);
                cmd.ExecuteNonQuery();
            }
            LoadTickets();
        }

        private void btnFilterStatus_Click(object sender, EventArgs e)
        {
            string status = cmbStatus.SelectedItem.ToString();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string sql = "SELECT * FROM Ticket WHERE status=@s";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@s", status);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTickets.DataSource = dt;
            }
        }

        private void LoadStatuses()
        {
            cmbStatus.Items.Clear();

            cmbStatus.Items.Add("Заброньовано");
            cmbStatus.Items.Add("Вільне");
            cmbStatus.SelectedIndex = -1;
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
