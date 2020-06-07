using System;
using System.Collections.Generic;

namespace Blackjack_CSharp_CLI
{
    class Player : Deck
    {
        public Player() : base() { }
        public Player(List<Card> givenCards) : base(givenCards) { }
        public bool CheckBust()
        {
            // This is to implement the way that an ace can either be 11 or 1 depending on which is more convenient.
            // If the total value is above 21, check whether there's an ace that can be changed from 11 to 1.
            if (TotalValue > 21)
            {
                // Loop through each card to see whether it's an ace.
                foreach (Card currentCard in ContainingCards)
                {
                    // If it is, change it to a 1 in hope of now bringing the total to below 21.
                    if (currentCard.Label == "A" && currentCard.Value == 11)
                    {
                        currentCard.Value = 1;
                        TotalValue -= 10;
                        // If it's not over 21 anymore, there's no need to keep looping, so break.
                        if (TotalValue <= 21) break;
                    }
                }
            }
            return TotalValue > 21;
        }
        public virtual bool WillHit(int playerNumber)
        {
            string choice;
            while (true)
            {
                Console.Write("\nWould you like to hit or hold, player" + " " + (playerNumber + 1).ToString() + " [hi/ho]? ");
                choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "hi":
                    case "hit":
                        return true;
                    case "ho":
                    case "hold":
                        return false;
                    default:
                        Console.WriteLine("\nPlease enter either [hi]t or [ho]ld.");
                        continue;
                }
            }
        }
    }
}
