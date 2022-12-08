using Ionic.Zip;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;
//using System.IO.Compression;
using System.Windows.Forms;

namespace ZIP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.UseSystemPasswordChar = true;
        }
        string start = @"C:\Praktyki\P_Data";
        string zip = @"C:\Praktyki\zip.zip";
        //string end = @"C:\Praktyki\end";
        CommonOpenFileDialog fileDialog = new CommonOpenFileDialog();
        OpenFileDialog fileDialog2 = new OpenFileDialog();
        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                fileDialog.InitialDirectory = @"C:\\";
                fileDialog.IsFolderPicker = true;
                if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    button1.Enabled = true;
                }
            }
            else
            {
                fileDialog2.Title = "Select File!";
                fileDialog2.InitialDirectory = @"c:\\";
                fileDialog2.Filter = "zip files (*.zip)|*.zip";
                if (fileDialog2.ShowDialog() == DialogResult.OK)
                {
                    button1.Enabled = true;

                    if (Ionic.Zip.ZipFile.CheckZipPassword(fileDialog2.FileName, ""))
                    {
                        label1.Visible = false;
                    }
                    else
                    {
                        label1.Visible = true;
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if (checkBox1.Checked == false)
            {
                button3.Text = "Select folder 📁";
                button1.Text = "Zip";
            }
            else
            {
                button3.Text = "Select file 🗎";
                button1.Text = "Unzip";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                string location = @fileDialog.FileName;
                using (ZipFile zip = new ZipFile())
                {
                    if (textBox1.TextLength > 0)
                    {
                        zip.Password = textBox1.Text;
                        zip.AddDirectory(location);
                        zip.Save(location + ".zip");
                    }
                    else
                    {
                        zip.AddDirectory(location);
                        zip.Save(location + ".zip");
                    }
                    MessageBox.Show("Zipped");
                }
            }
            else
            {
                //MessageBox.Show("Extract function");
                FileInfo fi = new FileInfo(fileDialog2.FileName);
                string direc = fi.DirectoryName;
                direc += @"\extracted " + fi.Name;
                //ZipFile.ExtractToDirectory(fileDialog.FileName, direc);
                using (ZipFile zip = ZipFile.Read(fileDialog2.FileName))
                {
                    //zip.Password = textBox1.Text;
                    if (Ionic.Zip.ZipFile.CheckZipPassword(fileDialog2.FileName, textBox1.Text))
                    {
                        zip.Password = textBox1.Text;
                        zip.ExtractAll(direc,ExtractExistingFileAction.OverwriteSilently);
                        MessageBox.Show("Extracted to: " + direc);
                    }
                    else
                        MessageBox.Show("Błędne chasło. Spróbuj ponownie");
                }
            }
        }
    }
}
