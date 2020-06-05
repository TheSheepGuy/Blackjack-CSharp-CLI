using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack_CSharp_CLI
{
    class Card
    {
        public int Value { get; set; }
        public string Suit { get; set; }
        public bool Revealed { get; set; }

        public Card(int value, string suit, bool revealed)
        {
            Value = value;
            Suit = suit;
            Revealed = revealed;
        }

        public string GetLabel()
        {
            return Value switch
            {
                0 => "A",
                11 => "J",
                12 => "Q",
                13 => "K",
                _ => Value.ToString(),
            };
        }
        public string GetColour()
        {
            return Suit switch
            {
                "diamond" => "red",
                "heart" => "red",
                "club" => "black",
                "spade" => "black",
                // Default not needed, since there can only be those four suits.
            };
        }
    }
}
