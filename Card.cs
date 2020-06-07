using System;

namespace Blackjack_CSharp_CLI
{
    class Card
    {
        public int Value { get; set; }
        public string Label { get; set; }
        public string suit;
        public string Suit
        {
            get
            {
                return suit switch
                {
                    "diamond" => "♦",
                    "heart" => "♥",
                    "club" => "♣",
                    "spade" => "♠",
                    // Default not needed, since there can only be those four suits.
                };
            }
            set { suit = value; }
        }
        public bool Revealed { get; set; }

        public Card(int number, string enteredSuit, bool revealed)
        {
            Suit = enteredSuit;
            Revealed = revealed;
            switch (number)
            {
                // Treat aces as 11 for now.
                case 1:
                    Value = 11;
                    Label = "A";
                    break;
                case 11:
                    Value = 10;
                    Label = "J";
                    break;
                case 12:
                    Value = 10;
                    Label = "Q";
                    break;
                case 13:
                    Value = 10;
                    Label = "K";
                    break;
                default:
                    Value = number;
                    Label = number.ToString();
                    break;
            }
        }

        public ConsoleColor GetColour()
        {
            return Suit switch
            {
                "♦" => ConsoleColor.Red,
                "♥" => ConsoleColor.Red,
                "♣" => ConsoleColor.Black,
                "♠" => ConsoleColor.Black,
                // Default not needed, since there can only be those four suits.
            };
        }
    }
}
