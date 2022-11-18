using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animacja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (Visible)
            {
                for (int c = 0; c <= 254 && Visible; c++)
                {
                    button1.BackColor = Color.FromArgb(c, 255 - c, c);
                    this.BackColor = Color.FromArgb(c, 255 - c, c);
                    button1.ForeColor = Color.FromArgb(c, 255 - c, c);
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(3);
                }
                for (int c = 254; c >= 0 && Visible; c--)
                {
                    button1.BackColor = Color.FromArgb(c, 255 - c, c);
                    this.BackColor = Color.FromArgb(c, 255 - c, c);
                    button1.ForeColor = Color.FromArgb(c, 255 - c, c);
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(3);
                }
            }
        }
    }
}
