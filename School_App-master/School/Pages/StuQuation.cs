﻿using School.Models;
using School.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace School.Pages
{
    partial class StuQuation : Form
    {
        public static Form ThisForm { get; set; }
        public List<Quation> Quations { get; set; } = new List<Quation>();

        public List<Quation> SelectedQuations { get; set; } = new List<Quation>();

        public List<Category> Categories { get; set; } = new List<Category>();

        public List<ComboboxItem> IncorrectQuations = new List<ComboboxItem>();

        public int Index { get; set; } = 0;

        public int CorrectCount { get; set; } = 0;
         
        public StuQuation()
        {
            InitializeComponent(); 
            this.Quations = this.getData<Quation>("Quations");
            this.Categories = this.getData<Category>("Categories");
            fillCmbCategory();
            this.lblName.Text = Login.LoginedUser.Name;
            this.lblSurname.Text = Login.LoginedUser.Surname;
            using (FileStream s = new FileStream(Extentions.GetPath() + "\\Uploads\\no-image.jpg", FileMode.Open))
            {
                this.pctQuation.Image = Image.FromStream(s);
            }
            ThisForm = this;
        }
         
        private void Closing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Dashboard.ThisForm.Show();
            }
            catch (Exception)
            { 
            } 
        }

        List<T> getData<T>(string table)
        {
            List<Quation> quations = new List<Quation>();
            List<Category> categories = new List<Category>();
            List<T> list = new List<T>();

            using (SQLiteConnection con = new SQLiteConnection(Login.connection))
            {
                string sql = "SELECT * FROM " + table;
                SQLiteCommand com = new SQLiteCommand(sql, con);
                SQLiteDataAdapter da = new SQLiteDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (quations is List<T>)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        quations.Add(new Quation
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Category_id = Convert.ToInt32(row["category_id"]),
                            Image = row["image"].ToString(),
                            Answer = row["answer"].ToString()
                        });
                    }
                    list = quations as List<T>;
                }
                else
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        categories.Add(new Category
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Name = row["name"].ToString(),
                        });
                    }
                    list = categories as List<T>;
                }

            }


            return list;
        }

        void fillCmbCategory()
        {
            this.cmbCategory.Items.Clear(); 
            foreach (Category cat in this.Categories.OrderBy(s=>s.Name))
            {
                ComboboxItem item = new ComboboxItem
                {
                    Text = cat.Name,
                    Value = cat.Id
                };
                this.cmbCategory.Items.Add(item);
            } 
        }
         
        void setQuation()
        {
            if (this.SelectedQuations.Count > 0)
            {
                using (FileStream s = new FileStream(Extentions.GetPath() + "\\Quations_Images\\" + this.SelectedQuations[Index].Image, FileMode.Open))
                {
                    this.pctQuation.Image = Image.FromStream(s);
                }
                this.txtQuationNum.Text = (this.Index + 1).ToString();
            }
            else
            {
                using (FileStream s = new FileStream(Extentions.GetPath() + "\\Uploads\\no-image.jpg", FileMode.Open))
                {
                    this.pctQuation.Image = Image.FromStream(s);
                }
                this.txtQuationNum.Text = "";
            }
            this.cleaner(); 
        }

        void cleaner()
        {
            this.lblResponse.Text = ""; 
            foreach (Button btn in grpAnswers.Controls)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = default(Color);
                btn.Enabled = true;
            }
        }

        private void AnswerClick(object sender, EventArgs e)
        {
          
            if (this.SelectedQuations.Count > 0)
            {
                Button btn = sender as Button;
                string answer = btn.Text;
                if (this.SelectedQuations[Index].Answer == answer)
                {
                    btn.BackColor = Color.LawnGreen;
                    this.lblResponse.ForeColor = Color.Green; 
                    this.lblResponse.Text = "Cavab Doğrudur";
                    lblResponse.Left = (grp_answers.Width / 2) - (lblResponse.Width / 2);
                    this.lblCorretCount.Text = (++this.CorrectCount).ToString();


                    if (cmbIncorrectQuations.SelectedIndex != -1)
                    {
                        string val = (cmbIncorrectQuations.SelectedItem as ComboboxItem).Value.ToString();
                        this.IncorrectQuations.Remove(this.IncorrectQuations.First(q => q.Value.ToString() == val));
                    }
                    fillCmbIncorrect();
                }
                else
                {
                    btn.BackColor = Color.Red;
                    lblResponse.ForeColor = Color.Red; 
                    lblResponse.Text = "Cavab Səhvdir";
                    lblResponse.Left = (grp_answers.Width / 2) - (lblResponse.Width / 2);



                    Quation quat = this.SelectedQuations[Index];
                    string value = quat.Id.ToString();
                    List<Quation> _quations = this.Quations.Where(q => q.Category_id == quat.Category_id).ToList();
                    int number = (_quations.IndexOf(quat) + 1);
                    ComboboxItem item = new ComboboxItem { Text = number.ToString(), Value = value };
                    if (!this.IncorrectQuations.Any(q => (string)q.Value == value))
                    {
                        this.IncorrectQuations.Add(item);
                    }
                    fillCmbIncorrect();
                }
                foreach (Button button in this.grpAnswers.Controls)
                {
                    if (button.Text == this.SelectedQuations[Index].Answer)
                    {
                        button.BackColor = Color.LawnGreen;
                    }
                    button.Enabled = false;
                }
            }
        }

        void fillCmbIncorrect()
        {
            this.cmbIncorrectQuations.Items.Clear();
            foreach (ComboboxItem item in this.IncorrectQuations)
            {
                this.cmbIncorrectQuations.Items.Add(item);
            }
            this.lblIncorretCount.Text = this.IncorrectQuations.Count.ToString();
        }
         
        private void SelectForNum(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string val = Regex.Replace(this.txtQuationNum.Text, @"\t|\n|\r", "");
                int num;
                if (int.TryParse(val, out num))
                {
                    this.Index = num > 0 && num <= this.SelectedQuations.Count ? (num - 1) : this.Index;
                    this.setQuation();
                }
                this.txtQuationNum.Text = val.Trim();
            }
        }
     
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbCategory.SelectedIndex == -1)  return; 

            int id = Convert.ToInt32((this.cmbCategory.SelectedItem as ComboboxItem).Value);
            this.SelectedQuations = this.Quations.Where(q => q.Category_id == id).ToList();
            this.lblQuationCount.Text = SelectedQuations.Count.ToString();
            //cmbCategory.SelectedIndex = 1;
            
            this.Index = 0;
            this.setQuation();
            this.cleaner();  
            this.cmbIncorrectQuations.Items.Clear();
            this.cmbIncorrectQuations.Items.Add("");
            this.IncorrectQuations.Clear();
            this.lblCorretCount.Text = "0";
            this.lblIncorretCount.Text = "0";
           
          
            this.rchCategory.Text = this.cmbCategory.Text;
            this.CorrectCount = 0;
        }

        private void cmbIncorrectQuations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbIncorrectQuations.SelectedItem.ToString() == "") return;
            int id = Convert.ToInt32((this.cmbIncorrectQuations.SelectedItem as ComboboxItem).Text);
           // this.SelectedQuations = this.Quations.Where(q => q.Id == id).ToList();
            this.Index = (id - 1);
            this.setQuation();
            //this.cmbCategory.SelectedIndex = -1;
            //this.rchCategory.Text = "";
            //this.txtQuationNum.Text = "";
            //this.lblQuationCount.Text = "0";
        }
         
        private void rtbSender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                Clipboard.Clear();
            }
        }
         
        private void btnPrev_Click(object sender, EventArgs e)
        {
            this.Index = this.Index > 0 ? this.Index - 1 : this.Index;
            this.setQuation();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Index = this.Index < (this.SelectedQuations.Count - 1) ? this.Index + 1 : this.Index;
            this.setQuation();
        }

        private void ticketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                new StuTicket().Show();
            }
            catch (Exception)
            {
               
                MessageBox.Show("Bilet əlavə olunmuyub");
            }
          
            //StuQuation stq = new StuQuation();
            //stq.Hide();
            //Login lgn = new Login();
            //lgn.Hide();
            //Dashboard dash = new Dashboard();
            //dash.Hide();
            //new StuTicket().ShowDialog();
        } 

        private void əsasSəhifəToolStripMenuItem_Click(object sender, EventArgs e)
        {
             this.Close();
             Dashboard.ThisForm.Show();
            //Dashboard dashboard = new Dashboard();
            //dashboard.Show();
            //StuQuation stq = new StuQuation();
            //stq.Hide();

            //new Dashboard().ShowDialog();
        }


        // Responsive

        private void StuQuation_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(this.Width, this.Height);

            try
            {
                cmbCategory.SelectedIndex = 0;
                this.Index = 0;
                this.setQuation();
                this.cleaner();
                this.cmbIncorrectQuations.Items.Clear();
                this.cmbIncorrectQuations.Items.Add("");
                this.IncorrectQuations.Clear();
                this.lblCorretCount.Text = "0";
                this.lblIncorretCount.Text = "0";
                this.rchCategory.Text = this.cmbCategory.Text;
                this.CorrectCount = 0;
            }
            catch (Exception)
            {
                new Dashboard().Show();
                MessageBox.Show("Sual əlavə olunmayıb", "SualInfo");
                this.Hide();
            }

            //deyisson
            this.pctQuation.Height = (this.Height - (this.grp_answers.Height + 60 + this.menuUser.Height));
            this.pctQuation.Left = 8;
            this.pctQuation.Top = this.menuUser.Height + 5;
            this.pctQuation.Width = this.Width - 30;




            //===============================For Panel Info===============================
            pnlInfo.Top = (this.Height - pnlInfo.Height - 50);


            //===============================For Panel Answers============================ 
            pnlAnswers.Top = pnlInfo.Top;
            pnlAnswers.Left = (this.Width / 2) - (pnlAnswers.Width / 2);
            pnlAnswers.Width = this.Width / 4;
            grp_answers.Width = pnlAnswers.Width - 10;
            grpAnswers.Width = grp_answers.Width - 10;
            int count = 5;
            foreach (Control ctr in grpAnswers.Controls)
            {
                ctr.Left = count;
                count += grpAnswers.Width / 5;
                ctr.Width = grpAnswers.Width / 5 - 8;
                ctr.Height = ctr.Width - 5;
            }
            foreach (Control ctr in grp_answers.Controls)
            {
                if(ctr is Button)
                {
                    ctr.Width = grp_answers.Width / 3 - 3;
                }
                if (ctr is TextBox)
                {
                    ctr.Width = grp_answers.Width / 3 - 3;
                }
            }

            txtQuationNum.Left = btnPrev.Left + btnPrev.Width;
            btnNext.Left = txtQuationNum.Left + txtQuationNum.Width;

            //===============================For Panel Categories========================= 
            pnlCategory.Top = pnlInfo.Top;
            pnlCategory.Left = (this.Width - pnlCategory.Width - 20);
        }

        private void formResize(object sender, EventArgs e)
        {
            pctQuation.Height = (this.Height - (this.grp_answers.Height + 60 + this.menuUser.Height));
            pctQuation.Left = 8;
            pctQuation.Top = this.menuUser.Height + 5;
            pctQuation.Width = this.Width - 30;  


            //===============================For Panel Info===============================
            pnlInfo.Top = (this.Height - pnlInfo.Height - 50);

            //===============================For Panel Answers============================ 
            pnlAnswers.Top = pnlInfo.Top;
            pnlAnswers.Left = (this.Width / 2) - (pnlAnswers.Width / 2);
            pnlAnswers.Width = this.Width / 4;
            grp_answers.Width = pnlAnswers.Width - 10;
            grpAnswers.Width = grp_answers.Width - 10;
            int count = 5;
            foreach (Control ctr in grpAnswers.Controls)
            {
                ctr.Left = count;
                count += grpAnswers.Width / 5;
                ctr.Width = grpAnswers.Width / 5 - 8;
                ctr.Height = ctr.Width - 5;
            }
            foreach (Control ctr in grp_answers.Controls)
            {
                if (ctr is Button)
                {
                    ctr.Width = grp_answers.Width / 3 - 3;
                }
                if (ctr is TextBox)
                {
                    ctr.Width = grp_answers.Width / 3 - 3;
                }
            }

            txtQuationNum.Left = btnPrev.Left + btnPrev.Width;
            btnNext.Left = txtQuationNum.Left + txtQuationNum.Width; 

            //===============================For Panel Categories========================= 
            pnlCategory.Top = pnlInfo.Top;
            pnlCategory.Left = (this.Width - pnlCategory.Width - 20); 
        }
    }
}