using School.Models;
using School.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows.Forms;

namespace School.Pages
{
    partial class StuTicket : Form
    {
        public static Form ThisForm { get; set; }

        public List<Quation> Quations { get; set; } = new List<Quation>();

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();

        public List<P_TicketAndQuation> Pivot { get; set; } = new List<P_TicketAndQuation>();

        public List<Quation> selectedQuatins { get; set; } = new List<Quation>();

        public List<Quation> IncorrectQuations { get; set; } = new List<Quation>();

        public int CorrectCount { get; set; }

        public string SelectedText { get; set; }

        public bool CheckCombo { get; set; } = false;

        public bool IsClose { get; set; } = true;

        System.Timers.Timer Timer = new System.Timers.Timer();

        System.Timers.Timer MessageTimer = new System.Timers.Timer();

        public int Index { get; set; } = 0;

        public int Minut { get; set; } = 15;

        public int Second { get; set; } = 1;

        public int MessageSecond { get; set; } = 0;

        mesaj loadingm = new mesaj();
        


        public StuTicket()
        {
            InitializeComponent();
            this.lblName.Text = Login.LoginedUser.Name;
            this.lblSurname.Text = Login.LoginedUser.Surname;
            this.Quations = getData<Quation>("Quations") as List<Quation>;
            this.Tickets = getData<Ticket>("Tickets") as List<Ticket>;
            this.Pivot = getData<P_TicketAndQuation>("P_TicketAndQuation") as List<P_TicketAndQuation>;
            fillCmbTickets();
            setTimer(1000);
            ThisForm = this;
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            if (IsClose) 
            {
                DialogResult result = MessageBox.Show("Programdan çıxmağa əminsinizmi ?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    SendKeys.Send("{esc}");
                    e.Cancel = true;
                    return;
                }
            }

            this.Timer.Stop();
            this.Timer.Dispose();
            try
            {
                Dashboard.ThisForm.Show();
            }
            catch (Exception)
            {
            }
        }

