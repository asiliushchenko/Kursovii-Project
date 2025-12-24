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
using static System.Net.Mime.MediaTypeNames;

namespace Kursova
{
    public partial class FilmAddForm : Form
    {
        string connStr = "server=localhost;user=root;password=Marshmello135;database=cinema_db;";
        public FilmAddForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string genre = txtGenre.Text.Trim();
            string age = cmbAge.SelectedItem.ToString();
            int duration;

            if (!int.TryParse(txtDuration.Text, out duration))
            {
                MessageBox.Show("Введіть коректну тривалість фільму!",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(genre))
            {
                MessageBox.Show("Заповніть всі поля!",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = "INSERT INTO Film (title, genre, duration, age_rating, description) VALUES (@t, @g, @d, @a, @desc)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@t", txtTitle.Text);
                cmd.Parameters.AddWithValue("@g", txtGenre.Text);
                cmd.Parameters.AddWithValue("@d", int.Parse(txtDuration.Text));
                cmd.Parameters.AddWithValue("@a", cmbAge.Text);
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Фільм успішно доданий!",
                "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
