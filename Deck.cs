using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
                ContainingCards.Add(new Card(clubLoop, "heart", false));
            }
            for (int spadeLoop = 1; spadeLoop < 14; spadeLoop++)
            {
                ContainingCards.Add(new Card(spadeLoop, "heart", false));
            }
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
        public void PutCard(Card toPut)
        {
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
    }
}
