using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack_CSharp_CLI
{
    class COM : Player
    {
        public int MaxHitWillingness;

        public COM(List<Card> givenCards) : base(givenCards) { }
        public override bool WillHit()
        {
            // The COM will hit as long as their TotalValue is less than or equal to their willingness.
            // This is an extremelly simple AI and doesn't take the other players' decks into account.
            return TotalValue <= MaxHitWillingness;
        }
    }
}
