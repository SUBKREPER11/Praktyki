using System;
using System.IO;
using System.Windows.Forms;

namespace menedzer_plac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //TextBox workerNameT, accNumT, plcT, wrkStrtDatT, bonT;
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
                workerNameT.Enabled = true;
                accNumT.Enabled = true;
                plcT.Enabled = true;
                //wrkStrtDatT.Enabled = true;
                bonT.Enabled = true;
                //button1.Enabled = true;
                button2.Enabled = true;
                dateTimePicker1.Enabled = true;
                if (workersList.SelectedIndex < 0)
                    button1.Enabled = false;
                else
                    button1.Enabled = true;
            }
            //workersList.Items.Clear();
            string filePath = Properties.Settings.Default.fullPath;
            if(File.ReadAllLines(filePath).Length < 1)
                File.AppendAllText(filePath, "I; I, N; 1, S; St1, D; 01.01.2000, B; 1");
            string[] lines = File.ReadAllLines(filePath);
            //Array.Resize(ref lines, lines.Length + 1);
            for (int i = 0; i < lines.Length; i++)
            {
                if (i < lines.GetUpperBound(0))
                {
                    string[] parts = lines[i].Split(",".ToCharArray());
                    if (parts.Length == 5)
                    {
                        string[] nameParts = parts[0].Split(";".ToCharArray());
                        if (nameParts.Length == 2)
                        {
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
            int var;
            if (index < 0)
                var = 0;
            else
                var = index;
            if (workersList.SelectedIndex < 0)
                button1.Enabled = false;
            else
                button1.Enabled = true;
            //MessageBox.Show(index.ToString());
            string[] parts = lines[var].Split(",".ToCharArray());
            if (parts.Length == 5)
            {
                string[] wrkNam = parts[0].Split(";".ToCharArray());
                if (wrkNam.Length == 2)
                {
                    workerNameT.Text = "" + wrkNam[1].Trim();
                }
                string[] acNum = parts[1].Split(";".ToCharArray());
                if (acNum.Length == 2)
                {
                    accNumT.Text = "" + acNum[1].Trim();
                }
                string[] stan = parts[2].Split(";".ToCharArray());
                if (stan.Length == 2)
                {
                    plcT.Text = "" + stan[1].Trim();
                }
                string[] wrkStrt = parts[3].Split(";".ToCharArray());
                if (wrkStrt.Length == 2)
                {
                    //dateTimePicker1.CustomFormat = "dd/MM/yyyy";
                    //wrkStrtDatT.Text = "" + wrkStrt[1].Trim();
                    //dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    dateTimePicker1.Value = Convert.ToDateTime(wrkStrt[1].Trim());
                }
                string[] bns = parts[4].Split(";".ToCharArray());
                if (bns.Length == 2)
                {
                    bonT.Text = "" + bns[1].Trim() + "";
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
        }

        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
        static void userAdder(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
            File.AppendAllText(fileName, "End" + Environment.NewLine);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //player1.URL = Convert.ToString(workersList.SelectedItem);
            string filePath = Properties.Settings.Default.fullPath;
            string[] lines = File.ReadAllLines(filePath);
            int index = workersList.SelectedIndex;
            int var;
            if (index < 0)
                var = 0;
            else
                var = index;
            //MessageBox.Show(index.ToString());
            string[] parts = lines[var].Split(",".ToCharArray());
            if (parts.Length == 5)
            {
                string[] wrkNam = parts[0].Split(";".ToCharArray());
                string[] acNum = parts[1].Split(";".ToCharArray());
                string[] stan = parts[2].Split(";".ToCharArray());
                string[] wrkStrt = parts[3].Split(";".ToCharArray());
                string[] bns = parts[4].Split(";".ToCharArray());
                lineChanger("I; " + workerNameT.Text + ", N; " + accNumT.Text + ", S; " +
                plcT.Text + ", D; " + dateTimePicker1.Value + ", B; " + bonT.Text, filePath, index + 1);
                //workersList.Items.RemoveAt(index);
                workersList.Items.Insert(index, workerNameT.Text);
                workersList.SelectedIndex = index;
                workersList.Items.RemoveAt(index + 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //player1.URL = Convert.ToString(workersList.SelectedItem);
            string filePath = Properties.Settings.Default.fullPath;
            string[] lines = File.ReadAllLines(filePath);
            int index = workersList.SelectedIndex;
            //MessageBox.Show(index.ToString());
            //workersList.SelectedIndex = index;
            //MessageBox.Show(lines.GetUpperBound(0).ToString());
            int var;
            if (index < 0)
                var = 0;
            else
                var = index;
            string[] parts = lines[var].Split(",".ToCharArray());
            if (parts.Length == 5)
            {
                string[] wrkNam = parts[0].Split(";".ToCharArray());
                string[] acNum = parts[1].Split(";".ToCharArray());
                string[] stan = parts[2].Split(";".ToCharArray());
                string[] wrkStrt = parts[3].Split(";".ToCharArray());
                string[] bns = parts[4].Split(";".ToCharArray());

                userAdder("I; " + workerNameT.Text + ", N; " + accNumT.Text + ", S; " +
                plcT.Text + ", D; " + dateTimePicker1.Value + ", B; " + bonT.Text, filePath, lines.GetUpperBound(0) + 1);
                workersList.Items.Add(workerNameT.Text);
                workersList.SelectedIndex = lines.GetUpperBound(0);
            }
        }
    }
}
