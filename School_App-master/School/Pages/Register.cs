using System; 
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Net;
using School.Settings;

namespace School.Pages
{
    public partial class Register : Form
    {  
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (this.isNotEmpty())
            { 
                string name = this.txtName.Text;
                string surname = this.txtSurname.Text;
                string email = this.txtEmail.Text;
                int gender = this.ckbMale.Checked ? 1 : 0;
                 

                string sql = "INSERT INTO Students(name, surname, username, email, password, gender, image) VALUES('" + name + "', '" + surname + "', '', '" + email + "', '', " + gender + ", '')";
                using(SQLiteConnection con = new SQLiteConnection(Login.connection))
                {
                    con.Open();
                    using (SQLiteCommand com = new SQLiteCommand(sql,con))
                    { 
                        com.ExecuteNonQuery();
                    }
                }
                btnRegister.Enabled = false;
                cleaner();
                this.Close();
            } 
        }

        bool isNotEmpty()
        {
            if (this.txtName.Text == "")
            {
                this.lblName.Text = "Ad boş olmaz ";
                this.ActiveControl = this.txtName;
                return false;
            }
            if (this.txtSurname.Text == "")
            {
                this.lblSurname.Text = "Soyad boş olmaz ";
                this.ActiveControl = this.txtSurname;
                return false;
            } 
            if (!(this.ckbMale.Checked || this.ckbFemale.Checked))
            {
                this.lblGender.Text = "Cins boş olmaz ";
                return false;
            }
            return true;
        }

        void cleaner()
        {
            this.txtName.Text = "";
            this.txtSurname.Text = "";
            this.txtEmail.Text = "";
            this.ckbMale.Checked  = false;
            this.ckbFemale.Checked = false;
            this.lblName.Text = "";
            this.lblSurname.Text = "";
            this.lblGender.Text = "";
        } 

        private void Closing(object sender, FormClosingEventArgs e)
        {
            Login.hideSignUp();
            Login.ThisForm.Show();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
