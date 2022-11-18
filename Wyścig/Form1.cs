using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wyścig
{
    public partial class Form1 : Form
    {
        Brownhound[] BrownhoundArray = new Brownhound[4];
        Guy[] GuyArray = new Guy[3];
        Random Randomizer = new Random();
        public Form1()
        {
            InitializeComponent();
            BrownhoundArray[0] = new Brownhound()
            {
                MyPictureBox = pictureDog1,
                StartingPosition = pictureDog1.Left,
                RacetrackLength = torWyscigowy.Width - pictureDog1.Width,
                MyRandom = Randomizer
            };

            BrownhoundArray[1] = new Brownhound()
            {
                MyPictureBox = pictureDog2,
                StartingPosition = pictureDog2.Left,
                RacetrackLength = torWyscigowy.Width - pictureDog2.Width,
                MyRandom = Randomizer
            };
            BrownhoundArray[2] = new Brownhound()
            {
                MyPictureBox = pictureDog3,
                StartingPosition = pictureDog3.Left,
                RacetrackLength = torWyscigowy.Width - pictureDog3.Width,
                MyRandom = Randomizer
            };
            BrownhoundArray[3] = new Brownhound()
            {
                MyPictureBox = pictureDog4,
                StartingPosition = pictureDog4.Left,
                RacetrackLength = torWyscigowy.Width - pictureDog4.Width,
                MyRandom = Randomizer
            };
            GuyArray[0] = new Guy()
            {
                Name = "Saimon",
                Cash = 100,
                MyBet = null,
                MyRadioButton = saimonButton,
                MyLabel = saimonBetLabel

            };
            GuyArray[1] = new Guy()
            {
                Name = "Eren",
                Cash = 150,
                MyBet = null,
                MyRadioButton = erenButton,
                MyLabel = erenBetLabel

            };
            GuyArray[2] = new Guy()
            {
                Name = "Bob",
                Cash = 125,
                MyBet = null,
                MyRadioButton = bobButton,
                MyLabel = bobBetLabel
            };
            for (int i = 0; i < 3; i++)
            {
                GuyArray[i].ClearBet();
                GuyArray[i].UpdateLabels();
            }
            nameLabel.Text = "Saimon";
            minimumBetLabel.Text = "Minimalna zakład: " + numericBetAmout.Minimum + " zł";
        }




        private void button1_Click(object sender, EventArgs e)
        {

            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            for (int i = 0; i < 4; i++)
            {
                if (BrownhoundArray[i].Run())
                {
                    timer1.Stop();
                    int NumerPsa = i + 1;
                    MessageBox.Show("Steve numer " + NumerPsa + " zwycięrzył");

                    for (int k = 0; k < 4; k++)
                    {
                        BrownhoundArray[k].TakeStartingPosition();
                    }

                    for (int j = 0; j < 3; j++)
                    {
                        GuyArray[j].Collect(NumerPsa);
                        GuyArray[j].ClearBet();
                        GuyArray[j].UpdateLabels();
                    }
                    groupBox1.Enabled = true;
                }
            }
        }

        private void janekButton_CheckedChanged(object sender, EventArgs e)
        {
            if (saimonButton.Checked)
            {
                nameLabel.Text = "Saimon";
            }
        }

        private void bartekButton_CheckedChanged(object sender, EventArgs e)
        {
            if (erenButton.Checked)
            {
                nameLabel.Text = "Eren";
            }
        }

        private void arekButton_CheckedChanged(object sender, EventArgs e)
        {
            if (bobButton.Checked)
            {
                nameLabel.Text = "Bob";
            }
        }

        private void betButton_Click(object sender, EventArgs e)
        {
            if (saimonButton.Checked)
                GuyArray[0].PlaceBet((int)numericBetAmout.Value, (int)numericDog.Value);
            if (erenButton.Checked)
                GuyArray[1].PlaceBet((int)numericBetAmout.Value, (int)numericDog.Value);
            if (bobButton.Checked)
                GuyArray[2].PlaceBet((int)numericBetAmout.Value, (int)numericDog.Value);

            for (int i = 0; i < 3; i++)
            {
                GuyArray[i].UpdateLabels();
            }
        }
    }
}