using School.Models;
using School.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace School.Settings
{
   public static class  Extentions
    {
        public static void Export_data(DataGridView dGV, string filename)
        {
            string stOutput = "";
            string sHeaders = ""; 
            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            for (int i = 0; i < dGV.RowCount; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += "\""+stLine+"\"" + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length);
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        public static void ImageUpload(OpenFileDialog file, string imageName, string folderName)
        {
            string path = GetPath() + folderName + "\\" + imageName;
            WebClient webclient = new WebClient();
            webclient.DownloadFile(file.FileName, path);
        }

        public static string GetPath()
        {
            //string path = Application.StartupPath; bunun uzerinde yapalim daha az soru olur belki
            //List<string> splited = Regex.Split(path, "bin").ToList();
            //return splited[0];

            return Path.GetDirectoryName(Application.ExecutablePath) + "\\";

        }

        public static void DeleteFile(string fileName, string folderName)
        {
            string path = Application.StartupPath;
            //List<string> splited = Regex.Split(path, "bin").ToList();
            File.Delete(path + "\\" + folderName + "\\" + fileName);
        }
    }
}
