using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wyścig
{
    public class Brownhound
    {
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random MyRandom;
        int[] tab = { 1, 2, 3, 6 };

        public bool Run()
        {
            MyPictureBox.Left += tab[MyRandom.Next(tab.Length)];

            if (MyPictureBox.Left >= RacetrackLength)
            {
                return true;
            }
            else
                return false;
        }

        public void TakeStartingPosition()
        {
            MyPictureBox.Left = StartingPosition;
        }

    }
}