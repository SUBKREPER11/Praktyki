using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Przyjęcie
{
    public partial class Form1 : Form
    {
        dinnerParty DinnerParty;
        public Form1()
        {
            InitializeComponent();
            DinnerParty = new dinnerParty() { NumberOfPeople = 5 };
            DinnerParty.CalculateCostOfDecorations(false);
            DinnerParty.SetHealthyOption(true);
            DisplayDinnerPartyCost();
        }

        private void DisplayDinnerPartyCost()
        {
            decimal Cost = DinnerParty.CalculateCost(checkBox1.Checked);
            label3.Text = Cost.ToString("c");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DinnerParty.CalculateCostOfDecorations(checkBox1.Checked);
            DisplayDinnerPartyCost();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            DinnerParty.SetHealthyOption(checkBox2.Checked);
            DisplayDinnerPartyCost();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            DinnerParty.NumberOfPeople = (int)numericUpDown1.Value;
            DisplayDinnerPartyCost();
        }
    }
}
