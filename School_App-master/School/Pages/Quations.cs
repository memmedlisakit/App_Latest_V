using School.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using System.Data.SQLite;
using School.Settings;
using System.IO;

namespace School.Pages
{
    public partial class Quations : Form
    {
        AddQuation AQ = new AddQuation();
        SQLiteConnection con = new SQLiteConnection(Login.connection);
        OpenFileDialog ofd = new OpenFileDialog();
        Quation seleced = new Quation();
        string selectedNumber = null;

        public Quations()
        {
            InitializeComponent();
            AQ.fillComboBox(this.cmbCategory);
            AQ.fillComboBox(this.cmbInfoCategory);
            //this.fillPanel(this.getAllQuations());

            pnlAllQuations.HorizontalScroll.Maximum = 0;
            pnlAllQuations.AutoScroll = false;
            pnlAllQuations.VerticalScroll.Visible = false;
            pnlAllQuations.AutoScroll = true;

            this.cmbCategory.SelectedIndex = -1;
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            AdminPanel.ThisForm.Show();
        }
         
        List<Quation> getAllQuations(int? id = null, int? category_id = null)
        {
            List<Quation> quations = new List<Quation>();
            SQLiteDataAdapter da = new SQLiteDataAdapter();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM Quations";
            sql += id != null ? " WHERE id = " + id : "";
            sql += category_id != null ? " WHERE category_id = " + category_id : "";
            SQLiteCommand com = new SQLiteCommand(sql, con);
            da.SelectCommand = com;
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                quations.Add(new Quation()
                {
                    Id = Convert.ToInt32(row["id"]),
                    Image = row["image"].ToString(),
                    Answer = row["answer"].ToString(),
                    Category_id = Convert.ToInt32(row["category_id"])
                });
            }
            return quations;
        }

