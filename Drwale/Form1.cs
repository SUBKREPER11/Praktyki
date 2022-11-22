using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drwale
{
    public enum Flapjack
    {
        Chrupkiego,
        Wilgotnego,
        Rumianego,
        Bananowego,
    }
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private Queue<Lumberjack> breakfastLine = new Queue<Lumberjack>();
        private void addLumberjack_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(name.Text)) return;
            breakfastLine.Enqueue(new Lumberjack(name.Text));
            name.Text = "";
            RedrawList();
        }

        private void RedrawList()
        {
            int number = 1;
            Line.Items.Clear();
            foreach (Lumberjack lumberjack in breakfastLine)
            {
                Line.Items.Add(number + ". " + lumberjack.Name);
                number++;
            }
            if(breakfastLine.Count == 0)
            {
                groupBox1.Enabled = false;
                nextInLine.Text = "";
            }
            else
            {
                groupBox1.Enabled = true;
                Lumberjack currentLumberjack = breakfastLine.Peek();
                nextInLine.Text = currentLumberjack.Name + " ma "
                    + currentLumberjack.FlapjackCount + " naleśników";
            }
            
        }

        private void addFlapjacks_Click(object sender, EventArgs e)
        {
            Flapjack food;
            if (crispy.Checked == true)
                food = Flapjack.Chrupkiego;
            else if (soggy.Checked == true)
                food = Flapjack.Wilgotnego;
            else if (browned.Checked == true)
                food = Flapjack.Rumianego;
            else
                food = Flapjack.Bananowego;

            Lumberjack currentLumberjack = breakfastLine.Peek();
            currentLumberjack.TakeFlapjacks(food, (int)howMany.Value);
            RedrawList();
        }

        private void nextLumberjack_Click(object sender, EventArgs e)
        {
            if (breakfastLine.Count == 0) return;
            Lumberjack nextLumberjack = breakfastLine.Dequeue();
            nextLumberjack.EatFlapjacks();
            nextInLine.Text = "";
            RedrawList();
        }
    }
    class Lumberjack
    {
        private string name;
        public string Name { get { return name; } }
        private Stack<Flapjack> meal;

        public Lumberjack(string name)
        {
            this.name = name;
            meal = new Stack<Flapjack>();
        }
        public int FlapjackCount { get { return meal.Count; } }
        public void TakeFlapjacks(Flapjack food, int HowMany)
        {
            for (int i = 0; i < HowMany; i++)
            {
                meal.Push(food);
            }
        }
        public void EatFlapjacks()
        {
            Console.WriteLine(name + " je naleśniki");
            while (meal.Count > 0)
            {
                Console.WriteLine(name + " zjadł " + meal.Pop().ToString().ToLower() + " naleśnika");
            }
        }
    }
}
