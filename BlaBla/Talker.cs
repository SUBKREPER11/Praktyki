using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace BlaBla
{
    class Talker
    {
        public static int TolkToMi(string thingTosay, int numberOfTimes)
        {
            string finalString = "";
            for(int count = 1; count <= numberOfTimes; count++)
            {
                finalString = finalString + thingTosay + "\n";
            }
            MessageBox.Show(finalString);
            return finalString.Length;
        }
    }
}
