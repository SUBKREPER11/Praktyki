using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace menedzer_plac
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            //InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialog = new OpenFileDialog();

            FileDialog.Title = "Select Text File!";
            FileDialog.InitialDirectory = @"c:\\";
            FileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = FileDialog.FileName;
                Properties.Settings.Default.fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            }

            string filePath = Properties.Settings.Default.fullPath;
            string ctlName;
            Control[] matches;
            Control player, score;
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                player = null;
                ctlName = "txtPlayer" + (i + 1).ToString();
                matches = this.Controls.Find(ctlName, true);
                if (matches.Length > 0)
                {
                    player = matches[0];
                    player.Text = "";
                }

                score = null;
                ctlName = "lblPlayer" + (i + 1).ToString() + "Points";
                matches = this.Controls.Find(ctlName, true);
                if (matches.Length > 0)
                {
                    score = matches[0];
                    score.Text = "";
                }

                if (i < lines.GetUpperBound(0))
                {
                    string[] parts = lines[i].Split(",".ToCharArray());
                    if (parts.Length == 2)
                    {
                        string[] nameParts = parts[0].Split(":".ToCharArray());
                        if (nameParts.Length == 2)
                        {
                            if (player != null)
                            {
                                player.Text = nameParts[1].Trim();
                            }
                        }
                        string[] scoreParts = parts[1].Split(":".ToCharArray());
                        if (scoreParts.Length == 2)
                        {
                            if (score != null)
                            {
                                score.Text = scoreParts[1].Trim();
                            }
                        }
                    }
                }
            }
        }
    }
}
