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
            return TotalValue > 21;
        }
        public virtual bool WillHit()
        {
            string choice;
            while (true)
            {
                Console.WriteLine("Would you like to hit or hold? [hi/ho]");
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
