using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wyścig
{
    public class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;
        public RadioButton MyRadioButton;
        public Label MyLabel;


        public void UpdateLabels()
        {
            MyRadioButton.Text = Name + " ma " + Cash + "zł";
            if (MyBet != null)
                MyLabel.Text = MyBet.GetDescription();

        }

        public void ClearBet()
        {
            MyBet = new Bet() { Amount = 0, Dog = 0, Bettor = this };
        }

        public bool PlaceBet(int Amount, int DogToWin)
        {
            if (Cash >= Amount)
            {
                MyBet = new Bet() { Amount = Amount, Dog = DogToWin, Bettor = this };
                return true;
            }
            else return false;

        }

        public void Collect(int Winner)
        {
            Cash += MyBet.PayOut(Winner);
            UpdateLabels();
        }

    }
}