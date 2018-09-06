using System;
using System.Collections.Generic; 
using System.Data;
using System.Data.SQLite;
using System.Drawing; 
using System.Linq; 
using System.Windows.Forms;


namespace School.Pages
{
    public partial class AdminPanel : Form
    {
        public static Form ThisForm;

        public AdminPanel()
        {
            InitializeComponent();
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            Login.ThisForm.Show();
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Student().Show();
            ThisForm = this;
            this.Hide();
        } 

        private void aCtivationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddActivation().Show();
            ThisForm = this;
            this.Hide();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThisForm = this;
            new Categories().Show();
        }

        private void quationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThisForm = this;
            new AddQuation().Show();
            this.Hide();
        }

        private void quationsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ThisForm = this;
            new Quations().Show();
            this.Hide();
        }

        private void ticketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThisForm = this;
            new Tickets().Show();
            this.Hide();
        }

        private void profileUpdate(object sender, EventArgs e)
        {
            this.txtUsername.Text = Login.LoginedUser.Username;
            this.txtPassword.Text = Login.LoginedUser.Password;
            this.txtEmail.Text = Login.LoginedUser.Email;
            this.grpAdminInfo.Visible = !this.grpAdminInfo.Visible;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "" || txtPassword.Text.Trim() == "" || txtEmail.Text.Trim() == "")
            {
                this.lblError.Text = "Boşluq olmaz ";
                return;
            }
            using(SQLiteConnection con =new SQLiteConnection(Login.connection))
            {
                string sql = $"UPDATE Admin SET username='{this.txtUsername.Text}', password='{this.txtPassword.Text}', email='{this.txtEmail.Text}' WHERE id = {Login.LoginedUser.Id}";
                SQLiteCommand com = new SQLiteCommand(sql, con);
                con.Open();
                com.ExecuteNonQuery();
            }
            this.Close();
        }

        private void ResetApp(object sender, EventArgs e)
        { 
            DeleteTabele("Students");
            DeleteTabele("Activations");
            this.Close();
            Login.AsAdmin.Checked = false;
            Login.UsernameTxt.Text = "";
            Login.PasswordTxt.Text = ""; 
            Login.hideSignUp();
        }

       

        void DeleteTabele(string table)
        {
            using (SQLiteConnection con = new SQLiteConnection(Login.connection))
            {

                string sql = $"DELETE FROM {table}";
                SQLiteCommand com = new SQLiteCommand(sql, con);
                con.Open();
                com.ExecuteNonQuery();
            }
        }
         
    }
}
