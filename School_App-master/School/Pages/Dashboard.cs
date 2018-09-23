using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using School.Models;
using System.Timers;

namespace School.Pages
{
    public partial class Dashboard : Form
    {
        Loading loadingm = new Loading();
       
        public int MessageSecond { get; set; } = 0;
        System.Timers.Timer MessageTimer = new System.Timers.Timer();
        public static Form ThisForm { get; set; }

        public Dashboard()
        {
            InitializeComponent();
            ThisForm = this;
            this.pctMain.Image = School.Properties.Resources.dashboard;
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            Login.ThisForm.Show();
        }

        private void QuationClick(object sender, EventArgs e)
        {
            try
            {
                this.Hide(); 
                new StuQuation().Show();
            }
            catch (Exception)
            { 
                this.Show();
                MessageBox.Show("Sual əlavə olunmayıb", "Sualinfo"); 
            } 
        }


        private void CloseMessage1(object source, ElapsedEventArgs e)
        {
            MessageSecond++;
            if (MessageSecond > 2)
            {
                this.MessageTimer.Stop();
                this.MessageTimer.Dispose();
                loadingm.Close();
                this.Close();
            }
        }
        private void ShowResponse1(string message, Color back_color)
        {

            loadingm.lblMessage.Text = message;
            loadingm.lblMessage.Left = ((loadingm.Width - loadingm.lblMessage.Width) / 2);
            loadingm.lblMessage.ForeColor = Color.White;
            loadingm.BackColor = back_color;
            loadingm.Show(this);
            MessageTimer.Elapsed += new ElapsedEventHandler(CloseMessage1);
            MessageTimer.Interval = 1000;
            MessageTimer.Enabled = true;
        }
        private void TicketClick(object sender, EventArgs e)
        { 
                this.Hide();
                new StuTicket().Show();
             
        }

        private void UpdateProfile(object sender, EventArgs e)
        {
            this.txtEmail.Text = Login.LoginedUser.Email;
            this.txtName.Text = Login.LoginedUser.Name;
            this.txtSurname.Text = Login.LoginedUser.Surname;
            if (Login.LoginedUser.Gender)
            {
                this.ckbMale.Checked = true;
            }
            else
            {
                this.ckbFemale.Checked = true;
            }
            this.grpStuProfile.Visible = true;
            this.pctMain.Visible = false;
            this.pnlAbout.Visible = false;
        }



        private void FormResize(object sender, EventArgs e)
        {
            this.pctMain.Width = this.Width - 200;
            this.pctMain.Height = this.Height - 100;

            this.grpStuProfile.Left = ((this.Width - this.grpStuProfile.Width) / 2 - 8);
            this.pctMain.Left = ((this.Width - this.pctMain.Width) / 2 - 8);
            this.pnlAbout.Left = ((this.Width - this.pnlAbout.Width) / 2 - 8);
            this.pnlAbout.Height = this.Height - 100;
            
            if(this.WindowState == FormWindowState.Maximized)
            {
                this.Width = 1000;
                this.Height = 500;
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.pctMain.Width = this.Width - 200;
            this.pctMain.Height = this.Height - 100; 
            this.pctMain.Left = ((this.Width - this.pctMain.Width) / 2 - 8);
            //this.Top = (this.Height - this.pctMain.Height) / 2;
            this.pctMain.Top = 50;

            this.pnlAbout.Left = (this.Width - this.pnlAbout.Width) / 2;
            this.pnlAbout.Height = this.Height - 100;
            this.pnlAbout.Top = 50;




            // this.lbl_about.Font = new Font("Microsoft Sans Serif", this.Width / 95, FontStyle.Italic);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.grpStuProfile.Visible = false;
            this.pctMain.Visible = false;
            this.pnlAbout.Visible = true;
        }
          
        private void Dashboard_FontChanged(object sender, EventArgs e)
        {
            //this.grpInfo.Width = this.grpInfo.Width + ((this.Width - this.grpInfo.Width) / 2);
            this.pctMain.Width = this.pctMain.Width + ((this.Width - this.pctMain.Width) / 2);
        }

        private void əsasSəhifəToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.grpStuProfile.Visible = false;
            this.pctMain.Visible = true;
            this.pnlAbout.Visible = false;
        }
    }
}
