using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace LOOP
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            String name = "Quentin";
            int x = 3;
            x = x * 17;
            double d = Math.PI / 2;
            myLabel.Text = "nazwa to" + name
            + "\nx jest równe " + x
            + "\nd jest równe" + d;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            int x = 5;
            if(x == 10)
            {
                myLabel.Text = "x musi być równe 10";
            }
            else
            {
                myLabel.Text = "x nie jest równe 10";
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            int someValue = 4;
            string name = "Eren Jaeger";
            if((someValue == 3) && (name.Equals("Levi Ackerman")))
            {
                myLabel.Text = "someValue jest równe 3 i name jest równe Levi Ackerman";
            }
            myLabel.Text = "ten wiersz jest wykonywany bez względu na warunki";
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            while (count < 10)
            {
                count = count + 1;
            }
            for (int i = 0; i < 5; i++)
            {
                count = count - 1;
            }
            myLabel.Text = "Odpowiedź brzmi " + count;
        }
    }
}
