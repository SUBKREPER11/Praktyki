using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace Ryby__gra_karciana___XAML_
{
    class Game
    {
        private List<Player> players;
        private Dictionary<Values, Player> books;
        private Deck stock;
        private ScrollViewer textBlockOnForm;

        public Game(string playerName, IEnumerable<string> opponentNames, ScrollViewer textBlockOnForm)
        {
            Random random = new Random();
            this.textBlockOnForm = textBlockOnForm;
            players = new List<Player>();
            players.Add(new Player(playerName, random, textBlockOnForm));
            foreach (string player in opponentNames)
            {
                players.Add(new Player(player, random, textBlockOnForm));
            }
            books = new Dictionary<Values, Player>();
            stock = new Deck();
            Deal();
            players[0].SortHand();

        }

        private void Deal()
        {
            stock.Shuffle();
            foreach (Player player in players)
            {
                for (int i = 0; i < 5; i++)
                {
                    player.TakeCard(stock.Deal());
                }
            }
            foreach (Player player in players)
            {
                PullOutBooks(player);
            }
        }

        public bool PlayOneRound(int selectedPlayerCard)
        {
            Values value = players[0].Peek(selectedPlayerCard).Value;

            for (int i = 0; i < players.Count; i++)
            {
                if (i == 0)
                    players[0].AskForACard(players, 0, stock, value);
                else
                    players[i].AskForACard(players, i, stock);
                if (PullOutBooks(players[i]))
                {
                    textBlockOnForm.Content += players[i].Name + " dobrał nową rękę" + Environment.NewLine;
                    int card = 1;
                    while (card <= 5 && stock.Count > 0)
                    {
                        players[i].TakeCard(stock.Deal());
                        card++;
                    }
                }
                players[0].SortHand();
                if (stock.Count == 0)
                {
                    textBlockOnForm.Content = "Nie ma więcej kart. Koniec gry!" + Environment.NewLine;
                    return true;
                }
            }
            return false;
        }

        public bool PullOutBooks(Player player)
        {
            foreach (Values value in player.PullOutBooks())
            {
                books.Add(value, player);
            }
            if (player.CardCount == 0)
                return true;
            return false;
        }

        public string DescribeBooks()
        {
            string description = "";
            foreach (Values value in books.Keys)
            {
                description += books[value].Name + " na grupę " + Card.Plural(value) + "." + Environment.NewLine;
            }
            return description;
        }

        public string GetWinnerName()
        {
            Dictionary<string, int> winners = new Dictionary<string, int>();
            foreach (Values value in books.Keys)
            {
                string name = books[value].Name;
                if (winners.ContainsKey(name))
                    winners[name]++;
                else
                    winners.Add(name, 1);
            }
            int mostBooks = 0;
            foreach (string name in winners.Keys)
                if (winners[name] > mostBooks)
                    mostBooks = winners[name];
            bool tie = false;
            string winnerList = "";
            foreach (string name in winners.Keys)
                if (winners[name] == mostBooks)
                {
                    if (!String.IsNullOrEmpty(winnerList))
                    {
                        winnerList += " i ";
                        tie = true;
                    }
                    winnerList += name;
                }
            winnerList += " z " + mostBooks + " grupy";
            if (tie)
                return "Remis między " + winnerList;
            else
                return winnerList;
        }

        public IEnumerable<string> GetPlayerCardNames()
        {
            return players[0].GetCardNames();
        }

        public string DescribePlayerHands()
        {
            string description = "";
            for (int i = 0; i < players.Count; i++)
            {
                description += players[i].Name + " ma " + players[i].CardCount;
                if (players[i].CardCount == 1)
                    description += " karta." + Environment.NewLine;
                else
                    description += " kart." + Environment.NewLine;
            }
            description += "Stock ma " + stock.Count;
            return description;
        }
    }
}
