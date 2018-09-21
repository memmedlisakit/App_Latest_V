using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using School.Settings;
using System.Collections.Generic;
using System.Net;
using School.Models;
using System.Linq; 
using System.Timers;

namespace School.Pages
{
    public partial class AddQuation : Form
    {
        static SQLiteConnection con = new SQLiteConnection(Login.connection);
        OpenFileDialog ofd = new OpenFileDialog();



        List<string> images = new List<string>();
        List<string> answers = new List<string>();
        string imageFolderPath = "";

        public AddQuation()
        {
            InitializeComponent();
            this.fillComboBox(this.cmbAllCategory);
            this.fillComboBox(this.cmbCategory);
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            AdminPanel.ThisForm.Show();
        }

        public void fillComboBox(ComboBox combo)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM Categories order by name";
            SQLiteCommand com = new SQLiteCommand(sql, con);
            da.SelectCommand = com;
            da.Fill(dt);
             

            List<Category> Categories = new List<Category>();

            foreach (DataRow row in dt.Rows)
            {
                Categories.Add(new Category()
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString()
                });
            }


            Dictionary<int, Category> categories = new Dictionary<int, Category>();


            foreach (Category cat in Categories)
            {
                int number;
                int.TryParse(cat.Name.Split('.').ToArray()[0], out number);
                if (!categories.ContainsKey(number))  categories.Add(number, cat);
            }



            foreach (KeyValuePair<int, Category> cat in categories.OrderBy(c => c.Key))
            {
                ComboboxItem item = new ComboboxItem
                {
                    Text = cat.Value.Name,
                    Value = cat.Value.Id
                };
                combo.Items.Add(item);
            } 
        }

        private bool checkingFiled()
        {
            if (this.cmbCategory.Text == "")
            {
                this.lblCategory.Text = "Mövzu seçin ";
                return false;
            }
            if (this.txtAnswer.Text == "")
            {
                this.lblAnswer.Text = "Cavab Yazın ";
                return false;
            }
            if (ofd.SafeFileName == "")
            {
                this.lblImage.Text = "Şəkil seçin ";
                return false;
            }
            return true;
        }

        private void cleaner()
        {
            this.lblAllAnswers.Text = "";
            this.lblAllCategory.Text = "";
            this.lblAllImages.Text = "";
            this.lblAnswer.Text = "";
            this.lblCategory.Text = "";
            this.lblImage.Text = "";
            this.txtAnswer.Text = "";
            this.cmbAllCategory.SelectedIndex = -1;
            this.cmbCategory.SelectedIndex = -1;
            this.pckSingle.Image = null;
        }

        public static int getCatId(string name)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM Categories WHERE name = '" + name + "'";
            SQLiteCommand com = new SQLiteCommand(sql, con);
            da.SelectCommand = com;
            da.Fill(dt);
            int id = Convert.ToInt32(dt.Rows[0]["id"]);
            return id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.checkingFiled())
            {
                string imageName = DateTime.Now.ToString("yyyyMMddHHssmm") + ofd.SafeFileName;
                Extentions.ImageUpload(ofd, imageName, "Quations_Images");
                string answer = this.txtAnswer.Text;
                string sql = "INSERT INTO Quations(answer, category_id, image) VALUES('" + this.txtAnswer.Text + "', '" + getCatId(this.cmbCategory.Text) + "', '" + imageName + "')";
                SQLiteCommand com = new SQLiteCommand(sql, con);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                this.cleaner();
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                this.pckSingle.Image = Image.FromFile(ofd.FileName);
            }
        }



        // Multipli insertion
        private void btnAllSave_Click(object sender, EventArgs e)
        {
            if (!this.checkingAllFiled())
            {
                images.Clear();
                answers.Clear();
                return;
            }
            int id = getCatId(this.cmbAllCategory.Text);
            for (int i = 0; i < images.Count; i++)
            {

                try
                {
                    SQLiteCommand com = new SQLiteCommand();
                    string imageName = DateTime.Now.ToString("yyyyMMddHHssmm") + images[i] + ".jpg";
                    string path = Extentions.GetPath() + "Quations_Images\\" + imageName;

                    WebClient webclient = new WebClient();
                    webclient.DownloadFile(imageFolderPath + "\\" + images[i], path);
                    string sql = "INSERT INTO Quations(answer, category_id, image) VALUES('" + this.answers[i] + "', " + id + ", '" + imageName + "')";
                    com.CommandText = sql;
                    com.Connection = con;
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    this.cmbAllCategory.SelectedIndex = -1;
                }
                catch (Exception)
                {
                    this.lblMulti.ForeColor = Color.Red;
                    this.lblMulti.Text = "Databazaya bağlanarkən xəta baş verdi";
                    return;
                }
            }
            this.lblMulti.ForeColor = Color.LimeGreen;
            MessageBox.Show("Uğurla tamamlandi");
            this.cleaner();
            images.Clear();
            answers.Clear();
        }

        private void btnAllImages_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(fbd.SelectedPath);
                int say = 0;
                string a;
                string b;
                string c;
                foreach (string file in files)
                {
                    say++;
                    a = say + ".jpg";
                    b = say + ".jpeg";
                    c = say + ".png";
                    if (Path.GetExtension(file) == ".jpg" )
                    {
                        //while (Path.GetFileName(file) == a || Path.GetFileName(file) == b || Path.GetFileName(file) == c)
                        //{
                            this.images.Add(Path.GetFileName(a));
                            //MessageBox.Show(Path.GetFileName(a));
                        //}

                    }
                    if ( Path.GetExtension(file) == ".jpeg")
                    {
                        this.images.Add(Path.GetFileName(b));
                    }
                    if ( Path.GetExtension(file) == ".png")
                    {
                        this.images.Add(Path.GetFileName(c));
                    }
                }
                imageFolderPath = fbd.SelectedPath;
            }
        }

        private void btnAllAnswers_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(ofd.SafeFileName) == ".txt")
                {
                    this.ReadTxt(ofd.FileName);
                }
                else
                {
                    this.lblAllAnswers.Text = "Fayl tipi .txt olmalidir ";
                }
            }
            ofd = new OpenFileDialog();

        }

        void ReadTxt(string fileName)
        {
            string line;
            StreamReader file = new StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                this.answers.Add(line);
            }
        }

        bool checkingAllFiled()
        {
            if (this.cmbAllCategory.Text == "")
            {
                this.lblAllCategory.Text = "Mövzu seçin ";
                return false;
            }
            if (this.images.Count <= 0)
            {
                this.lblAllImages.Text = "Şəkillər qovluqu seçin ";
                return false;
            }
            if (this.answers.Count <= 0)
            {
                this.lblAllAnswers.Text = "Cavablar faylı seçin ";
                return false;
            }
            if (this.answers.Count < this.images.Count)
            {
                this.lblAllAnswers.Text = "Cavablar sayi Şəkillər sayi ile eyni olmalıdır ";
                return false;
            }
            if (this.images.Count < this.answers.Count)
            {
                this.lblAllImages.Text = "Şəkillər sayı Cavablar sayı ilə eyni olmalıdır ";
                return false;
            }
            return true;
        }

        private void cmbAllCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
