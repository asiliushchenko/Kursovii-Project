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
    public partial class FilmListForm : Form
    {
        string connStr = "server=localhost;user=root;password=Marshmello135;database=cinema_db;";
        public FilmListForm()
        {
            InitializeComponent();
            LoadFilms();
        }
        private void LoadFilms()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM Film";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvFilms.DataSource = dt;

                dgvFilms.Columns["film_id"].HeaderText = "ID";
                dgvFilms.Columns["title"].HeaderText = "Назва";
                dgvFilms.Columns["genre"].HeaderText = "Жанр";
                dgvFilms.Columns["duration"].HeaderText = "Тривалість (хв)";
                dgvFilms.Columns["age_rating"].HeaderText = "Вік";
                dgvFilms.Columns["description"].HeaderText = "Опис";

                dgvFilms.Columns["title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvFilms.Columns["description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            }
        }

        private void btnDeleteFilm_Click(object sender, EventArgs e)
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

            if (dgvFilms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть фільм для видалення");
                return;
            }

            int filmId = Convert.ToInt32(
                dgvFilms.SelectedRows[0].Cells["film_id"].Value);

            DialogResult dr = MessageBox.Show(
                "Ви впевнені, що хочете видалити фільм?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
                return;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(
                    "DELETE FROM Film WHERE film_id = @id", conn);
                cmd.Parameters.AddWithValue("@id", filmId);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Фільм видалено");
                    LoadFilms();
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Неможливо видалити фільм, оскільки він використовується у сеансах");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string text = txtSearch.Text.Trim();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string sql = @"SELECT * FROM Film
                       WHERE title LIKE @q OR genre LIKE @q";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@q", "%" + text + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvFilms.DataSource = dt;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadFilms();
            txtSearch.Clear();
        }
    }
}
