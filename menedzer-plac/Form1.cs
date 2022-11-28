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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DateTime zeroTime = new DateTime(1, 1, 1);
        DateTime currDate = DateTime.Now;
        private void button1_Click(object sender, EventArgs e)
        {
            workersList.Items.Clear();
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
            //string ctlName;
            //Control[] matches;
            //Control player;
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                //player = null;
                //ctlName = "label" + (i + 1).ToString();
                //matches = this.Controls.Find(ctlName, true);
                //if (matches.Length > 0)
                //{
                //    player = matches[0];
                //    player.Text = "";
                //}
                if (i < lines.GetUpperBound(0))
                {
                    string[] parts = lines[i].Split(",".ToCharArray());
                    if (parts.Length == 5)
                    {
                        string[] nameParts = parts[0].Split(":".ToCharArray());
                        if (nameParts.Length == 2)
                        {
                                //player.Text = nameParts[1].Trim();
                                workersList.Items.Add(nameParts[1].Trim());
                        }
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //player1.URL = Convert.ToString(workersList.SelectedItem);
            string filePath = Properties.Settings.Default.fullPath;
            string[] lines = File.ReadAllLines(filePath);
            int index = workersList.SelectedIndex;
            //MessageBox.Show(index.ToString());
            string[] parts = lines[index].Split(",".ToCharArray());
            if (parts.Length == 5)
            {
                string[] wrkNam = parts[0].Split(":".ToCharArray());
                if (wrkNam.Length == 2)
                {
                        workerName.Text = "Imie pracownika: " + wrkNam[1].Trim();
                }
                string[] acNum = parts[1].Split(":".ToCharArray());
                if(acNum.Length == 2)
                {
                    accNum.Text = "Numer konta: " + acNum[1].Trim();
                }
                string[] stan = parts[2].Split(":".ToCharArray());
                if(stan.Length == 2)
                {
                    plc.Text = "Stanowisko: " + stan[1].Trim();
                }
                string[] wrkStrt = parts[3].Split(":".ToCharArray());
                if (wrkStrt.Length == 2)
                {
                    wrkStrtDat.Text = "Data zatrudnienia: " + wrkStrt[1].Trim();
                }
                string[] bns = parts[4].Split(":".ToCharArray());
                if (bns.Length == 2)
                {
                    bon.Text = "Bonus: " + bns[1].Trim() + "$";
                }

                DateTime strtDate = Convert.ToDateTime(wrkStrt[1].Trim());
                TimeSpan span = currDate - strtDate;
                int yrs = (zeroTime + span).Year - 1;
                //MessageBox.Show(yrs.ToString());
                int stVal;
                if (stan[1].Trim() == "St1")
                    stVal = 100;
                else if (stan[1].Trim() == "St2")
                    stVal = 200;
                else if (stan[1].Trim() == "St3")
                    stVal = 300;
                else if (stan[1].Trim() == "St4")
                    stVal = 400;
                else
                    stVal = 50;

                int wyplata = (yrs * 100) + int.Parse(bns[1].Trim()) + stVal;
                //MessageBox.Show("Wypłata: " + wyplata.ToString() + "$"); 
                payCheck.Text = "Wypłata: " + wyplata.ToString() + "$";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int i = workersList.FindString(textBox1.Text);
            string filePath = Properties.Settings.Default.fullPath;
            string[] lines = File.ReadAllLines(filePath);
            if (i <= lines.Length && i > -1)
                workersList.SelectedIndex = i;
            //MessageBox.Show("OK " + i.ToString());
            else
                //MessageBox.Show("NIE OK " + i.ToString());
                MessageBox.Show("Nie znaleziono osoby o nazwie: " + textBox1.Text);
            // workersList.SelectedIndex = i;
        }
    }
}
