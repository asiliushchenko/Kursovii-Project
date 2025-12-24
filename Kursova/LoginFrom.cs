using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Kursova
{
    public partial class LoginForm : Form
    {
        string connStr = "server=localhost;user=root;password=Marshmello135;database=cinema_db;";

        public static string CurrentUserRole = "";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string sql = "SELECT role FROM users WHERE username=@u AND password=@p LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    CurrentUserRole = result.ToString();
                    MessageBox.Show($"Вхід успішний! Роль: {CurrentUserRole}");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Невірний логін або пароль.");
                }
            }
        }
    }
}
