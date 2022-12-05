using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace ZIP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string start = @"C:\Praktyki\P_Data";
        string zip = @"C:\Praktyki\zip.zip";
        //string end = @"C:\Praktyki\end";

        private void button3_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked == false)
            {
                CommonOpenFileDialog fileDialog = new CommonOpenFileDialog();
                fileDialog.InitialDirectory = @"C:\\";
                fileDialog.IsFolderPicker = true;
                if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    //MessageBox.Show("You selected: " + fileDialog.FileName);
                    //string fileName;
                    //fileName = fileDialog.FileName;
                    string location = @fileDialog.FileName;
                    if (File.Exists(location + ".zip"))
                        File.Delete(location + ".zip");
                    ZipFile.CreateFromDirectory(location, location + ".zip");
                }
            }
            else
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Title = "Select File!";
                fileDialog.InitialDirectory = @"c:\\";
                fileDialog.Filter = "zip files (*.zip)|*.zip";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    //MessageBox.Show("Extract function");
                    FileInfo fi = new FileInfo(fileDialog.FileName);
                    string direc = fi.DirectoryName;
                    direc += @"\extracted "+fi.Name;
                    ZipFile.ExtractToDirectory(fileDialog.FileName, direc);
                    MessageBox.Show("Extracted to: " + direc);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
                button3.Text = "Open";
            else
                button3.Text = "Extract";
        }
    }
}
