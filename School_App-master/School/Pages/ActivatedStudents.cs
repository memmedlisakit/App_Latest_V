using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School.Pages
{
    public partial class ActivatedStudents : Form
    {  
        const string STUDENT_TOKEN = "d1347bda-b758-4857-91b5-354e6e368bac";

        public ActivatedStudents()
        {
            InitializeComponent();
            getData(); 
        }

        public void Closing(object sender, FormClosingEventArgs e)
        {
            Student.ThisForm.Show();
        }

        void getData()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://sakit.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync($"api/students?token={STUDENT_TOKEN}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var products = response.Content.ReadAsStringAsync().Result;
                    List<Json_Student> students = JsonConvert.DeserializeObject<List<Json_Student>>(products);
                    int index = 0;
                    this.lblCount.Text = students.Count.ToString();
                    foreach (Json_Student s in students)
                    { 
                        this.dgvData.Rows.Add();
                        this.dgvData.Rows[index].Cells[0].Value = s.id;
                        this.dgvData.Rows[index].Cells[1].Value = s.name;
                        this.dgvData.Rows[index].Cells[2].Value = s.surname;
                        this.dgvData.Rows[index].Cells[3].Value = s.email;
                        this.dgvData.Rows[index].Cells[4].Value = s.gender == true ? "Kişi" : "Qadın";
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

        private void ActivatedStudents_Load(object sender, EventArgs e)
        {
            dgvData.Width = this.Width - 40;
        }

        private void FormResize(object sender, EventArgs e)
        {
            dgvData.Width = this.Width - 40;
        }
    }
}
