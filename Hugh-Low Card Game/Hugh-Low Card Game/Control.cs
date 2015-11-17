using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Low_Card_Game
{
    class Control
    {
        static Deck base_deck;
        static bool tie = false;

        public static void SettingUp()
        {
            base_deck = new Deck(13, 4);
            base_deck.Shuffle();
        }

        public static void NewPlayers(Player pPlayer1, Player pPlayer2, string pPlayerName1 = "Anonymous", string pPlayerName2 = "Anonymous")
        {
            Console.Write("1st Player's Name : ");
            pPlayerName1 = Console.ReadLine();
            Console.Write("2nd Player's Name : ");
            pPlayerName2 = Console.ReadLine();
            pPlayer1.Name = pPlayerName1;
            pPlayer2.Name = pPlayerName2;
        }

        public static void GivePlayerADeck(Player pPlayer1, Player pPlayer2)
        {
            for (int i = 0; i < 26; i++)
            {
                pPlayer1.PlayingDeck.Cards.Add(base_deck.Cards[i]);
                pPlayer2.PlayingDeck.Cards.Add(base_deck.Cards[i + 26]);
            }
        }

        public static void PlayerWinTurn(Player pPlayer, int NumberofCards = 1)
        {
            pPlayer.Count += (NumberofCards) * 2;
            if (tie) pPlayer.Count += 2;
            Console.WriteLine("[Winner = " + pPlayer.Name + "] Gots " + (NumberofCards * 2) + " Cards");
        }

        public static void TieTurn(Player pPlayer1, Player pPlayer2)
        {
            Console.WriteLine("[ReShuffle]");
            pPlayer1.PlayingDeck.Shuffle();
            {
                pPlayer2.PlayingDeck.Shuffle();
            }
            tie = true;
        }

        public static void RemovePlayerCards(Player pPlayer1, Player pPlayer2, int range)
        {
            int LastCard = pPlayer1.PlayingDeck.Cards.Count - 1;
            pPlayer1.PlayingDeck.Cards.RemoveRange(LastCard - range + 1, range);
            pPlayer2.PlayingDeck.Cards.RemoveRange(LastCard - range + 1, range);
        }

        public static int CompareCardDeck(Player pPlayer1, Player pPlayer2)
        {
            tie = false;
            if (pPlayer1.PlayingDeck.Cards.Count == 0)
            {
                Console.WriteLine("---[Both Players Have No Card]---");
                return -1;
            }
            int LastCard = pPlayer1.PlayingDeck.Cards.Count - 1;
            int pPlayer1_last = pPlayer1.PlayingDeck.Cards[LastCard].Value;
            int pPlayer2_last = pPlayer2.PlayingDeck.Cards[LastCard].Value;
            Console.WriteLine("[" + pPlayer1.Name + "] Has " + pPlayer1.PlayingDeck.Cards[LastCard], -30);
            Console.WriteLine("[" + pPlayer2.Name + "] Has " + pPlayer2.PlayingDeck.Cards[LastCard]);
            if (pPlayer1.PlayingDeck.Cards.Count == 1 && pPlayer1.PlayingDeck.Cards[LastCard].Value == pPlayer2.PlayingDeck.Cards[LastCard].Value) // No longer be playing
            {
                Console.WriteLine("[Both Players Cards Are Same]");
                return -1;
            }
            if (pPlayer1_last == pPlayer2_last)
            {
                bool Continue_Game = true;
                for (int i = 0; i <= LastCard; i++)
                {
                    for (int j = 0; j <= LastCard; j++)
                    {
                        if (pPlayer1.PlayingDeck.Cards[i].Value > pPlayer2.PlayingDeck.Cards[j].Value)
                        {
                            Continue_Game = false;
                        }
                        else
                        {
                            Continue_Game = true;
                        }
                    }
                }
                if (!Continue_Game)
                {
                    Console.WriteLine("= [" + pPlayer1.Name + "] Card Deck Is Containing : ");
                    pPlayer1.PlayingDeck.ViewCardsinDeck();
                    Console.WriteLine("= [" + pPlayer2.Name + "] Card Deck Is Containing : ");
                    pPlayer2.PlayingDeck.ViewCardsinDeck();
                    return -1;
                }
                int NumberFromLastCard = pPlayer1_last;
                if (NumberFromLastCard > LastCard)
                {

                    NumberFromLastCard = LastCard;

                }
                Console.WriteLine("[" + pPlayer1.Name + "] Has " + pPlayer1.PlayingDeck.Cards[NumberFromLastCard]);
                Console.WriteLine("[" + pPlayer2.Name + "] Has " + pPlayer2.PlayingDeck.Cards[NumberFromLastCard]);
                int pPlayer1_fromlast = pPlayer1.PlayingDeck.Cards[NumberFromLastCard].Value;
                int pPlayer2_fromlast = pPlayer2.PlayingDeck.Cards[NumberFromLastCard].Value;
                if (pPlayer1_fromlast < pPlayer2_fromlast)
                {
                    PlayerWinTurn(pPlayer1, NumberFromLastCard);
                    RemovePlayerCards(pPlayer1, pPlayer2, NumberFromLastCard);
                    return 1;
                }
                else if (pPlayer1_fromlast > pPlayer2_fromlast)
                {
                    PlayerWinTurn(pPlayer2, NumberFromLastCard);
                    RemovePlayerCards(pPlayer1, pPlayer2, NumberFromLastCard);
                    return 2;
                }
                else
                {
                    TieTurn(pPlayer1, pPlayer2);
                    return 0;
                }
            }
            // Player 1 WIN
            else if (pPlayer1_last < pPlayer2_last)
            {
                PlayerWinTurn(pPlayer1);
                RemovePlayerCards(pPlayer1, pPlayer2, 1);
                return 1;
            }
            // Player 2 WIN
            else if (pPlayer1_last > pPlayer2_last)
            {
                PlayerWinTurn(pPlayer2);
                RemovePlayerCards(pPlayer1, pPlayer2, 1);
                return 2;
            }
            return -1;
        }

        public static void FinishedPlaying(Player pPlayer1, Player pPlayer2)
        {
            Console.WriteLine("");
            string WinningMSG = "=== [Winner Is : ";
            if (pPlayer1.Count > pPlayer2.Count) WinningMSG += pPlayer1.Name;
            else if (pPlayer2.Count > pPlayer1.Count) WinningMSG += pPlayer2.Name;
            else WinningMSG += "NO ONE";
            WinningMSG += "] ===";
            Console.WriteLine(WinningMSG);
        }
    }

}
