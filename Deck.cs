using System;
using System.Collections.Generic;

namespace Blackjack_CSharp_CLI
{
    class Deck
    {
        public List<Card> ContainingCards { get; set; }
        public int TotalValue { get; set; }

        public Deck()
        {
            ContainingCards = new List<Card>();
            // Add all 52 standard cards. Each for loop does all cards in each suite.
            for (int diamondLoop = 1; diamondLoop < 14; diamondLoop++)
            {
                ContainingCards.Add(new Card(diamondLoop, "diamond", false));
            }
            for (int heartLoop = 1; heartLoop < 14; heartLoop++)
            {
                ContainingCards.Add(new Card(heartLoop, "heart", false));
            }
            for (int clubLoop = 1; clubLoop < 14; clubLoop++)
            {
                ContainingCards.Add(new Card(clubLoop, "club", false));
            }
            for (int spadeLoop = 1; spadeLoop < 14; spadeLoop++)
            {
                ContainingCards.Add(new Card(spadeLoop, "spade", false));
            }
            TotalValue = 380;
        }
        public Deck(List<Card> initialCards)
        {
            ContainingCards = initialCards;
            TotalValue = 0;
            foreach (Card currentCard in initialCards)
            {
                TotalValue += currentCard.Value;
            }
        }
        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = ContainingCards.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                Card temp = ContainingCards[i];
                ContainingCards[i] = ContainingCards[j];
                ContainingCards[j] = temp;
            }
        }
        public Card RemoveCard()
        {
            Card toReturn = ContainingCards[0];
            TotalValue -= toReturn.Value;
            ContainingCards.RemoveAt(0);
            return toReturn;
        }
        public void PutCard(Card toPut, bool reveal = false)
        {
            toPut.Revealed = reveal;
            ContainingCards.Add(toPut);
            TotalValue += toPut.Value;
        }
        public void RevealAll()
        {
            foreach (Card currentCard in ContainingCards)
            {
                currentCard.Revealed = true;
            }
        }
        public void DrawDeck()
        {
            for (int currentCardNo = 0; currentCardNo < ContainingCards.Count; currentCardNo++)
            {
                if (ContainingCards[currentCardNo].Revealed == false)
                {
                    Console.WriteLine("??");
                    continue;
                }
                // Save the colour of the suite.
                ConsoleColor suiteColour = ContainingCards[currentCardNo].GetColour();
                // If the suite colour is black, then background should turn white to make it visible.
                if (suiteColour == ConsoleColor.Black)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = suiteColour;
                }
                else
                {
                    Console.ForegroundColor = suiteColour;
                }
                Console.Write(ContainingCards[currentCardNo].Suit + ContainingCards[currentCardNo].Label);
                Console.ResetColor();
                Console.Write("  ");
            }
            Console.ResetColor();
        }
    }
}
