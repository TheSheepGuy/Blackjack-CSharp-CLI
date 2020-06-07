using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack_CSharp_CLI
{
    class Player : Deck
    {
        public bool IsBust { get; set; }

        public Player() : base() { }
        public Player(List<Card> givenCards) : base(givenCards) { }
        public bool CheckBust()
        {
            if (TotalValue > 21)
            {
                for (int i = 0; i < ContainingCards.Count; i++)
                {
                    if (ContainingCards[i].Label == "A" && ContainingCards[i].Value == 11)
                    {
                        ContainingCards[i].Value = 1;
                        TotalValue -= 10;
                        if (TotalValue > 21) continue;
                        else break;
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
                Console.Write("\nWould you like to hit or hold, player" + " " + (playerNumber+1).ToString() + " [hi/ho]? ");
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
