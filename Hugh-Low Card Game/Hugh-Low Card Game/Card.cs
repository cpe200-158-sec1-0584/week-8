using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Low_Card_Game
{
    class Card
    {
        private int _value;
        private int _suit;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public int Suit
        {
            get { return _suit; }
            set { _suit = value; }
        }

        public Card()
        {
            Value = 0;
            Suit = 0;
        }

        protected string[] suit = { "Clubs", "Diamonds", "Hearts", "Spades" };
        protected string[] face = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

        public override string ToString()
        {
            return " [" + face[Value - 1] + " Of " + suit[Suit - 1] + "] ";
        }
    }
}
