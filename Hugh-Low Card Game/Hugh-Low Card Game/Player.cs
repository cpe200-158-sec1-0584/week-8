using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Low_Card_Game
{
    class Player
    {
        private Deck _playingdeck;
        private int _count;
        private string _name;
        private int order = 0;

        public Deck PlayingDeck
        {
            get { return _playingdeck; }
            set { _playingdeck = value; }
        }
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Order
        {
            get { return order; }
            set { order = value; }
        }

        public Player(int pOrder = 0, string pName = "Anonymous")
        {
            PlayingDeck = new Deck();
            Count = 0;
            Name = pName;
            Order = pOrder;
        }

        public void ShowPlayerProperties()
        {
            Console.WriteLine("[" + Name + "] Has [" + PlayingDeck.Cards.Count + " Card(s) In Deck] [" + Count + " Winning Card(s)]");
        }
    }
}
