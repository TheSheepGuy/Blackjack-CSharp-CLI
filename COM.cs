using System;
using System.Collections.Generic;
using System.Threading;

namespace Blackjack_CSharp_CLI
{
    class COM : Player
    {
        public int MaxHitWillingness;

        public COM() : base()
        {
            Random rand = new Random();
            switch (rand.Next(4))
            {
                case 0:
                    MaxHitWillingness = 14;
                    break;
                case 1:
                    MaxHitWillingness = 16;
                    break;
                case 2:
                    MaxHitWillingness = 18;
                    break;
                case 3:
                    MaxHitWillingness = 20;
                    break;
            }
        }
        public COM(List<Card> givenCards) : base(givenCards)
        {
            Random rand = new Random();
            switch (rand.Next(4))
            {
                case 0:
                    MaxHitWillingness = 14;
                    break;
                case 1:
                    MaxHitWillingness = 16;
                    break;
                case 2:
                    MaxHitWillingness = 18;
                    break;
                case 3:
                    MaxHitWillingness = 20;
                    break;
            }
        }
        public override bool WillHit(int comNumber)
        {
            // The COM will hit as long as their TotalValue is less than or equal to their willingness.
            // This is an extremelly simple AI and doesn't take the other players' decks into account.
            Console.Write("\nWould you like to hit or hold, player" + " " + (comNumber + 1).ToString() + " [hi/ho]? ");
            Thread.Sleep(750);
            if (TotalValue <= MaxHitWillingness)
            {
                Console.Write("h");
                Thread.Sleep(250);
                Console.Write("i");
                Thread.Sleep(250);
                Console.WriteLine();
                return true;
            }
            else
            {
                Console.Write("h");
                Thread.Sleep(250);
                Console.Write("o");
                Thread.Sleep(250);
                Console.WriteLine();
                return false;
            }
        }
    }
}
