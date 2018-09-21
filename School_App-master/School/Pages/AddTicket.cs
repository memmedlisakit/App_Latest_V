using System;
using System.Collections.Generic; 
using System.Data;
using System.Data.SQLite;
using System.Linq; 
using System.Windows.Forms;
using School.Models;
using System.IO;
using School.Settings;
using System.Drawing;

namespace School.Pages
{
    public partial class AddTicket : Form
    {
        SQLiteConnection con = new SQLiteConnection(Login.connection);
        List<Quation> quations = new List<Quation>();
        List<Category> categories = new List<Category>();
        List<P_TicketAndQuation> pivot = new List<P_TicketAndQuation>();
        List<int> quation_ids = new List<int>();
        public bool UpdateCheck { get; set; }
        public int TicketId { get; set; }
        public Tickets TicketForm { get; set; }

        public AddTicket(Tickets ticketForm, bool updateCheck = true)
        {
            this.TicketForm = ticketForm;
            InitializeComponent();
            selectAllForTable("Quations");
            selectAllForTable("Categories");
            selectAllForTable("P_TicketAndQuation");
            this.UpdateCheck = updateCheck;
            setScrollImages(); 
        }

       
        private void Closing(object sender, FormClosingEventArgs e)
        {
            Tickets.ThisForm.Show();
        }

        void setScrollImages()
        {


            Dictionary<int, Category> categories = new Dictionary<int, Category>();


            foreach (Category cat in this.categories)
            {
                int number;
                int.TryParse(cat.Name.Split('.').ToArray()[0], out number);
                if (!categories.ContainsKey(number))  categories.Add(number, cat);
            }



            

            foreach (var grp in this.grpMain.Controls)
            {
                if (grp is GroupBox)
                {
                    GroupBox groupBox = grp as GroupBox;
                    foreach (var obj in groupBox.Controls)
                    {
                        if (obj is Panel)
                        {
                            Panel panel = obj as Panel;
                            panel.HorizontalScroll.Maximum = 0;
                            panel.AutoScroll = false;
                            panel.VerticalScroll.Visible = false;
                            panel.AutoScroll = true;
                        }
                        if (obj is ComboBox)
                        {
                            ComboBox cmb = obj as ComboBox;
                            if (cmb.Name.Contains("Category"))
                            {
                                cmb.Items.Clear();
                                foreach (KeyValuePair<int, Category> cat in categories.OrderBy(c => c.Key))
                                {
                                    ComboboxItem item = new ComboboxItem
                                    {
                                        Text = cat.Value.Name,
                                        Value = cat.Value.Id
                                    };
                                    cmb.Items.Add(item);
                                    cmb.TextChanged += Cmb_SelectedIndexChanged;
                                } 
                            }
                        }
                    }
                }
            }
        }
         
