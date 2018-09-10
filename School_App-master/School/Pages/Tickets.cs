using School.Models;
using System;
using System.Collections.Generic; 
using System.Data; 
using System.Data.SQLite;
using System.Drawing;
using System.Linq; 
using System.Windows.Forms;

namespace School.Pages
{
    public partial class Tickets : Form
    {
        public static Form ThisForm { get; set; }
        List<Ticket> tickets = new List<Ticket>();
        public Tickets()
        {
            InitializeComponent();
            this.tickets = this.selectAllTicket();
            fillPanel();
            ThisForm = this;
        }

        private void btnAddTicket_Click(object sender, EventArgs e)
        { 
            new AddTicket(this).Show();
            this.Hide();
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            AdminPanel.ThisForm.Show();
        }

        List<Ticket> selectAllTicket()
        {
            List<Ticket> tickets = new List<Ticket>();
            using(SQLiteConnection con =new SQLiteConnection(Login.connection))
            {
                string sql = "SELECT * FROM Tickets";
                SQLiteCommand com = new SQLiteCommand(sql, con);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand =  com;
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    tickets.Add(new Ticket()
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Name = row["name"].ToString()
                    });
                }

                return tickets;
            }
        }

        public void fillPanel()
        {
            this.dgwTickets.Rows.Clear();
            int index = 0;
            foreach (Ticket tick in this.tickets)
            { 

                DataGridViewButtonCell update = new DataGridViewButtonCell();
                update.Value = "Yenilə";
                update.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                update.FlatStyle = FlatStyle.Flat;
                update.Style.BackColor = Color.LimeGreen; 
                update.Style.ForeColor = Color.White;
                

                DataGridViewButtonCell delete = new DataGridViewButtonCell();
                delete.Value = "Sil";
                delete.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                delete.FlatStyle = FlatStyle.Flat;
                delete.Style.BackColor = Color.IndianRed;
                delete.Style.ForeColor = Color.White;


                this.dgwTickets.Rows.Add();
                this.dgwTickets.Rows[index].Cells[0].Value = tick.Id;
                this.dgwTickets.Rows[index].Cells[1].Value = tick.Name;
                this.dgwTickets[2,index] = update;
                this.dgwTickets[3,index] = delete;
                index++;
            }
        }

        private void updateAndDelete(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(this.dgwTickets.Rows[e.RowIndex].Cells[0].Value);
            if(e.ColumnIndex == 3)
            {
                this.delete(id);
                this.fillPanel();
            }
            if(e.ColumnIndex == 2)
            {
                AddTicket form = new AddTicket(this);
                form.update(id);
                this.Hide();
                form.Show();
            }
        }

        void delete(int ticketId)
        {
            string sql = "DELETE FROM P_TicketAndQuation WHERE ticket_id = " + ticketId;
            using(SQLiteConnection con =new SQLiteConnection(Login.connection))
            {
                con.Open();
                SQLiteCommand com = new SQLiteCommand(sql, con);
                com.ExecuteNonQuery();
            }

            using(SQLiteConnection con = new SQLiteConnection(Login.connection))
            {
                sql = "DELETE FROM Tickets WHERE id = " + ticketId;
                con.Open();
                SQLiteCommand com = new SQLiteCommand(sql, con);
                com.ExecuteNonQuery();
            }

            this.tickets.Remove(this.tickets.First(t => t.Id == ticketId));
        }

        public void updatePanel()
        {
            this.tickets = this.selectAllTicket();
            this.fillPanel();
        }

        private void Tickets_Load(object sender, EventArgs e)
        {
            grpTickets.Width = this.Width - 50;
            dgwTickets.Width = grpTickets.Width - 13;
            btnAddTicket.Left = (this.Width - btnAddTicket.Width) - 50;
        }

        private void FormResize(object sender, EventArgs e)
        {
            grpTickets.Width = this.Width - 50;
            dgwTickets.Width = grpTickets.Width - 13;
            btnAddTicket.Left = (this.Width - btnAddTicket.Width) - 50;
        }
    }
}
