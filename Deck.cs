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