        private void Cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            int category_id = Convert.ToInt32((cmb.SelectedItem as ComboboxItem).Value);
            Control nextCtl = cmb.Parent.GetNextControl(cmb, true);
            ComboBox next_cmb = nextCtl.Parent.GetNextControl(nextCtl, true) as ComboBox;
            List<Quation> newQuations = this.quations.Where(q => q.Category_id == category_id).ToList();
            next_cmb.Items.Clear();
            int number = 0;
            foreach (Quation item in newQuations)
            {
                ++number;
                ComboboxItem cmbi = new ComboboxItem();
                 
                if (this.pivot.Where(p=>p.Quation_id == item.Id).ToList().Count > 0)
                {
                    cmbi.Text = number.ToString() + " - *";
                }
                else
                {
                    cmbi.Text = number.ToString();
                }
                cmbi.Value = item.Id;
                next_cmb.Items.Add(cmbi);    
            }
            if (next_cmb.Items.Count < 1)
            {
                next_cmb.Items.Add("");
            } 
        }

       
        void selectAllForTable(string table)
        {
            string sql = "SELECT * FROM " + table;
            SQLiteCommand com = new SQLiteCommand(sql, con);
            SQLiteDataAdapter da = new SQLiteDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = com;
            da.Fill(dt);

            if (table == "Quations")
            {
                foreach (DataRow row in dt.Rows)
                {
                    this.quations.Add(new Quation()
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Category_id = Convert.ToInt32(row["category_id"]),
                        Image = row["image"].ToString(),
                        Answer = row["answer"].ToString()
                    });
                }
            }
            if (table == "Categories")
            {
                foreach (DataRow row in dt.Rows)
                {
                    this.categories.Add(new Category()
                    {
                        Id = Convert.ToInt32(row["id"]),
                      Name = row["name"].ToString()
                    });
                }
            }
            if (table == "P_TicketAndQuation")
            {
                foreach (DataRow row in dt.Rows)
                {
                    this.pivot.Add(new P_TicketAndQuation()
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Quation_id = Convert.ToInt32(row["quation_id"]),
                        Ticket_id = Convert.ToInt32(row["ticket_id"])                    
                    });
                }
            } 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (this.txtTicketName.Text == "")
            {
                this.lblTicketName.Text = "Bilet adını yazın ";
                return;
            }

            foreach (Control item in this.grpMain.Controls)
            {
                if (item is GroupBox)
                {
                    GroupBox grp = item as GroupBox;
                    if (grp.Name.Contains("selected"))
                    {
                        count++;
                    }
                }
            }

            if (count != 10)
            {
                this.lblQuations.Text = "10 sual seçin ";
                return;
            }

            using (SQLiteConnection con = new SQLiteConnection(Login.connection))
            {
                con.Open();
                string selectSql = "SELECT * FROM Tickets WHERE name = '" + this.txtTicketName.Text + "'";
                SQLiteCommand com = new SQLiteCommand(selectSql, con);
                SQLiteDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    if (dr[1].ToString() == this.txtTicketName.Text)
                    {
                        this.lblTicketName.Text = "Bilet əlavə edildi ";
                        return;
                    }
                }
            }

            foreach (Control item in this.grpMain.Controls)
            {
                if (item is GroupBox)
                {
                    GroupBox grp = item as GroupBox;
                    int id = Convert.ToInt32(grp.Name.Split('-').ToArray()[1]);
                    this.quation_ids.Add(id);
                }
            }
             
            this.btnSave.Enabled = false;
            int tickedId = this.insertToTicket();
            this.insertToPivot(tickedId, this.quation_ids);
            this.TicketForm.updatePanel();
            this.Close();
            Tickets.ThisForm.Show();
        }

        int insertToTicket()
        {

            string sql = "INSERT INTO Tickets(name) VALUES('" + this.txtTicketName.Text + "')";
            SQLiteCommand com = new SQLiteCommand(sql, con);
            con.Open();
            com.ExecuteNonQuery();


            com.CommandText = "SELECT * FROM Tickets WHERE name = '" + this.txtTicketName.Text + "'";
            com.Connection = con;
            SQLiteDataReader dr = com.ExecuteReader();
            int ticketId = 0;
            while (dr.Read())
            {
                ticketId = Convert.ToInt32(dr["id"]);
            }

            con.Close();
            return ticketId;
        }

        void insertToPivot(int ticketId, List<int> quationIds)
        {
            foreach (int q_id in quationIds)
            {
                using (SQLiteConnection con = new SQLiteConnection(Login.connection))
                {
                    con.Open();
                    string sql = "INSERT INTO P_TicketAndQuation(ticket_id, quation_id) values(" + ticketId + ", " + q_id + ")";
                    SQLiteCommand com = new SQLiteCommand(sql, con);
                    com.ExecuteNonQuery();
                }
            }
        }
         
        public void update(int ticketId)
        {

            this.TicketId = ticketId;
            this.btnSave.Visible = false;
            this.btnUpdate.Visible = true;

            using (SQLiteConnection con = new SQLiteConnection(Login.connection))
            {
                con.Open();
                string sql = "SELECT * FROM Tickets WHERE id = " + ticketId;
                SQLiteCommand com = new SQLiteCommand(sql, con);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = com;
                da.Fill(dt);
                this.txtTicketName.Text = dt.Rows[0]["name"].ToString();
            }

            using (SQLiteConnection con = new SQLiteConnection(Login.connection))
            {
                con.Open();
                string sql = "SELECT * FROM P_TicketAndQuation WHERE ticket_id = " + ticketId;
                SQLiteCommand com = new SQLiteCommand(sql, con);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = com;
                da.Fill(dt);

                int c_index = 0;
                int p_index = 0;
                foreach (Control ctrl in this.grpMain.Controls)
                {
                    if (ctrl is GroupBox)
                    {
                        foreach (Control cmb in ctrl.Controls)
                        {
                            if (cmb is ComboBox)
                            {
                                ComboBox combo = cmb as ComboBox;
                                if (combo.Name.Contains("Category"))
                                {
                                    combo.TextChanged -= Cmb_SelectedIndexChanged;
                                    int id = Convert.ToInt32(dt.Rows[c_index]["quation_id"]);
                                    int cat_id = this.quations.FirstOrDefault(q => q.Id == id).Category_id;
                                    foreach (ComboboxItem item in combo.Items)
                                    {
                                        if (cat_id == Convert.ToInt32(item.Value))
                                        {
                                            combo.SelectedItem = item;
                                        }
                                    }
                                    c_index++;
                                }
                            }                             
                        }

                        foreach (Control panel in ctrl.Controls)
                        {
                            if (panel is ComboBox)
                            {
                                ComboBox cmb = panel as ComboBox;
                                if (cmb.Name.Contains("quation"))
                                {
                                    int id = Convert.ToInt32(dt.Rows[p_index]["quation_id"]);
                                    Quation selected = quations.FirstOrDefault(q => q.Id == id); 
                                    cmb.Parent.Name = "selected-" + id;
                                    foreach (var item in cmb.Items)
                                    {
                                        ComboboxItem comboboxItem = item as ComboboxItem;
                                        if(comboboxItem.Value.ToString() == id.ToString())
                                        {
                                            cmb.SelectedItem = item;
                                        }
                                    }
                                    p_index++;
                                } 
                            }
                        }
                    } 
                } 
            }
             
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.btnUpdate.Enabled = false;

            using(SQLiteConnection con =new SQLiteConnection(Login.connection))
            {
                string sql = "UPDATE Tickets SET name = '" + this.txtTicketName.Text + "' where id = " + this.TicketId;
                SQLiteCommand com = new SQLiteCommand(sql, con);
                con.Open();
                com.ExecuteNonQuery();
            }

            using (SQLiteConnection con = new SQLiteConnection(Login.connection))
            {
                con.Open();
                string sql = "DELETE FROM P_TicketAndQuation WHERE ticket_id = " + this.TicketId;
                SQLiteCommand com = new SQLiteCommand(sql, con);
                com.ExecuteNonQuery();
            }
             
            foreach (Control item in this.grpMain.Controls)
            {
                if (item is GroupBox)
                {
                    GroupBox grp = item as GroupBox;
                    int id = Convert.ToInt32(grp.Name.Split('-').ToArray()[1]);
                    using (SQLiteConnection con = new SQLiteConnection(Login.connection))
                    {
                        con.Open();
                        string sql = "INSERT INTO P_TicketAndQuation(ticket_id, quation_id) values(" + this.TicketId + ", " + id + ")";
                        SQLiteCommand com = new SQLiteCommand(sql, con);
                        com.ExecuteNonQuery();
                    }
                }
            }
             
            this.Close();
            this.TicketForm.updatePanel();
            Tickets.ThisForm.Show();
        }

        private void Select_answer(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            ComboboxItem item = (cmb.SelectedItem as ComboboxItem);
            cmb.Parent.Name = $"selected-{item.Value}";
        }
    }
}
