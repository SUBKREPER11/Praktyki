using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator_odległości
{
    public partial class Form1 : Form
    {
        int startingMileage;
        int endingMileage;
        double milesTraveled;
        double reinburseRate = .39;
        double amoutOwed;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startingMileage = (int)numericUpDown1.Value;
            endingMileage = (int)numericUpDown2.Value;
            if(startingMileage <= endingMileage)
            {
                milesTraveled = endingMileage - startingMileage;
                amoutOwed = milesTraveled * reinburseRate;
                label4.Text = amoutOwed.ToString() + " zł";
            }
            else
            {
                MessageBox.Show(
                    "Początkowy stan licznika musi być mniejszy niż końcowy",
                    "Nie mogę obliczć odległości");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(milesTraveled + " kilometrów", "Przebyta odległość");
        }
    }
}