        void fillPanel(List<Quation> quations)
        {
            int counter = 1;
            this.pnlAllQuations.Controls.Clear();
            int mainWidth = this.pnlAllQuations.Width - 10;
            int mainHeight = this.pnlAllQuations.Height;
            int top = 10;
            int left = 10;
            foreach (Quation q in quations)
            {
                GroupBox qrp = new GroupBox();
                qrp.Width = (mainWidth / 3 - 20);
                qrp.Height = (mainHeight / 3 - 20);
                qrp.Text = this.selectedNumber == null ? counter.ToString() : this.selectedNumber;
                qrp.Name = q.Id.ToString();
                qrp.Top = top;
                qrp.Left = left;
                left += (mainWidth / 3);
                if((quations.IndexOf(q) + 1) % 3 == 0)
                {
                    left = 10;
                    top += (mainHeight / 3);
                }
                this.pnlAllQuations.Controls.Add(qrp);

                counter++;

                PictureBox pct = new PictureBox();
                pct.Width = qrp.Width;
                pct.Top = 15;
                pct.Height = qrp.Height - 50;
                using (FileStream s = new FileStream(Extentions.GetPath() + "\\Quations_Images\\" + q.Image, FileMode.Open))
                {
                    pct.Image = Image.FromStream(s);
                }
                pct.SizeMode = PictureBoxSizeMode.StretchImage;
                qrp.Controls.Add(pct);


                // delete button
                Button btnDel = new Button();
                btnDel.Text = "Delete";
                btnDel.Width = (qrp.Width / 2 - 15);
                btnDel.Height = 30;
                btnDel.Left = 5;
                btnDel.Font = new Font(btnDel.Font.FontFamily, 12);
                btnDel.BackColor = Color.LightCoral;
                btnDel.ForeColor = Color.White;
                btnDel.Top = qrp.Height - 33;
                qrp.Controls.Add(btnDel);
                btnDel.Name = q.Id+"_"+ q.Image;
                btnDel.Click += this.delete;


                // Edit button
                Button btnEdit = new Button();
                btnEdit.Text = "Update";
                btnEdit.Width = (qrp.Width / 2 - 15);
                btnEdit.Height = 30;
                btnEdit.Left = (qrp.Width / 2 + 10);
                btnEdit.Font = new Font(btnDel.Font.FontFamily, 12);
                btnEdit.BackColor = Color.LimeGreen;
                btnEdit.ForeColor = Color.White;
                btnEdit.Top = qrp.Height - 33;
                qrp.Controls.Add(btnEdit);
                btnEdit.Name = q.Id.ToString();
                btnEdit.Click += this.update;
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        { 
           int id = AddQuation.getCatId(this.cmbCategory.Text);
           this.fillPanel(this.getAllQuations(null, id)); 
        }

        private void selectQuation(object sender, EventArgs e)
        {
            int id;
            if (this.txtNumOfQuation.Text != "")
            {
                if (Int32.TryParse(this.txtNumOfQuation.Text, out id))
                {
                    this.selectQuationForNumber(this.txtNumOfQuation.Text);
                    this.lblNumberOfQuation.Text = "";
                }
                else
                {
                    this.lblNumberOfQuation.Text = "Rəqəm olmalıdır ";
                }
            }
            else
            {
                this.lblNumberOfQuation.Text = "";
                this.selectQuationForNumber();
            }
        }

        void selectQuationForNumber(string number = "")
        {
            this.selectedNumber = null;
            if (this.cmbCategory.SelectedIndex != -1)
            {
                int id = AddQuation.getCatId(this.cmbCategory.Text);
                this.fillPanel(this.getAllQuations(null, id));
            }            
            
            if (number != "")
            {
                foreach (var control in this.pnlAllQuations.Controls)
                {
                    GroupBox grp = control as GroupBox;
                    if (grp.Text == number)
                    {
                            this.selectedNumber = grp.Text;
                            this.fillPanel(this.getAllQuations(Convert.ToInt32(grp.Name)));
                            return;
                    } 
                } 
            } 
        }

        private void delete(object sender, EventArgs e)
        {
                                                     
            if (DialogResult.Yes == MessageBox.Show("Həmçinin bu sual ile əlaqəli bütün Biletlər silinəcək", "Sualı sil", MessageBoxButtons.YesNo))
            {
                this.selectedNumber = null;
                this.pnlAllQuations.Controls.Clear();
                Button btn = sender as Button;
                string[] data = btn.Name.Split('_');

                deleteTickets(Convert.ToInt32(data[0]));

                string sql = "DELETE FROM Quations WHERE id = " + Convert.ToInt32(data[0]);
                SQLiteCommand com = new SQLiteCommand(sql, con);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                Extentions.DeleteFile(data[1], "Quations_Images");
                this.fillPanel(this.getAllQuations());
            }
        }
        
        private void deleteTickets(int quation_id)
        {
            List<int> ticket_ids = new List<int>();
            using(SQLiteConnection con = new SQLiteConnection(Login.connection))
            {
                string sql = "SELECT * FROM P_TicketAndQuation WHERE quation_id = " + quation_id;
                SQLiteCommand com = new SQLiteCommand(sql, con);
                con.Open();
                SQLiteDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    int ticket_id = Convert.ToInt32(dr["ticket_id"]);
                    if (!ticket_ids.Contains(ticket_id))
                    {
                        ticket_ids.Add(ticket_id);
                    }
                }
            }


            foreach (int ticket_id in ticket_ids)
            {
                using (SQLiteConnection con = new SQLiteConnection(Login.connection))
                {
                    string sql = "DELETE FROM P_TicketAndQuation WHERE ticket_id = " + ticket_id;
                    SQLiteCommand com = new SQLiteCommand(sql, con);
                    con.Open();
                    com.ExecuteNonQuery();
                }
                using (SQLiteConnection con = new SQLiteConnection(Login.connection))
                {
                    string sql = "DELETE FROM Tickets WHERE id = " + ticket_id;
                    SQLiteCommand com = new SQLiteCommand(sql, con);
                    con.Open();
                    com.ExecuteNonQuery();
                }
            }
        }

        private void update(object sender, EventArgs e)
        { 
            this.pnlAllQuations.Controls.Clear();
            Button btn = sender as Button;
            this.seleced.Id = Convert.ToInt32(btn.Name);
            string sql = "SELECT * FROM Quations q INNER JOIN Categories c ON q.category_id = c.id WHERE q.id = " + this.seleced.Id;
            SQLiteCommand com = new SQLiteCommand(sql, con);
            SQLiteDataAdapter da = new SQLiteDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = com;
            da.Fill(dt);
            this.cmbInfoCategory.Text = dt.Rows[0]["name"].ToString();
            this.txtInfoAnswer.Text = dt.Rows[0]["answer"].ToString();
            this.seleced.Image = dt.Rows[0]["image"].ToString();
            using (FileStream s = new FileStream(Extentions.GetPath() + "\\Quations_Images\\" + this.seleced.Image, FileMode.Open))
            {
                this.pctInfoQuation.Image = Image.FromStream(s);
            }
            this.grpInfo.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int category_id = AddQuation.getCatId(this.cmbInfoCategory.Text);
            string answer = this.txtInfoAnswer.Text;
            string sql = "UPDATE Quations SET answer = '" + answer + "', category_id = " + category_id;
            if (ofd.FileName != "")
            {
                string imageName = DateTime.Now.ToString("yyyyMMddHHssmm") + ofd.SafeFileName;
                Extentions.ImageUpload(ofd, imageName, "Quations_Images");
                Extentions.DeleteFile(this.seleced.Image, "Quations_Images");
                sql += ", image = '" + imageName + "' WHERE id = " + this.seleced.Id;
            }
            else
            {
                sql += " WHERE id = " + this.seleced.Id;
            }

            SQLiteCommand com = new SQLiteCommand(sql, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            //this.fillPanel(this.getAllQuations());
            int id = AddQuation.getCatId(this.cmbCategory.Text);
            this.fillPanel(this.getAllQuations(null, id));
            this.grpInfo.Visible = false;
        }

        private void linkUpload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.pctInfoQuation.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.grpInfo.Visible = false;
            this.selectedNumber = null;
            int id = AddQuation.getCatId(this.cmbCategory.Text);
            this.fillPanel(this.getAllQuations(null, id));
            //this.fillPanel(this.getAllQuations());
        }

        private void Quations_Load(object sender, EventArgs e)
        {

        }
    }
}
