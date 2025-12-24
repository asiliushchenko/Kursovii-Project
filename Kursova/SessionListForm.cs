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
    public partial class SessionListForm : Form
    {
        string connStr = "server=localhost;user=root;password=Marshmello135;database=cinema_db;";
        public SessionListForm()
        {
            InitializeComponent();
            LoadSessions();
            LoadFilmsToCombo();
        }
        private void LoadSessions()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
            SELECT 
                Session.session_id,
                Film.title AS film_title,
                Hall.hall_name,
                Session.start_time,
                Session.price
            FROM Session
            JOIN Film ON Session.film_id = Film.film_id
            JOIN Hall ON Session.hall_id = Hall.hall_id;";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSessions.DataSource = dt;

                dgvSessions.Columns["session_id"].HeaderText = "ID сеансу";
                dgvSessions.Columns["film_title"].HeaderText = "Фільм";
                dgvSessions.Columns["hall_name"].HeaderText = "Зал";
                dgvSessions.Columns["start_time"].HeaderText = "Час початку";
                dgvSessions.Columns["price"].HeaderText = "Ціна квитка";

                dgvSessions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnHallScheme_Click(object sender, EventArgs e)
        {
            if (dgvSessions.CurrentRow == null)
            {
                MessageBox.Show("Оберіть сеанс");
                return;
            }

            int sessionId = Convert.ToInt32(dgvSessions.CurrentRow.Cells["session_id"].Value);

            HallSchemeForm form = new HallSchemeForm(sessionId, LoginForm.CurrentUserRole);
            form.ShowDialog();
        }

        private void btnDeleteSession_Click(object sender, EventArgs e)
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

            if (dgvSessions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть сеанс");
                return;
            }

            int sessionId = Convert.ToInt32(
                dgvSessions.SelectedRows[0].Cells["session_id"].Value);

            if (MessageBox.Show(
                "Видалити сеанс і всі квитки?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                MySqlCommand cmd1 = new MySqlCommand(
                    "DELETE FROM Ticket WHERE session_id=@id", conn);
                cmd1.Parameters.AddWithValue("@id", sessionId);
                cmd1.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand(
                    "DELETE FROM Session WHERE session_id=@id", conn);
                cmd2.Parameters.AddWithValue("@id", sessionId);
                cmd2.ExecuteNonQuery();
            }

            LoadSessions();
        }

        private void btnFilterDate_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
            SELECT s.session_id, f.title AS film, h.hall_name AS hall,
                   s.start_time, s.price
            FROM Session s
            JOIN Film f ON s.film_id = f.film_id
            JOIN Hall h ON s.hall_id = h.hall_id
            WHERE DATE(s.start_time) = @d";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@d", dtpDate.Value.Date);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSessions.DataSource = dt;
            }
        }

        private void LoadFilmsToCombo()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string sql = "SELECT film_id, title FROM Film";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbFilm.DataSource = dt;
                cmbFilm.DisplayMember = "title";
                cmbFilm.ValueMember = "film_id";
                cmbFilm.SelectedIndex = -1;
            }
        }

        private void btnFilterFilm_Click(object sender, EventArgs e)
        {
            int filmId = (int)cmbFilm.SelectedValue;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
            SELECT s.session_id, f.title, h.hall_name,
                   s.start_time, s.price
            FROM Session s
            JOIN Film f ON s.film_id = f.film_id
            JOIN Hall h ON s.hall_id = h.hall_id
            WHERE s.film_id = @id";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@id", filmId);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSessions.DataSource = dt;
            }
        }
    }
}
