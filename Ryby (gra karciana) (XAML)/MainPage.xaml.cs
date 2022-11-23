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
//using System.Windows.Forms;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace Ryby__gra_karciana___XAML_
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
        private Game game;

        //private void buttonStart_Click(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(textName.Text))
        //    {
        //        //MessageBox.Show("Wpisz swoje imię", "Nie można jeszcze rozpocząć gry");
        //        return;
        //    }
        //    game = new Game(textName.Text, new List<string> { "Le", "Vi" }, textProgress);
        //    buttonStart.IsEnabled = false;
        //    textName.IsEnabled = false;
        //    buttonAsk.IsEnabled = true;
        //    UpdateForm();
        //}

        private void UpdateForm()
        {
            listHand.Items.Clear();
            foreach (string cardName in game.GetPlayerCardNames())
                listHand.Items.Add(cardName);
            textBooks.Content = game.DescribeBooks();
           // textBooks.ScrollToCaret();
            textProgress.Content += game.DescribePlayerHands();
           // textProgress.SelectionStart = textProgress.Content.Length;
           // textProgress.ScrollToCaret();
        }

        //private void buttonAsk_Click(object sender, EventArgs e)
        //{
        //    textProgress.Content = "";
        //    if (listHand.SelectedIndex < 0)
        //    {
        //        //MessageBox.Show("Proszę wybrać kartę");
        //        return;
        //    }
        //    if (game.PlayOneRound(listHand.SelectedIndex))
        //    {
        //        textProgress.Content += "Zwycięzcą jest... " + game.GetWinnerName();
        //        textBooks.Content = game.DescribeBooks();
        //        textBooks.ScrollToCaret();
        //        buttonAsk.IsEnabled = false;
        //    }
        //    else
        //        UpdateForm();
        //}

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(textName.Text))
            {
                //MessageBox.Show("Wpisz swoje imię", "Nie można jeszcze rozpocząć gry");
                return;
            }
            game = new Game(textName.Text, new List<string> { "Le", "Vi" },textProgress);
            buttonStart.IsEnabled = false;
            textName.IsEnabled = false;
            buttonAsk.IsEnabled = true;
            UpdateForm();
        }

        private void buttonAsk_Click(object sender, RoutedEventArgs e)
        {
            textProgress.Content = "";
            if (listHand.SelectedIndex < 0)
            {
                //MessageBox.Show("Proszę wybrać kartę");
                return;
            }
            if (game.PlayOneRound(listHand.SelectedIndex))
            {
                textProgress.Content += "Zwycięzcą jest... " + game.GetWinnerName();
                textBooks.Content = game.DescribeBooks();
         //       textBooks.ScrollToCaret();
                buttonAsk.IsEnabled = false;
            }
            else
                UpdateForm();
        }

        private void listHand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
