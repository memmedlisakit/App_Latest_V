using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using School.Settings; 
using System.Web.Script.Serialization;
using Newtonsoft.Json; 
using School.Models;
using System.Net.Http;
using System.Net.Http.Headers; 

namespace School.Pages
{
    public partial class AddActivation : Form
    {
        List<string> activations = new List<string>();

        const string TOKET = "628x9x0xx447xx4x421x517x4x474x33x2065x4x1xx523xxxxx6x7x20";

        public static string message { get; set; } = "";
         
        public AddActivation()
        {
            InitializeComponent();
            btnExel.Enabled = false;
        }




        private void btnActivation_Click(object sender, EventArgs e)
        { 
            int count = 0;
            if (txtActivation.Text == ""||(!int.TryParse(this.txtActivation.Text, out count))|| txtActivation.Text == "0")
            {
                this.lblCount.Text = "Aktivasiya sayını daxil edin ";
                return;
            }
            else
            {
                if (count > 200)
                {
                    this.lblCount.Text = "Maximum say 200 ";
                    return;
                }
                btnActivation.Enabled = false;
                this.lblCount.Text = "";
                this.dgvData.Rows.Clear(); 
                this.activations = this.ActivateGenerator(count);
                int i = 0; 
                foreach (string activate in this.activations)
                {
                    this.dgvData.Rows.Add();
                    this.dgvData.Rows[i].Cells[0].Value = activate;
                    i++;
                }
            }
            btnExel.Enabled = true;
        }

        public void btnExel_Click(object sender, EventArgs e)
        {
            btnExel.Enabled = false;
            btnExel.Text = "Gözləyin...";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                addData(this.activations);
                if (message != "")
                {
                    this.lblError.ForeColor = Color.Red;
                    this.lblError.Text = message;
                    this.btnExel.Text = "Yadda saxla exel";
                    return;
                }
                this.lblError.ForeColor = Color.LimeGreen;
                this.lblError.Text = "Uğurla tamamlandı"; 
                Extentions.Export_data(this.dgvData, sfd.FileName); 
            }
            btnExel.Text = "Bitdi";
        }

        static void addData(List<string> activations)
        {
            try
            {
                foreach (string code in activations)
                {
                    Activation_C activation = new Activation_C { activation_code = code, status = false };
                    string json = new JavaScriptSerializer().Serialize(activation);
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://sakit.azurewebsites.net/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.GetAsync($"api/activations?code={json}&token={TOKET}").Result;
                    }
                }
            }
            catch (Exception)
            {
                message = "Serverə qoşularkən xəta baş verdi, \r\nzəhmət olmasa internet bağlantınızı yoxlayın";
            }
        }

        private List<string> ActivateGenerator(int count)
        {
            List<string> activations = new List<string>();
            while(true)
            {
                string activate = "";
                Random rnd = new Random();
                MD5 md5 = new MD5CryptoServiceProvider();
                string text = rnd.Next(0, 5000).ToString();
                md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
                foreach (var c in md5.Hash)
                {
                    activate += c;
                }
                activate = activate.Substring(0, 10);
                activate += DateTime.Now.ToString("ddMMyyyy");
                activations.Add(activate);
                activations = activations.Distinct().ToList();
                if (activations.Count == count) break;
            }
            return activations;
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            AdminPanel.ThisForm.Show();
            this.Hide();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
