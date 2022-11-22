﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Talie
{
    public partial class Form1 : Form
    {
        Deck deck1;
        Deck deck2;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            ResetDeck(1);
            ResetDeck(2);
            RedrawDeck(1);
            RedrawDeck(2);
        }

        private void ResetDeck(int deckNumber)
        {
            if (deckNumber == 1)
            {
                int numberOfCards = random.Next(1, 11);
                deck1 = new Deck(new Card[] { });
                for (int i = 0; i < numberOfCards; i++)
                    deck1.Add(new Card((Suits)random.Next(4), (Values)random.Next(1, 14)));
                deck1.Sort();
            } else
                deck2 = new Deck();
        }

        private void moveToDeck2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex >= 0)
                if (deck1.Count > 0)
                {
                    deck2.Add(deck1.Deal(listBox1.SelectedIndex));
                }
            RedrawDeck(1);
            RedrawDeck(2);
        }

        private void moveToDeck1_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
                if (deck2.Count > 0)
                {
                    deck1.Add(deck2.Deal(listBox2.SelectedIndex));
                }
            RedrawDeck(1);
            RedrawDeck(2);

        }

        private void reset1_Click(object sender, EventArgs e)
        {
            ResetDeck(1);
            RedrawDeck(1);
        }

        private void reset2_Click(object sender, EventArgs e)
        {
            ResetDeck(2);
            RedrawDeck(2);
        }

        private void shuffle1_Click(object sender, EventArgs e)
        {
            deck1.Shuffle();
            RedrawDeck(1);
        }

        private void shuffle2_Click(object sender, EventArgs e)
        {
            deck2.Shuffle();
            RedrawDeck(2);
        }

        public void RedrawDeck(int DeckNumer)
        {
            if(DeckNumer == 1)
            {
                listBox1.Items.Clear();
                foreach (string cardName in deck1.GetCardNames())
                    listBox1.Items.Add(cardName);
                label1.Text = "Zestaw 1. (" + deck1.Count + " kart)";
            }
            else
            {
                listBox2.Items.Clear();
                foreach (string cardName in deck2.GetCardNames())
                    listBox2.Items.Add(cardName);
                label2.Text = "Zestaw 2. (" + deck2.Count + " kart)";
            }
        }
    }
    class Deck
    {
        private List<Card> cards;
        private Random random = new Random();

        public Deck()
        {
            cards = new List<Card>();
            for (int suit = 0; suit <= 3; suit++)
                for (int value = 1; value <= 13; value++)
                    cards.Add(new Card((Suits)suit, (Values)value));
        }
        public Deck (IEnumerable<Card> initialCards)
        {
            cards = new List<Card>(initialCards);
        }
        public int Count { get { return cards.Count; } }
        public void Add(Card cardToAdd)
        {
            cards.Add(cardToAdd);
        }
        public Card Deal(int index)
        {
            Card CardToDeal = cards[index];
            cards.RemoveAt(index);
            return CardToDeal;
        }
        public void Shuffle()
        {
            //Tasowanie kart
            List<Card> NewCards = new List<Card>();
            while (cards.Count > 0)
            {
                int CardToMove = random.Next(cards.Count);
                NewCards.Add(cards[CardToMove]);
                cards.RemoveAt(CardToMove);
            }
            cards = NewCards; 
        }
        public IEnumerable<string> GetCardNames()
        {
            //Zwaracanie tablicy łańcuchów
            string[] CardNames = new string[cards.Count];
            for (int i = 0; i < cards.Count; i++)
                CardNames[i] = cards[i].Name;
            return CardNames;
        }
        public void Sort()
        {
            cards.Sort(new CardComparer_bySuit());
        }
    }
    class CardComparer_bySuit : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            if (x.Suit > y.Suit)
                return 1;
            if (x.Suit < y.Suit)
                return -1;
            if (x.Value > y.Value)
                return 1;
            if (x.Value < y.Value)
                return -1;
            return 0;
        }
    }
}
