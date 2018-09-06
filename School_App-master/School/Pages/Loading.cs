using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace School.Pages
{
    public partial class Loading : Form
    {
        public static Form Login;
        public static Form ThisForm { get; set; }
        public Loading()
        {
           
            InitializeComponent();
            ThisForm = this;
            this.FormBorderStyle = FormBorderStyle.None;
        }
        public void setImage()
        {
            this.BackgroundImage = School.Properties.Resources.initial;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Loading_Load(object sender, EventArgs e)
        {
          
            timer1.Enabled = true;

        }
        int vaxt = 3;
        private void timer1_Tick(object sender, EventArgs e)
        {
            vaxt--;
           
            if (vaxt == 0)
            {
                this.Hide();
                Login lgn = new Login();
                lgn.Show();
                
                timer1.Stop();

            }
        }
    }
}
