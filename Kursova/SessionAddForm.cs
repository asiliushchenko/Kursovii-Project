using Google.Protobuf.WellKnownTypes;
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
    public partial class SessionAddForm : Form
    {
        string connStr = "server=localhost;user=root;password=Marshmello135;database=cinema_db;";
        public SessionAddForm()
        {
            InitializeComponent();
            LoadFilms();
            LoadHalls();
        }
        private void LoadFilms()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT film_id, title FROM Film", conn);
                MySqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                    cmbFilm.Items.Add($"{r[0]} - {r[1]}");
            }
        }
        private void LoadHalls()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT hall_id, hall_name FROM Hall", conn);
                MySqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                    cmbHall.Items.Add($"{r[0]} - {r[1]}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int film_id = int.Parse(cmbFilm.Text.Split(' ')[0]);
            int hall_id = int.Parse(cmbHall.Text.Split(' ')[0]);
            int filmId = (int)cmbFilm.SelectedValue;
            int hallId = (int)cmbHall.SelectedValue;
            DateTime startTime = dtpStartTime.Value;
            int duration;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                MySqlCommand cmdDur = new MySqlCommand(
                    "SELECT duration FROM Film WHERE film_id=@id", conn);
                cmdDur.Parameters.AddWithValue("@id", filmId);

                duration = Convert.ToInt32(cmdDur.ExecuteScalar());

                string checkSql = @"
            SELECT COUNT(*) 
            FROM Session s
            JOIN Film f ON s.film_id = f.film_id
            WHERE s.hall_id = @hall
            AND @start < DATE_ADD(s.start_time, INTERVAL f.duration MINUTE)
            AND DATE_ADD(@start, INTERVAL @dur MINUTE) > s.start_time";

                MySqlCommand checkCmd = new MySqlCommand(checkSql, conn);
                checkCmd.Parameters.AddWithValue("@hall", hallId);
                checkCmd.Parameters.AddWithValue("@start", startTime);
                checkCmd.Parameters.AddWithValue("@dur", duration);

                int conflicts = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (conflicts > 0)
                {
                    MessageBox.Show("У цьому залі вже є сеанс, що перетинається за часом!");
                    return;
                }

                string insertSql = @"
            INSERT INTO Session (film_id, hall_id, start_time, price)
            VALUES (@f, @h, @t, @p)";

                MySqlCommand insertCmd = new MySqlCommand(insertSql, conn);
                insertCmd.Parameters.AddWithValue("@f", filmId);
                insertCmd.Parameters.AddWithValue("@h", hallId);
                insertCmd.Parameters.AddWithValue("@t", startTime);
                insertCmd.Parameters.AddWithValue("@p", decimal.Parse(txtPrice.Text));

                insertCmd.ExecuteNonQuery();
            }
            MessageBox.Show("Сеанс успішно додано!");
            this.Close();
        }

    }

}
