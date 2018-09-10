using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using System;
using System.Drawing;
using School.Settings;
using System.Net.Http;
using System.Net.Http.Headers;
using School.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace School.Pages
{
    public partial class Student : Form
    { 
         
        const string TOKET = "628x9x0xx447xx4x421x517x4x474x33x2065x4x1xx523xxxxx6x7x20";

        public static Form ThisForm { get; set; }

        public List<Activation_C> Activations { get; set; } = new List<Activation_C>();

        public Student()
        {
            InitializeComponent();
            this.getData(); 
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            AdminPanel.ThisForm.Show();
        }
         
        void getData()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://sakit.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync($"api/activations?token={TOKET}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var products = response.Content.ReadAsStringAsync().Result;
                    List<Activation_C> activations = JsonConvert.DeserializeObject<List<Activation_C>>(products);
                    this.Activations = activations;
                    int index = 0;
                    this.lblCount.Text = activations.Count.ToString();
                    this.dgvData.Rows.Clear();
                    foreach (Activation_C a in activations)
                    {
                        this.dgvData.Rows.Add();
                        this.dgvData.Rows[index].Cells[0].Value = a.activation_code;
                        this.dgvData.Rows[index].Cells[1].Value = a.username;
                        this.dgvData.Rows[index].Cells[2].Value = a.user_email;
                        this.dgvData.Rows[index].Cells[3].Value = a.computer_info;
                        this.dgvData.Rows[index].Cells[4].Value = a.status ? "Activasiya olunub" : "Activasiya olunmayıb";
                        index++;
                    }
                    this.lblError.Text = "";
                }
            }
            catch (Exception)
            {
                this.lblError.Text = "Serverə qoşularkən xəta baş verdi, zəhmət olmasa internet bağlantınızı yoxlayin";
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            ThisForm = this;
            this.Hide();
            new ActivatedStudents().Show();
        }

        private void SearchUser(object sender, KeyEventArgs e)
        {
            if (this.txtSearch.Text == "")
            {
                this.getData();
                return;
            } 
            this.dgvData.Rows.Clear();
            List<Activation_C> selected = new List<Activation_C>();

            if (this.rdUsername.Checked)
            {
                selected = Activations.Where(a => a.username != null && a.username.ToLower().Contains(this.txtSearch.Text.ToLower())).ToList();
            }
            else
            {
                selected = Activations.Where(a => a.user_email != null && a.user_email.Contains(this.txtSearch.Text.ToLower())).ToList();
            }

            int index = 0;
            foreach (Activation_C item in selected)
            {
                this.dgvData.Rows.Add();
                this.dgvData.Rows[index].Cells[0].Value = item.activation_code;
                this.dgvData.Rows[index].Cells[1].Value = item.username;
                this.dgvData.Rows[index].Cells[2].Value = item.user_email;
                this.dgvData.Rows[index].Cells[3].Value = item.computer_info;
                this.dgvData.Rows[index].Cells[4].Value = item.status ? "Activated" : "No Activated";
                index++;
            }
        }

        private void Student_Load(object sender, EventArgs e)
        {
            grpStudents.Width = this.Width - 50;
            grpStudents.Height = this.Height - 200;
            dgvData.Width = grpStudents.Width - 20;
            dgvData.Height = grpStudents.Height - 20;
            grpInfo.Left = (this.Width - grpInfo.Width) - 40;
            btnAll.Left = grpInfo.Left;
        }

        private void FormResize(object sender, EventArgs e)
        {
            grpStudents.Width = this.Width - 50;
            grpStudents.Height = this.Height - 200;
            dgvData.Width = grpStudents.Width - 20;
            dgvData.Height = grpStudents.Height - 20;
            grpInfo.Left = (this.Width - grpInfo.Width) - 40;
            btnAll.Left = grpInfo.Left;
        }
    }
}
