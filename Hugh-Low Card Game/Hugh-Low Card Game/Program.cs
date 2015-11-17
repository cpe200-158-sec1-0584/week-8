using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Low_Card_Game
{
    class Program
    {
        static void Main(string[] args)
        {

            Player player1 = new Player(1);
            Player player2 = new Player(2);
            Control.SettingUp();
            Control.NewPlayers(player1, player2);
            Control.GivePlayerADeck(player1, player2);

            Console.WriteLine("");
            Console.WriteLine("START GAME");

            int result = 0;
            int turn = 1;
            do
            {
                Console.WriteLine("***Turn " + turn + "***");
                result = Control.CompareCardDeck(player1, player2);
                player1.ShowPlayerProperties();
                player2.ShowPlayerProperties();
                if (player1.PlayingDeck.Cards.Count == 0)
                {
                    Console.WriteLine("---[Both Players Have No Card]---");
                    break;
                }
                Console.WriteLine("");
                ++turn;

            } while (result != -1);
            Control.FinishedPlaying(player1, player2);
            Console.ReadKey();
        }
    }
}
