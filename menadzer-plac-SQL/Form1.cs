using System;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Reflection;

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
            SQLiteCommand command = new SQLiteCommand(query);
            command.Connection = con;
            int val =Convert.ToInt32(command.ExecuteScalar());
            for(int i = 0; i < val; i++)
            {
                SQLiteCommand workers = new SQLiteCommand("SELECT name FROM worker WHERE ID=" + (i + 1));
                workers.Connection = con;
                string output = Convert.ToString(workers.ExecuteScalar());
                //workersList.Items.Add(output);
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
            SQLiteCommand nameT = new SQLiteCommand(nameQ);
            nameT.Connection = con;
            workerNameT.Text = Convert.ToString(nameT.ExecuteScalar());

            string accnumQ = "SELECT accnum FROM worker WHERE ID=" + (var + 1);
            SQLiteCommand accnumT = new SQLiteCommand(accnumQ);
            accnumT.Connection = con;
            accNumT.Text = Convert.ToString(accnumT.ExecuteScalar());

            string wrkplcQ = "SELECT wrkplc FROM worker WHERE ID=" + (var + 1);
            SQLiteCommand wrkplcT = new SQLiteCommand(wrkplcQ);
            wrkplcT.Connection = con;
            plcT.Text = Convert.ToString(wrkplcT.ExecuteScalar());

            string joidateQ = "SELECT joidate FROM worker WHERE ID=" + (var + 1);
            SQLiteCommand joidateT = new SQLiteCommand(joidateQ);
            joidateT.Connection = con;
            dateTimePicker1.Value = Convert.ToDateTime(joidateT.ExecuteScalar());

            string bonusQ = "SELECT bonus FROM worker WHERE ID=" + (var + 1);
            SQLiteCommand bonusT = new SQLiteCommand(bonusQ);
            bonusT.Connection = con;
            bonT.Text = Convert.ToString(bonusT.ExecuteScalar());



            DateTime strtDate = dateTimePicker1.Value;
            TimeSpan span = currDate - strtDate;
            int yrs = (zeroTime + span).Year - 1;
            //MessageBox.Show(yrs.ToString());
            int stVal;
            if (plcT.Text == "St1" || plcT.Text == "st1" || plcT.Text == "sT1" || plcT.Text == "ST1")
                stVal = 100;
            else if (plcT.Text == "St2" || plcT.Text == "st2" || plcT.Text == "sT2" || plcT.Text == "ST2")
                stVal = 200;
            else if (plcT.Text == "St3" || plcT.Text == "st3" || plcT.Text == "sT3" || plcT.Text == "ST3")
                stVal = 300;
            else if (plcT.Text == "St4" || plcT.Text == "st4" || plcT.Text == "sT4" || plcT.Text == "ST4")
                stVal = 400;
            else
                stVal = 50;

            int wyplata = (yrs * 100) + int.Parse(bonT.Text) + stVal;
            //MessageBox.Show("Wypłata: " + wyplata.ToString() + "$"); 
            payCheck.Text = "Wypłata: " + wyplata.ToString() + "$";

            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT COUNT(ID) FROM worker";
            SQLiteCommand command = new SQLiteCommand(query);
            command.Connection = con;
            int val = Convert.ToInt32(command.ExecuteScalar());
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
            SQLiteCommand updateT = new SQLiteCommand(updateQ);
            updateT.Connection = con;
            updateT.ExecuteScalar();
            workersList.Items.Insert(index, workerNameT.Text);
            workersList.SelectedIndex = index;
            workersList.Items.RemoveAt(index + 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String insertQ = "INSERT INTO worker (name, accnum, wrkplc, joidate, bonus) VALUES ('" + 
                workerNameT.Text + "'," + accNumT.Text + ",'" + plcT.Text + "','" + dateTimePicker1.Value + "'," + bonT.Text + ")";
            SQLiteCommand insertT = new SQLiteCommand(insertQ);
            insertT.Connection = con;
            insertT.ExecuteScalar();
            workersList.Items.Add(workerNameT.Text);
            workersList.SelectedIndex = workersList.Items.Count - 1;
        }
    }
}