        private List<T> getData<T>(string table)
        {
            List<T> list = new List<T>();
            List<Quation> quations = new List<Quation>();
            List<Ticket> tickets = new List<Ticket>();
            List<P_TicketAndQuation> pivot = new List<P_TicketAndQuation>();


            using (SQLiteConnection con = new SQLiteConnection(Login.connection))
            {
                string sql = "SELECT * FROM " + table;
                SQLiteCommand com = new SQLiteCommand(sql, con);
                SQLiteDataAdapter da = new SQLiteDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (table == "Quations")
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        quations.Add(new Quation
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Image = row["image"].ToString(),
                            Answer = row["answer"].ToString(),
                            Category_id = Convert.ToInt32(row["category_id"])
                        });

                    }
                    list = quations as List<T>;
                }
                if (table == "Tickets")
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        tickets.Add(new Ticket
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Name = row["name"].ToString()
                        });

                    }
                    list = tickets as List<T>;
                }
                if (table == "P_TicketAndQuation")
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        pivot.Add(new P_TicketAndQuation
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Quation_id = Convert.ToInt32(row["quation_id"]),
                            Ticket_id = Convert.ToInt32(row["ticket_id"])
                        });

                    }
                    list = pivot as List<T>;
                }

            }

            return list;
        }

        private void fillCmbTickets()
        {
            this.cmbTicket.Items.Clear();
            foreach (Ticket item in this.Tickets)
            {
                ComboboxItem itm = new ComboboxItem
                {
                    Text = item.Name,
                    Value = item.Id
                };
                cmbTicket.Items.Add(itm);
            }
            if (cmbTicket.Items.Count > 0) 
            cmbTicket.SelectedIndex = 0;
        }
          
        private void setQuation()
        { 
                using (FileStream s = new FileStream(Extentions.GetPath() + "\\Quations_Images\\" + this.selectedQuatins[Index].Image, FileMode.Open))
                {
                    this.pctTicket.Image = Image.FromStream(s);
                }
                this.cleaner(); 
        }

        private void cmbTicket_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckCombo && SelectedText != cmbTicket.Text)
            {
                DialogResult result = MessageBox.Show("Programdan çıxmağa əminsinizmi ?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    cmbTicket.Text = SelectedText;
                    return;
                }
            }
            if(SelectedText != cmbTicket.Text)
            {
                this.selectedQuatins.Clear();
                this.IncorrectQuations.Clear();
                this.Index = 0;
                this.CorrectCount = 0;
                int tickt_id = Convert.ToInt32((cmbTicket.SelectedItem as ComboboxItem).Value);
                foreach (P_TicketAndQuation item in this.Pivot.Where(p => p.Ticket_id == tickt_id).ToList())
                {
                    this.selectedQuatins.Add(this.Quations.First(q => q.Id == item.Quation_id));
                }
                this.setQuation();
                foreach (Button btn in this.grpQuations.Controls)
                {
                    btn.BackColor = Color.Black;
                    btn.Enabled = true;
                }

                this.Minut = 15;
                this.Second = 0;
                this.lblDuration.Text = "15:00";

                SelectedText = cmbTicket.Text;
                CheckCombo = true;
            }
        }
          
        private void btnAnswer(object sender, EventArgs e)
        {
            foreach (Button _btn in grpAnswers.Controls)
            {
                _btn.Enabled = false;
            }
            bool result;
            Button btn = sender as Button;
            
            string answer = this.selectedQuatins[Index].Answer;
             
            if (btn.Text == answer)
            { 
                lblResponse1.Text = "Cavab Doğrudur";
                lblResponse1.Left = (this.Width - lblResponse1.Width) / 2;
                lblResponse1.ForeColor = Color.Green;

                btn.BackColor = Color.LawnGreen;
                result = true;
                CorrectCount++;
                if (CorrectCount == 9)
                {
                    ShowResponse("Hörmətli " + Login.LoginedUser.Name +" "+Login.LoginedUser.Surname +"! \r\n Təbriklər, siz Yol Hərəkəti \r\n Qaydaları üzrə nəzəri \r\n  imtahandan keçdiniz", Color.Green);
                    this.IsClose = false;
                } 
            } 
            else
            { 
                lblResponse1.Text = "Cavab Səhvdir";
                lblResponse1.Left = (this.Width - lblResponse1.Width) / 2; 
                lblResponse1.ForeColor = Color.Red;


                btn.BackColor = Color.Red;
                foreach (Button _btn in grpAnswers.Controls)
                {
                    if (_btn.Text == answer)
                        _btn.BackColor = Color.LawnGreen;
                }


                IncorrectQuations.Add(selectedQuatins[Index]);
                result = false;
                checkExem(); 
            }

            foreach (Button btnQua in this.grpQuations.Controls)
            {
                if ((Convert.ToInt32(btnQua.Text) - 1) == this.Index)
                {
                    btnQua.BackColor = result ? Color.LawnGreen : Color.Red;
                }
            } 
            DisableBUttons();
        }

        void DisableBUttons()
        {
            foreach (Control ctr in grpQuations.Controls)
            {
                if(ctr.BackColor == Color.Red||ctr.BackColor == Color.LawnGreen)
                {
                    ctr.Enabled = false;
                }
            }
        }

        private void ShowResponse(string message, Color back_color)
        {
           
            loadingm.lblMessage.Text = message;
            loadingm.lblMessage.Top = (loadingm.Height - loadingm.lblMessage.Height) / 2;
            loadingm.lblMessage.Left = ((loadingm.Width - loadingm.lblMessage.Width) / 2);
            loadingm.lblMessage.ForeColor = Color.White;
            loadingm.BackColor = back_color;
            
            
            loadingm.Show(this);
            MessageTimer.Elapsed += new ElapsedEventHandler(CloseMessage);
            MessageTimer.Interval = 1000;
            MessageTimer.Enabled = true;
        }
       
        private void checkExem()
        {
            if (this.IncorrectQuations.Count >= 2)
            {
                this.Timer.Stop();
                this.Timer.Dispose();
                ShowResponse("Təəssüf, siz imtahandan \r\n keçmədiniz", Color.Red);
                this.IsClose = false;
            }
        }

        private void cleaner()
        {
            foreach (Button btn in this.grpAnswers.Controls)
            { 
                btn.BackColor = Color.Black;
                btn.Enabled = true;
            }
            this.lblResponse1.Text = "";
        }

        private void setTimer(int interval)
        {
            Timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            Timer.Interval = interval;
            Timer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (this.Minut == 0 && this.Second ==00)
            {
                this.Timer.Stop();
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                btn01.Enabled = true;
                btn02.Enabled = true;
                btn03.Enabled = true;
                btn04.Enabled = true;
                btn05.Enabled = true;
                this.Timer.Dispose();
                
               
                this.Close();
                MessageBox.Show("Təəssüf, vaxtınız bitti!");
            }
            if (this.Second > 0)
            {
                this.lblDuration.Text = this.Minut + ":" + --this.Second;
            }
            else
            {
                this.Second = 60;
                this.Minut--;
            }
        }

        private void CloseMessage(object source, ElapsedEventArgs e)
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
         
        public void SelectButton(object sender, EventArgs e)
        {
            int num = Convert.ToInt32((sender as Button).Text);
            this.Index = --num;
            this.setQuation();
            if (button1.BackColor == Color.LawnGreen)
            {
                button1.Enabled = false;
            }
            if (button2.BackColor == Color.LawnGreen)
            {
                button2.Enabled = false;
            }
            if (button3.BackColor == Color.LawnGreen)
            {
                button3.Enabled = false;
            }
            if (button4.BackColor == Color.LawnGreen)
            {
                button4.Enabled = false;
            }
            if (button5.BackColor == Color.LawnGreen)
            {
                button5.Enabled = false;
            }
            if (button6.BackColor == Color.LawnGreen)
            {
                button6.Enabled = false;
            }
            if (button7.BackColor == Color.LawnGreen)
            {
                button7.Enabled = false;
            }
            if (button8.BackColor == Color.LawnGreen)
            {
                button8.Enabled = false;
            }
            if (button9.BackColor == Color.LawnGreen)
            {
                button9.Enabled = false;
            }
            if (button10.BackColor == Color.LawnGreen)
            {
                button10.Enabled = false;
            }
            /// 
            if (button1.BackColor == Color.Red)
            {
                button1.Enabled = false;
            }
            if (button2.BackColor == Color.Red)
            {
                button2.Enabled = false;
            }
            if (button3.BackColor == Color.Red)
            {
                button3.Enabled = false;
            }
            if (button4.BackColor == Color.Red)
            {
                button4.Enabled = false;
            }
            if (button5.BackColor == Color.Red)
            {
                button5.Enabled = false;
            }
            if (button6.BackColor == Color.Red)
            {
                button6.Enabled = false;
            }
            if (button7.BackColor == Color.Red)
            {
                button7.Enabled = false;
            }
            if (button8.BackColor == Color.Red)
            {
                button8.Enabled = false;
            }
            if (button9.BackColor == Color.Red)
            {
                button9.Enabled = false;
            }
            if (button10.BackColor == Color.Red)
            {
                button10.Enabled = false;
            }
        } 

        private void əsasSəhifəToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Programdan çıxmağa əminsinizmi ?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            this.IsClose = false;
            this.Timer.Stop();
            this.Timer.Dispose();
            this.Hide();
            Dashboard.ThisForm.Show();
        }

        private void ticketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Programdan çıxmağa əminsinizmi ?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            { 
                return;
            }
            this.IsClose = false;
            this.Timer.Stop();
            this.Timer.Dispose();
            try
            {
                this.Hide();
                new StuQuation().Show();
            }
            catch (Exception)
            { 
                MessageBox.Show("Sual əlavə olunmuyub");
            }

           
        }

        private void StuTicket_Load(object sender, EventArgs e)
        {
            this.pctTicket.Left = 8;
            this.pctTicket.Top = this.menuUser.Height + 5;
            this.pctTicket.Width = this.Width - 30;

            this.pnlAnswer.Top = this.Height - (this.pnlAnswer.Height + this.pnlCavablar.Height + this.lblResponse1.Height + 40);
            this.pnlAnswer.Left = (this.Width - this.pnlAnswer.Width) / 2;

            this.lblDuration.Top = this.Height - 120;
            this.lblDuration.Left = this.Width - 250;

            pnlInfo.Top = this.Height - (this.pnlInfo.Height + 55);
            pnlInfo.Width = this.Width / 4;
            grpInfo.Width = pnlInfo.Width-10;
            cmbTicket.Left = (grpInfo.Width - cmbTicket.Width) - 10;
            cmbTicket.Width = (grpInfo.Width / 3) + 10;
            lblTicket.Left = cmbTicket.Left;

            this.pnlCavablar.Left = (this.Width - (this.pnlInfo.Width + this.lblDuration.Width + 10)) / 2 + 40;
            int b = this.pnlCavablar.Left;
            this.lblResponse1.Left = b + ((this.pnlCavablar.Width / 2) - 65);

            pnlCavablar.Top = pnlInfo.Top;
            pnlCavablar.Left = (this.Width - pnlCavablar.Width) / 2;

            this.lblResponse1.Top = (pnlCavablar.Top - lblResponse1.Height + 5);

            this.pctTicket.Height = pnlAnswer.Top - 40;

            if (Tickets.Count <= 0)
            {
                MessageBox.Show("Hal hazirda bilet yoxdur");
                this.IsClose = false;
                this.Close();
                Dashboard.ThisForm.Show();
            }
        }

        private void FormResize(object sender, EventArgs e)
        {
            this.pctTicket.Left = 8;
            this.pctTicket.Top = this.menuUser.Height + 5;
            this.pctTicket.Width = this.Width - 30;

            this.pnlAnswer.Top = this.Height - (this.pnlAnswer.Height + this.pnlCavablar.Height + this.lblResponse1.Height + 40);
            this.pnlAnswer.Left = (this.Width - this.pnlAnswer.Width) / 2;

            this.lblDuration.Top = this.Height - 120;
            this.lblDuration.Left = this.Width - 250;
            this.pnlCavablar.Left = (this.Width - (this.pnlInfo.Width + this.lblDuration.Width + 10)) / 2 + 40;

            pnlInfo.Top = this.Height - (this.pnlInfo.Height + 55);
            pnlInfo.Width = this.Width / 4;
            grpInfo.Width = pnlInfo.Width - 10;
            cmbTicket.Left = (grpInfo.Width - cmbTicket.Width) - 10;
            cmbTicket.Width = (grpInfo.Width / 3) + 10;
            lblTicket.Left = cmbTicket.Left;


            int a = this.pnlCavablar.Left;
            this.lblResponse1.Left = a + ((this.pnlCavablar.Width / 2) - 60);

            pnlCavablar.Top = pnlInfo.Top;
            pnlCavablar.Left = (this.Width - pnlCavablar.Width) / 2;

            this.lblResponse1.Top = (pnlCavablar.Top - lblResponse1.Height + 5);


            if (WindowState == FormWindowState.Maximized)
            {
                this.Width = 1000;
                this.Height = 500;
            }

            lblResponse1.Left = (this.Width - lblResponse1.Width) / 2;

            this.pctTicket.Height = pnlAnswer.Top - 40;
        }

        private void StuTicket_SizeChanged(object sender, EventArgs e)
        {
            pnlInfo.Top = this.Height - (this.pnlInfo.Height + 55);
            pnlInfo.Width = this.Width / 4;
            grpInfo.Width = pnlInfo.Width - 10;
            cmbTicket.Left = (grpInfo.Width - cmbTicket.Width) - 10;
            cmbTicket.Width = (grpInfo.Width / 3) + 10;
            lblTicket.Left = cmbTicket.Left;
        }
  
    }
}
