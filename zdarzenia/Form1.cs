using System;
using System.Windows.Forms;

namespace zdarzenia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Właśnie kliknąłeś formularz.");
        }
        private void SaySomething(object sender, EventArgs e)
        {
            MessageBox.Show("Coś");
        }
        private void SaySomethingElse(object sender, EventArgs e)
        {
            MessageBox.Show("Coś INNEGO!!!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Click += new EventHandler(SaySomething);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Click += new EventHandler(SaySomethingElse);
        }
    }
}
