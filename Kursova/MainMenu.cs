using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Kursova
{
    public partial class MainMenu : Form
    {
        string connStr = "server=localhost;user=root;password=Marshmello135;database=cinema_db;";
        private string currentUserRole = "viewer";

        public MainMenu()
        {
            InitializeComponent();
            ApplyRoleAccess();
        }

        private void ApplyRoleAccess()
        {
            btnAddFilm.Visible = false;
            btnAddSession.Visible = false;
            btnViewTickets.Visible = false;

            btnViewFilms.Visible = true;
            btnViewSessions.Visible = true;

            if (currentUserRole == "cashier")
            {
                btnViewTickets.Visible = true;
            }

            if (currentUserRole == "manager")
            {
                btnAddFilm.Visible = true;
                btnAddSession.Visible = true;
                btnViewTickets.Visible = true;
            }
        }

        private void btnAddFilm_Click(object sender, EventArgs e)
        {
            FilmAddForm form = new FilmAddForm();
            form.ShowDialog();
        }

        private void btnViewFilms_Click(object sender, EventArgs e)
        {
            FilmListForm form = new FilmListForm();
            form.ShowDialog();
        }

        private void btnAddSession_Click(object sender, EventArgs e)
        {
            SessionAddForm form = new SessionAddForm();
            form.ShowDialog();
        }

        private void btnViewSessions_Click(object sender, EventArgs e)
        {
            SessionListForm form = new SessionListForm();
            form.ShowDialog();
        }

        private void btnViewTickets_Click(object sender, EventArgs e)
        {
            TicketListForm form = new TicketListForm();
            form.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            currentUserRole = "viewer";
            ApplyRoleAccess();
            MessageBox.Show("Ви увійшли як відвідувач");
        }

        private void btnStaffLogin_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            if (lf.ShowDialog() == DialogResult.OK)
            {
                currentUserRole = LoginForm.CurrentUserRole;
                ApplyRoleAccess();
            }
        }
    }
}