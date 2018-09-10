using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using School.Settings;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Timers;
using System.Drawing;

namespace School.Pages
{
    partial class Login : Form
    {
        public static Models.Student LoginedUser = new Models.Student();
        public static Form ThisForm;
        public static string connection = null;
        public static LinkLabel LinkLabel = null;

        public static CheckBox RemeberMe { get; set; }

        public static CheckBox AsAdmin { get; set; }

        public static TextBox UsernameTxt { get; set; }

        public static TextBox PasswordTxt { get; set; }
       // public static Form Loading;

        static HttpClient client = new HttpClient();

        public int Count { get; set; }

        System.Timers.Timer Timer = new System.Timers.Timer();

        public Login()
        {
            InitializeComponent();
            connection = "Data Source=" + Extentions.GetPath() + @"DB\StoreDb.db;Version=3;";
            LinkLabel = this.linkSignUp;
            hideSignUp();
            AsAdmin = this.ckbAdmin;
            UsernameTxt = this.txtName;
            PasswordTxt = this.txtPassword;

            //this.Opacity = 0;
            //Loading loading = new Loading();
            //loading.setImage();
            //loading.Show();
            //Timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            //Timer.Interval = 1000;
            //Timer.Enabled = true;

         
        } 

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //Count++;
            //if (Count > 2)
            //{
            //    this.Timer.Stop();
            //    this.Timer.Dispose();


            //    this.Opacity = 1;
            //    Loading ldng = new Loading();
            //    ldng.Opacity = 0;
            //}
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            ThisForm = this;
            if (this.ckbAdmin.Checked)
            {
                if (this.isNotEmpty(this.txtName.Text, this.txtPassword.Text))
                {
                    this.cleaner();
                    if (this.hasAdmin(this.txtName.Text, this.txtPassword.Text))
                    {
                        this.Hide();
                        this.lblError.Text = "";
                        new AdminPanel().Show();
                    }
                }
            }
            else
            {
                if (hasStudent(txtName.Text, txtPassword.Text))
                {
                    this.lblError.Text = "";
                    this.Hide();
                    if (isActivated())
                    {
                        ThisForm = this;
                        new Dashboard().Show();
                    }
                    else
                    {
                        new CheckActivation().Show();
                    }
                }
                else
                {
                    this.lblError.Text = "Siz qeydiyyatdan keçməlisiniz";
                }

            }
        }

        bool isActivated()
        {
            using (SQLiteConnection con = new SQLiteConnection(connection))
            {
                string sql = "SELECT * FROM Activations";
                SQLiteCommand com = new SQLiteCommand(sql, con);
                SQLiteDataAdapter da = new SQLiteDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }




        private bool hasAdmin(string name, string password)
        {
            SQLiteConnection con = new SQLiteConnection(connection);
            string sql = "SELECT * FROM Admin WHERE username = '" + name + "' AND password = '" + password + "'";
            SQLiteCommand com = new SQLiteCommand(sql, con);
            SQLiteDataAdapter da = new SQLiteDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = com;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                LoginedUser.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                LoginedUser.Username = dt.Rows[0]["username"].ToString();
                LoginedUser.Password = dt.Rows[0]["password"].ToString();
                LoginedUser.Email = dt.Rows[0]["email"].ToString();
                return true;
            }
            else
            {
                this.lblError.Text = "İstifadəçi adı və ya Şifrə yalnışdır";
                return false;
            }
        }

        private bool hasStudent(string username, string password)
        {
            string query = "SELECT * FROM Students";
            SQLiteConnection Con = new SQLiteConnection(connection);
            SQLiteCommand Com = new SQLiteCommand(query, Con);
            SQLiteDataAdapter Da = new SQLiteDataAdapter();
            DataTable Dt = new DataTable();
            Com.Connection = Con;
            Com.CommandText = query;
            Da.SelectCommand = Com;
            Da.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                LoginedUser = new Models.Student()
                {
                    Id = Convert.ToInt32(Dt.Rows[0]["id"]),
                    Name = Dt.Rows[0]["name"].ToString(),
                    Username = Dt.Rows[0]["username"].ToString(),
                    Surname = Dt.Rows[0]["surname"].ToString(),
                    Email = Dt.Rows[0]["email"].ToString(),
                    Password = Dt.Rows[0]["password"].ToString(),
                    Image = Dt.Rows[0]["image"].ToString(),
                    Gender = Dt.Rows[0]["gender"].ToString() == "1"
                };
                return true;
            }
            return false;
        }

        public static void hideSignUp()
        {
            string query = "SELECT * FROM Students";
            SQLiteConnection Con = new SQLiteConnection(connection);
            SQLiteCommand Com = new SQLiteCommand(query, Con);
            SQLiteDataAdapter Da = new SQLiteDataAdapter();
            DataTable Dt = new DataTable();
            Com.Connection = Con;
            Com.CommandText = query;
            Da.SelectCommand = Com;
            Da.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                LinkLabel.Visible = false;
            }
            else
            {
                LinkLabel.Visible = true;
            }
        }

        private void cleaner()
        {
            this.lblPassword.Text = "";
            this.lblUsername.Text = "";
        }

        private bool isNotEmpty(string username, string password)
        {
            this.cleaner();
            if (username == "")
            {
                this.lblError.Text = "";
                this.lblUsername.Text = "İstifadəçi adı boş olmaz";
                this.ActiveControl = this.txtName;
                return false;
            }
            if (password == "")
            {
                this.lblError.Text = "";
                this.lblPassword.Text = "Şifrə boş olmaz ";
                this.ActiveControl = this.txtPassword;
                return false;
            }
            return true;
        }

        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ThisForm = this;
            this.Hide();
            new Register().Show();
        }

        private void ckbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlLogin.Visible = this.ckbAdmin.Checked;
        }
         
        private void rtbSender_KeyDown(object sender, KeyEventArgs e)
        {

            Clipboard.Clear();

        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            //Loading.ThisForm.Close(); 
            //Dashboard.ThisForm.Close();
            try
            {
                //Dashboard.ThisForm.Dispose();
                Application.Exit();
            }
            catch (Exception)
            {
            } 
        }

        private void Login_Load(object sender, EventArgs e)
        {
            linkSignUp.Left = (this.Width - linkSignUp.Width) - 30;
            grpLogin.Left = (this.Width - grpLogin.Width) / 2;
            grpLogin.Top = (this.Height - grpLogin.Height) / 2;
        }

        private void FormResize(object sender, EventArgs e)
        {
            linkSignUp.Left = (this.Width - linkSignUp.Width) - 30;
            grpLogin.Left = (this.Width - grpLogin.Width) / 2;
            grpLogin.Top = (this.Height - grpLogin.Height) / 2;
        }
    }
}
