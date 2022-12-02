using System;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Reflection;
using menadzer_plac_SQL;

namespace menedzer_plac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //SQLiteConnection con = new SQLiteConnection("Data Source=C:/Praktyki/P_Data/workers.db");
        SQLiteConnection con = new SQLiteConnection("DataSource=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/res/workers.db");
        QueryExec execute = new QueryExec();
        //TextBox workerNameT, accNumT, plcT, wrkStrtDatT, bonT;
        DateTime zeroTime = new DateTime(1, 1, 1);
        DateTime currDate = DateTime.Now;
        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName);
            workerNameT.Enabled = true;
            accNumT.Enabled = true;
            plcT.Enabled = true;
            dateTimePicker1.Enabled = true;
            bonT.Enabled = true;
            button2.Enabled = true;

            string query = "SELECT COUNT(ID) FROM worker";
            workersList.Items.Clear();
            con.Close();
            con.Open();
            int val =Convert.ToInt32(execute.exec(query,con));
            for(int i = 0; i < val; i++)
            {
                string workers = "SELECT name FROM worker WHERE ID=" + (i + 1);
                string output = Convert.ToString(execute.exec(workers,con));
                workersList.Items.Add(output);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            string nameQ = "SELECT name FROM worker WHERE ID=" + (var + 1);
            workerNameT.Text = Convert.ToString(execute.exec(nameQ,con));

            string accnumQ = "SELECT accnum FROM worker WHERE ID=" + (var + 1);
            accNumT.Text = Convert.ToString(execute.exec(accnumQ,con));

            string wrkplcQ = "SELECT wrkplc FROM worker WHERE ID=" + (var + 1);
            plcT.Text = Convert.ToString(execute.exec(wrkplcQ,con));

            string joidateQ = "SELECT joidate FROM worker WHERE ID=" + (var + 1);
            dateTimePicker1.Value = Convert.ToDateTime(execute.exec(joidateQ,con));

            string bonusQ = "SELECT bonus FROM worker WHERE ID=" + (var + 1);
            bonT.Text = Convert.ToString(execute.exec(bonusQ,con));



            DateTime strtDate = dateTimePicker1.Value;
            TimeSpan span = currDate - strtDate;
            int yrs = (zeroTime + span).Year - 1;
            //MessageBox.Show(yrs.ToString());
            int stVal;
            if (plcT.Text.ToLower() == "st1")
                stVal = 100;
            else if (plcT.Text.ToLower() == "st2")
                stVal = 200;
            else if (plcT.Text.ToLower() == "st3")
                stVal = 300;
            else if (plcT.Text.ToLower() == "st4")
                stVal = 400;
            else
                stVal = 50;

            int wyplata = (yrs * 100) + int.Parse(bonT.Text) + stVal; 
            payCheck.Text = "Wypłata: " + wyplata.ToString() + "$";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT COUNT(ID) FROM worker";
            int val = Convert.ToInt32(execute.exec(query,con));
            int i = workersList.FindString(textBox1.Text);
            if (i <= val && i > -1)
                workersList.SelectedIndex = i;
            else
                MessageBox.Show("Nie znaleziono osoby o nazwie: " + textBox1.Text);

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            int index = workersList.SelectedIndex;
            int var;
            if (index < 0)
                var = 0;
            else
                var = index;
            string updateQ = "UPDATE worker SET name='" +
                workerNameT.Text +"', accnum=" + accNumT.Text +
                ", wrkplc='" + plcT.Text + "', joidate='" + dateTimePicker1.Value +  "', bonus=" + bonT.Text + " WHERE ID=" + (var + 1);
            execute.exec(updateQ, con);
            workersList.Items.Insert(index, workerNameT.Text);
            workersList.SelectedIndex = index;
            workersList.Items.RemoveAt(index + 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String insertQ = "INSERT INTO worker (name, accnum, wrkplc, joidate, bonus) VALUES ('" + 
                workerNameT.Text + "'," + accNumT.Text + ",'" + plcT.Text + "','" + dateTimePicker1.Value + "'," + bonT.Text + ")";
            execute.exec(insertQ, con);
            workersList.Items.Add(workerNameT.Text);
            workersList.SelectedIndex = workersList.Items.Count - 1;
        }
    }
}