using School.Models;
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
        public bool CheckCombo { get; private set; } = false;
        public string SelectedText { get; private set; }
        public bool IsClose { get; private set; } = true;

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
            if(IncorrectQuations.Count > 0 || CorrectCount > 0)
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
            }

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

            Dictionary<int, Category> categories = new Dictionary<int, Category>();


            foreach (Category cat in Categories)
            {
                int number;
                int.TryParse(cat.Name.Split('.').ToArray()[0], out number);
                categories.Add(number, cat);
            }

            

            foreach (KeyValuePair<int, Category> cat in categories.OrderBy(c => c.Key))
            {
                ComboboxItem item = new ComboboxItem
                {
                    Text = cat.Value.Name,
                    Value = cat.Value.Id
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
            if (IncorrectQuations.Count > 0 || CorrectCount > 0)
            {
                if (CheckCombo && SelectedText != cmbCategory.Text)
                {
                    DialogResult result = MessageBox.Show("Programdan çıxmağa əminsinizmi ?", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        cmbCategory.Text = SelectedText;
                        return;
                    }
                }
            }

            if (SelectedText != cmbCategory.Text)
            {
                if (this.cmbCategory.SelectedIndex == -1) return;

                int id = Convert.ToInt32((this.cmbCategory.SelectedItem as ComboboxItem).Value);
                this.SelectedQuations = this.Quations.Where(q => q.Category_id == id).ToList();
                this.lblQuationCount.Text = SelectedQuations.Count.ToString();

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

                SelectedText = cmbCategory.Text;
                CheckCombo = true;
            }   
        }

        private void cmbIncorrectQuations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbIncorrectQuations.SelectedItem.ToString() == "") return;
            int id = Convert.ToInt32((this.cmbIncorrectQuations.SelectedItem as ComboboxItem).Text);
            this.Index = (id - 1);
            this.setQuation(); 
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
           
                if (IncorrectQuations.Count > 0 || CorrectCount > 0)
                {
                    DialogResult result = MessageBox.Show("Programdan çıxmağa əminsinizmi ?", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }
                this.IsClose = false;
                this.Hide();
                new StuTicket().Show(); 
        } 

        private void əsasSəhifəToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IncorrectQuations.Count > 0 || CorrectCount > 0)
            {
                DialogResult result = MessageBox.Show("Programdan çıxmağa əminsinizmi ?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            this.IsClose = false;
            this.Close();
             Dashboard.ThisForm.Show(); 
        }
         

        private void PaintBorderlessGroupBox(object sender, PaintEventArgs p)
        {
            GroupBox box = (GroupBox)sender;
            p.Graphics.Clear(Color.SkyBlue);
            p.Graphics.DrawString(box.Text, box.Font, Brushes.SkyBlue, 0, 0);
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
            grpAnswers.ForeColor = Color.Transparent;


            //===============================For Panel Answers============================ 
            pnlAnswers.Top = pnlInfo.Top;
            pnlAnswers.Width = (this.Width / 3);
            pnlAnswers.Height = pnlInfo.Height;
            int left = (pnlInfo.Left + pnlInfo.Width);
            pnlAnswers.Left = (((pnlCategory.Left - left) - pnlAnswers.Width) / 2) + left + 5;
            grp_answers.Width = pnlAnswers.Width - 10;
            grpAnswers.Width = grp_answers.Width - 10;
            grpAnswers.Left = (grp_answers.Width - grpAnswers.Width) / 2;
            AnswerResize();
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
            pnlCategory.Top = pnlAnswers.Top - 4;
            pnlCategory.Height = pnlInfo.Height;
            pnlCategory.Left = (this.Width - pnlCategory.Width - 20);
        }

        private void AnswerResize()
        {
            int count = 10;
            int number = 1;
            foreach (Control ctr in grpAnswers.Controls)
            {
                ctr.Left = count;
                ctr.Text = (number++).ToString();
                ctr.Top = ((grpAnswers.Height - ctr.Height) / 2) + 3;
                count += grpAnswers.Width / 5;
                int width = (grpAnswers.Width / 5) - 20;
                ctr.Width = width;
                //ctr.Height = ctr.Width - 5;
            }
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
            pnlAnswers.Width = (this.Width / 3);
            pnlAnswers.Left = (this.Width / 2) - (pnlAnswers.Width / 2) + 10;
            grp_answers.Width = pnlAnswers.Width - 10;
            grpAnswers.Width = grp_answers.Width - 12;
            AnswerResize();
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
            pnlCategory.Top = pnlAnswers.Top - 4;
            pnlCategory.Left = (this.Width - pnlCategory.Width - 20);


            if (WindowState == FormWindowState.Maximized)
            {
                this.Width = 1000;
                this.Height = 500;

            }
        }

        private void StuQuation_SizeChanged(object sender, EventArgs e)
        {
            int left = (pnlInfo.Left + pnlInfo.Width);
            pnlAnswers.Left = (((pnlCategory.Left - left) - pnlAnswers.Width) / 2) + left + 5;
            AnswerResize();
        } 
    }
}