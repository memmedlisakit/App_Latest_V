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
            this.Timer.Stop();
            this.Timer.Dispose();
            try
            {
                Dashboard.ThisForm.Show();
            }
            catch (Exception)
            {
            }
            //new Loading().Hide();
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
            }

            this.Minut = 15;
            this.Second = 0;
            this.lblDuration.Text = "15:00";
        }

        private void btnAnswer(object sender, EventArgs e)
        {

            bool result;
            Button btn = sender as Button;
            string answer = this.selectedQuatins[Index].Answer;

            if (btn.Text == answer)
            {


                this.lblResponse1.Text = "Cavab Doğrudur";

                //btn.Enabled = false;
                this.lblResponse1.ForeColor = Color.Green;
                btn.BackColor = Color.LawnGreen;

                //btn.Enabled = false;
                btn01.Enabled = false;
                btn02.Enabled = false;
                btn03.Enabled = false;
                btn04.Enabled = false;
                btn05.Enabled = false;
                ////
                //if (button1.Focus() == true)
                //{
                //    button1.Enabled = false;
                //}
                //if (button2.Focus() == true)
                //{
                //    button2.Enabled = false;
                //}
                //if (button3.Focus() == true)
                //{
                //    button3.Enabled = false;
                //}
                //if (button4.Focus() == true)
                //{
                //    button4.Enabled = false;
                //}
                //if (button5.Focus() == true)
                //{
                //    button5.Enabled = false;
                //}
                //if (button6.Focus() == true)
                //{
                //    button6.Enabled = false;
                //}
                //if (button7.Focus() == true)
                //{
                //    button7.Enabled = false;
                //}
                //if (button8.Focus() == true)
                //{
                //    button8.Enabled = false;
                //}
                //if (button9.Focus() == true)
                //{
                //    button9.Enabled = false;
                //}
                //if (button10.Focus() == true)
                //{
                //    button10.Enabled = false;
                //}
                /////

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
                result = true;
                CorrectCount++;
                btn.Enabled = false;
                if (CorrectCount == 9)
                {
                    //new Loading().Hide();
                    //Loading.ActiveForm.Hide();
                    ShowResponse("Hörmətli " + Login.LoginedUser.Name +" "+Login.LoginedUser.Surname +"! \r\n Təbriklər, siz Yol Hərəkəti \r\n Qaydaları üzrə nəzəri \r\n  imtahandan keçdiniz", Color.Green);
                }

            }



            else
            {
                foreach (Button _btn in this.grpAnswers.Controls)
                {
                    if (_btn.Text == answer)
                    {
                        _btn.BackColor = Color.LawnGreen;
                    }
                }
                this.lblResponse1.Text = "Cavab Səhvdir";

                btn.Enabled = false;
                this.lblResponse1.ForeColor = Color.Red;
                btn.BackColor = Color.Red;

                this.IncorrectQuations.Add(this.selectedQuatins[Index]);
                btn.Enabled = false;
                btn01.Enabled = false;
                btn02.Enabled = false;
                btn03.Enabled = false;
                btn04.Enabled = false;
                btn05.Enabled = false;
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

                //if (button1.Focus() == true)
                //{
                //    button1.Enabled = false;
                //}
                //if (button2.Focus() == true)
                //{
                //    button2.Enabled = false;
                //}
                //if (button3.Focus() == true)
                //{
                //    button3.Enabled = false;
                //}
                //if (button4.Focus() == true)
                //{
                //    button4.Enabled = false;
                //}
                //if (button5.Focus() == true)
                //{
                //    button5.Enabled = false;
                //}
                //if (button6.Focus() == true)
                //{
                //    button6.Enabled = false;
                //}
                //if (button7.Focus() == true)
                //{
                //    button7.Enabled = false;
                //}
                //if (button8.Focus() == true)
                //{
                //    button8.Enabled = false;
                //}
                //if (button9.Focus() == true)
                //{
                //    button9.Enabled = false;
                //}
                //if (button10.Focus() == true)
                //{
                //    button10.Enabled = false;
                //}
                //
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
                btn.Enabled = false;
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
            }
        }

        private void cleaner()
        {
            foreach (Button btn in this.grpAnswers.Controls)
            {
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
                // this.Close();s
                // MessageBox.Show("Təəssüf edirik \r\n vaxt bitdiyi üçün \r\n siz imtahandan keçə bilmədiniz");
                
               
                //btn.BackColor = Color.Black;
                //btn.Enabled = true;
                this.Close();
                MessageBox.Show("Təəssüf, vaxtınız bitti!");
                // ShowResponse("",Color.Red);
                // MessageBox.Show(" ");


                //errorfor errorfor = new errorfor();
                //errorfor.Show();
                //this.Close();

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

        private void StuTicket_Load(object sender, EventArgs e)
        {

            // MessageBox.Show(lblResponse.Location.X.ToString(), lblResponse.Location.Y.ToString());

            //this.pctTicket.Width = (this.Width / 2);
            //this.pctTicket.Height = (this.Width / 4);
            //this.pctTicket.Left = ((this.Width - this.pctTicket.Width) / 2);

            //this.pnlAnswer.Left = ((this.Width - this.pnlAnswer.Width) / 2);
            //this.pnlAnswer.Top = (this.pctTicket.Top + this.pctTicket.Height + 5);
            this.pctTicket.Height = (this.Height - (this.pnlCavablar.Height + this.pnlAnswer.Height + 60 + this.menuUser.Height));
            this.pctTicket.Left = 8;
            this.pctTicket.Top = this.menuUser.Height + 5;
            this.pctTicket.Width = this.Width - 30;

            this.pnlAnswer.Top = this.Height - (this.pnlAnswer.Height + this.pnlCavablar.Height + this.lblResponse1.Height +30);
            this.pnlAnswer.Left = (this.Width - this.pnlAnswer.Width) / 2;
            this.lblResponse1.Top = this.Height - (this.pnlCavablar.Height + 60);
            this.pnlCavablar.Top = this.Height - (this.pnlCavablar.Height + 40);
            this.label2.Top = this.Height - 100;
            this.label2.Left = this.Width - 150;
            this.lblDuration.Top = this.Height - 100;
            this.lblDuration.Left = this.Width - 150 + label2.Width;
            this.pnlInfo.Top = this.Height - (this.pnlInfo.Height + 40);
            this.pnlCavablar.Left = (this.Width - (this.pnlInfo.Width + this.label2.Width + this.lblDuration.Width + 10)) / 2 + 40;
            //this.pnlInfo.Top = (pnlAnswer.Top + pnlAnswer.Height);
            int b = this.pnlCavablar.Left;
            this.lblResponse1.Left = b + ((this.pnlCavablar.Width / 2) - 65);
        }

        private void FormResize(object sender, EventArgs e)
        {
            this.pctTicket.Height = (this.Height - (this.pnlCavablar.Height + this.pnlAnswer.Height + 60 + this.menuUser.Height));
            this.pctTicket.Left = 8;
            this.pctTicket.Top = this.menuUser.Height + 5;
            this.pctTicket.Width = this.Width - 30;

            this.pnlAnswer.Top = this.Height - (this.pnlAnswer.Height + this.pnlCavablar.Height + this.lblResponse1.Height + 30);
            this.lblResponse1.Top = this.Height - (this.pnlCavablar.Height + 65);
            this.pnlCavablar.Top = this.Height - (this.pnlCavablar.Height + 40);
            this.pnlAnswer.Left = (this.Width - this.pnlAnswer.Width) / 2;
            this.label2.Top = this.Height - 100;
            this.label2.Left = this.Width - 150;
            this.lblDuration.Top = this.Height - 100;
            this.lblDuration.Left = this.Width - 150 + label2.Width;
            this.pnlCavablar.Left = (this.Width - (this.pnlInfo.Width + this.label2.Width + this.lblDuration.Width + 10)) / 2 + 40;
            this.pnlInfo.Top = this.Height - (this.pnlInfo.Height + 40);
            int a = this.pnlCavablar.Left;
            this.lblResponse1.Left = a + ((this.pnlCavablar.Width / 2) - 60);
            //this.pctTicket.Width = (this.Width / 2);
            //this.pctTicket.Height = (this.Width / 4);
            //this.pctTicket.Left = ((this.Width - this.pctTicket.Width) / 2);

            //this.pnlAnswer.Left = ((this.Width - this.pnlAnswer.Width) / 2);
            //this.pnlAnswer.Top = (this.pctTicket.Top + this.pctTicket.Height + 5);

            //this.pnlInfo.Left = ((this.Width - this.pnlInfo.Width) / 2);
            //this.pnlInfo.Top = (pnlAnswer.Top + pnlAnswer.Height);
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

            this.Close();
            Dashboard.ThisForm.Show();
            //Dashboard dashboard = new Dashboard();
            //dashboard.Show();
            //new Dashboard().ShowDialog();
        }

        private void ticketToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
    }
}
