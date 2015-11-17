using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Low_Card_Game
{
    class Deck
    {
        public List<Card> Cards;

        public Deck()
        {
            Cards = new List<Card>();
        }

        public Deck(int pValue = 13, int pSuit = 4) : this()
        {

            for (int i = 0; i < pValue; i++)
            {
                for (int j = 0; j < pSuit; j++)
                {
                    Cards.Add(new Card { Value = i + 1, Suit = j + 1 });
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                var j = random.Next(i, Cards.Count);
                var temp = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = temp;
            }
        }

        public void ViewCardsinDeck()
        {
            foreach (Card aCard in this.Cards)
            {
                Console.WriteLine(aCard);
            }
        }
    }
}
