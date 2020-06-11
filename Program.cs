using System;
using System.Collections.Generic;

namespace Blackjack_CSharp_CLI
{
    class Program
    {
        public static void DrawTable(List<Player> players)
        {
            for (int currentPlayerNo = 0; currentPlayerNo < players.Count; currentPlayerNo++)
            {
                Console.WriteLine("\nPlayer " + (currentPlayerNo + 1).ToString());
                // Display all of the cards of the current player.
                players[currentPlayerNo].DrawDeck();
                Console.ResetColor();
            }
        }
        public static void DrawTable(List<COM> players)
        {
            for (int currentPlayerNo = 0; currentPlayerNo < players.Count; currentPlayerNo++)
            {
                Console.WriteLine("\nCOM " + (currentPlayerNo + 1).ToString());
                // Display all of the cards of the current player.
                players[currentPlayerNo].DrawDeck();
                Console.ResetColor();
            }
        }

        private static List<Card> PlayGame(Deck mainDeck, int noOfHumans, int noOfCOMs)
        {
            List<Player> humanPlayers = new List<Player>();
            List<COM> comPlayers = new List<COM>();
            // Add all human players.
            for (int human = 0; human < noOfHumans; human++)
            {
                // Give them an empty deck.
                humanPlayers.Add(new Player(new List<Card>()));
                // And now give them two cards from the main deck.
                humanPlayers[human].PutCard(mainDeck.RemoveCard());
                // Reveal the first card only.
                humanPlayers[human].ContainingCards[0].Revealed = true;
                humanPlayers[human].PutCard(mainDeck.RemoveCard());
            }
            // Add all COM players.
            for (int currentCOM = 0; currentCOM < noOfCOMs; currentCOM++)
            {
                comPlayers.Add(new COM(new List<Card>()));
                comPlayers[currentCOM].PutCard(mainDeck.RemoveCard());
                comPlayers[currentCOM].ContainingCards[0].Revealed = true;
                comPlayers[currentCOM].PutCard(mainDeck.RemoveCard());
            }


            int highestPlayer = 0, highestValue = 0;
            bool winnerHuman = true;
            for (int currentPlayer = 0; currentPlayer < humanPlayers.Count; currentPlayer++)
            {
                humanPlayers[currentPlayer].RevealAll();
                while (true)
                {
                    DrawTable(humanPlayers);
                    DrawTable(comPlayers);
                    if (humanPlayers[currentPlayer].WillHit(currentPlayer))
                    {
                        humanPlayers[currentPlayer].PutCard(mainDeck.RemoveCard(), true);
                        if (humanPlayers[currentPlayer].CheckBust())
                        {
                            DrawTable(humanPlayers);
                            DrawTable(comPlayers);
                            Console.WriteLine("You are bust! Press any key to continue to the next player.");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (humanPlayers[currentPlayer].TotalValue > highestValue)
                        {
                            highestValue = humanPlayers[currentPlayer].TotalValue;
                            highestPlayer = currentPlayer;
                            winnerHuman = true;
                        }
                        Console.WriteLine("Press any key to continue to the next player.");
                        Console.ReadKey();
                        break;
                    }
                }
            }
            for (int currentPlayer = 0; currentPlayer < comPlayers.Count; currentPlayer++)
            {
                comPlayers[currentPlayer].RevealAll();
                while (true)
                {
                    DrawTable(humanPlayers);
                    DrawTable(comPlayers);
                    if (comPlayers[currentPlayer].WillHit(currentPlayer))
                    {
                        comPlayers[currentPlayer].PutCard(mainDeck.RemoveCard(), true);
                        if (comPlayers[currentPlayer].CheckBust())
                        {
                            DrawTable(humanPlayers);
                            DrawTable(comPlayers);
                            Console.WriteLine("You are bust! Press any key to continue to the next player.");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (comPlayers[currentPlayer].TotalValue > highestValue)
                        {
                            highestValue = comPlayers[currentPlayer].TotalValue;
                            highestPlayer = currentPlayer;
                            winnerHuman = false;
                        }
                        Console.WriteLine("Press any key to continue to the next player.");
                        Console.ReadKey();
                        break;
                    }
                }
            }
            if (highestValue == 0)
            {
                Console.WriteLine("No-one won this game.");
            }
            else if (winnerHuman)
            {

                Console.WriteLine("The winner is player " + (highestPlayer + 1).ToString());
            }
            else
            {
                Console.WriteLine("The winner is COM " + (highestPlayer + 1).ToString());
            }

            // Collect all cards and put them in a deck that'll be returned.
            Deck toReturn = new Deck(new List<Card>());
            foreach (Player currentPlayer in humanPlayers)
            {
                toReturn.ContainingCards.AddRange(currentPlayer.ContainingCards);
            }
            foreach (COM currentCOM in comPlayers)
            {
                toReturn.ContainingCards.AddRange(currentCOM.ContainingCards);
            }
            return toReturn.ContainingCards;
        }

        static void Main(string[] args)
        {
            // Test whether the entered numbers are actually integers.
            int noOfHumans, noOfCOMs;
            try
            {
                if (!Int32.TryParse(args[0], out noOfHumans))
                {
                    Console.WriteLine("Please enter a number. You instead entered " + args[0]);
                    return;
                }
                else if (!Int32.TryParse(args[1], out noOfCOMs))
                {
                    Console.WriteLine("Please enter a number. You instead entered " + args[1]);
                    return;
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine("Please enter the number of human and COM players as arguments.\nFor example, to have 2 human and 1 COM players, enter 'blackjack 2 1'.");
                return;
            }

            Deck mainDeck = new Deck();
            mainDeck.Shuffle();

            // This is the normal gameplay loop.
            // Notice that to ensure that all cards stay in the game, any used cards get passed back into mainDeck.
            mainDeck.ContainingCards.AddRange(PlayGame(mainDeck, noOfHumans, noOfCOMs));
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("Would you like to play again? [y/N]");
                string choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "y":
                    case "yes":
                        mainDeck.ContainingCards.AddRange(PlayGame(mainDeck, noOfHumans, noOfCOMs));
                        break;
                    case "n":
                    case "no":
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("Please either type yes or no.");
                        break;
                }
            }
        }
    }
}
