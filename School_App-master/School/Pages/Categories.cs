using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using School.Settings;
using System.Collections.Generic;
using School.Models;
using System.Linq;

namespace School.Pages
{
    public partial class Categories : Form
    {
        SQLiteConnection con = new SQLiteConnection(Login.connection);

     

        int id;
        public Categories()
        {
            InitializeComponent();
            this.fillData();
        }
        //deyisikıik bas
        private void updateAndDelete(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(this.dgvData.Rows[e.RowIndex].Cells[0].Value);
            if (e.ColumnIndex == 0)
            {

            }

        }
        // deyisikıik son
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtCategory.Text == "")
            {
                this.lblCatError.Text = "Boşluq olmaz ";
            }
            else
            {
                string sql = "INSERT INTO Categories(name) VALUES ('" + this.txtCategory.Text + "')";
                SQLiteCommand com = new SQLiteCommand(sql, con);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                this.fillData();
            }
        }

        void cleaner()
        {
            this.lblCatError.Text = "";
            this.txtCategory.Text = "";
            this.btnAdd.Visible = true;
            this.btnDelete.Visible = false;
            this.btnUpdate.Visible = false;
        }

        void fillData()
        {
            List<Category> Main_Categories = new List<Category>();

            foreach (DataRow row in this.select(null).Rows)
            {
                Main_Categories.Add(new Category()
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString()
                });
            }

            Dictionary<int, Category> categories = new Dictionary<int, Category>();
             
            foreach (Category cat in Main_Categories)
            {
                int number;
                int.TryParse(cat.Name.Split('.').ToArray()[0], out number);
                if(!categories.ContainsKey(number)) categories.Add(number, cat); 
            }

            this.dgvData.Rows.Clear();
            int a = 0;
            foreach (KeyValuePair<int, Category> cat in categories.OrderBy(c => c.Key))
            {
                this.dgvData.Rows.Add();
                this.dgvData.Rows[a].Cells[0].Value = cat.Value.Id;
                this.dgvData.Rows[a].Cells[1].Value = cat.Value.Name;
                a++;
            }
            this.cleaner();  
        } 

        DataTable select(int? id)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM Categories";
            sql += id != null ? " WHERE id = " + id : "";
            SQLiteCommand com = new SQLiteCommand(sql, con);
            da.SelectCommand = com;
            da.Fill(dt);
            return dt;
        }

        void deleteAllQuations(int catId)
        {
            List<int> ticket_ids = new List<int>();
            SQLiteDataAdapter da = new SQLiteDataAdapter();
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM Quations WHERE category_id = " + catId;
            SQLiteCommand com = new SQLiteCommand(sql, con);
            da.SelectCommand = com;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    sql = "DELETE FROM Quations WHERE category_id = " + Convert.ToInt32(row["category_id"]);
                    com.CommandText = sql;
                    com.Connection = con;
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    Extentions.DeleteFile(row["image"].ToString(), "Quations_Images");

                    using (SQLiteConnection conn = new SQLiteConnection(Login.connection))
                    {
                        sql = "SELECT ticket_id FROM P_TicketAndQuation WHERE quation_id = " + Convert.ToInt32(row["id"]);
                        SQLiteCommand command = new SQLiteCommand(sql, conn);
                        conn.Open();
                        SQLiteDataReader dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            int ticket_id = Convert.ToInt32(dr[0]);
                            if (!ticket_ids.Contains(ticket_id))
                            {
                                ticket_ids.Add(ticket_id);
                            }
                        }
                        con.Close();
                    }
                }
            }

            if (ticket_ids.Count > 0)
            {
                foreach (int id in ticket_ids)
                {
                    using (SQLiteConnection connection = new SQLiteConnection(Login.connection))
                    {
                        string query = "DELETE FROM P_TicketAndQuation WHERE ticket_id = " + id;
                        SQLiteCommand command = new SQLiteCommand(query, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    using (SQLiteConnection connection = new SQLiteConnection(Login.connection))
                    {
                        string query = "DELETE FROM Tickets WHERE id = " + id;
                        SQLiteCommand command = new SQLiteCommand(query, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Həmçinin bu mövzu ile əlaqəli  butun Suallar və Biletlər silinəcək", "Mövzunu sil", MessageBoxButtons.YesNo))
            {
                string sql = "DELETE FROM Categories WHERE id = " + this.id;
                SQLiteCommand com = new SQLiteCommand(sql, con);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                this.fillData();
                this.deleteAllQuations(this.id);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE Categories SET name = '" + this.txtCategory.Text + "' WHERE id = " + this.id;
            SQLiteCommand com = new SQLiteCommand(sql, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            this.fillData();
        }

        private void Celect(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.id = Convert.ToInt32(this.dgvData.Rows[e.RowIndex].Cells[0].Value);
                if (this.id > 0)
                {
                    this.btnAdd.Visible = false;
                    this.btnDelete.Visible = true;
                    this.btnUpdate.Visible = true;
                    this.txtCategory.Text =this.select(id).Rows[0]["name"].ToString();
                }
                else
                {
                    //MessageBox.Show("sdsd");
                    this.cleaner();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Düzgün yerə basın","Position 0");
            }
           
        }

        private void Categories_Load(object sender, EventArgs e)
        {

        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("iki dəfə basın");
        }
    }
}
