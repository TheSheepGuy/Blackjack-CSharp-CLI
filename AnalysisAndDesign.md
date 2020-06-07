# Analysis

## Purpose

A blackjack clone being able to be played using the command line.

## Scope

* A basic design which will be used to implement the program.
* A build for Win x64 and Linux x64 targets.

## Boundaries

* The user will see and control the program from the command line.
* The program must use OOP in as many areas as possible.
* There will be a single deck of cards where used up cards will be returned to.

## Functional Requirements

* The program should be delivered as an executable binary and compilable source for both Win and Linux targets (a PKGBUILD should be made for Arch Linux targets).
* The user should enter how many human and AI players there will be. This is done through arguments (e.g. `blackjack 2 1` for two human and one AI player).
  * The input should be interpreted as an integer, and if the user didn't enter a correct input, the program should terminate and inform the user that the input was faulty.
* The program should present the players with a standard game of blackjack.
  * At the end of a game the user should input whether they want to keep playing or end the game.
  * The user should be able to play a game as usual, that means to be able to hit, hold, etc.
  
## Miscellaneous

* To hit is to take another card from the deck, to hold is to end one's turn, and to bust is to go over 21 in terms of total card value.

# Design

## Classes

### Card

* Properties:
  * Value, int (Ace = 11, J Q K = 11 12 13)
  * Suit, string (diamonds and hearts are red, clubs and spades are black)
  * Label, string (this is the "name" of the card, its label, e.g. A for ace, Q for queen.)
  * Revealed, bool
* Methods:
  * GetColour, ConsoleColor (returns the console colour red or black which is used to colour the foreground.)

### Deck

* Properties:
  * ContainingCards, list of Cards (on construction, fill with 52 shuffled Cards, one from each value and suit (henceforth referred to as "standard deck"). Cards can be removed and added at any time.)
  * TotalValue, int (updated whenever Remove and PutCard are run.)
* Methods:
  * Shuffle, void (shuffle the order of the cards)
  * RemoveCard, Card (removes a Card from the deck (from the start of the list) and returns it)
  * PutCard, void (adds the entered Card to the deck (at the end of the list). This and the method above also update TotalValue.)
  * RevealAll, void (changes all of the Cards in ContainingCards to be reavealed instead of not)

### Player

* Inherits from Deck.
* Properites:
  * [None].
* Methods:
  * CheckBust, bool (checks if the totalValue is over 21)
  * WillHit, bool (asks the player whether to hit or hold. If the player hits, then return true, otherwise (if the player holds), false.)

### COM

* Inherits from Player
* Properties:
  * MaxHitWillingness, int (the AI won't hit if their total is above this number. So if it's 16, then the AI will hit when its value is 16, but not if it's 17).
* Methods:
  * Override WillHit. Instead of asking the user for input, make a choice based on MaxHitWillingness

## Main program

1. Create a new standard deck and list of players.
2. Give each player two cards, one revealed, the other not revealed. These cards are taken from the standard deck (which implies they are removed from the deck too).
3. For each player playing, starting with "player 1", reveal the other card and ask them whether they want to hit or hold. If they go over 21, then they are bust and do not participate in the round anymore. Move on to the next player if the current player holds or busts.
   1. Create highestValue and highestPlayer variables (both int) which keep track of the highest score and the player who achieved this score.
   2. For each player in the list of players (preferably not using a `foreach` loop):
      1. Reveal their cards (`currentPlayer.RevealAll()`)
      2. Start a while loop that needs to be manually broken (`while(true) {}`).
         1. Reveal their cards and present them their values and their total. Ask them whether they want to hit or hold (use WillHit method).
         2. If they hold, check whether they have the highest score now and update the variables highestValue and highestPlayer accordingly. Then, move on to the next player (`break`).
         3. If they are bust, move on to the next player (`break`).
4. Once each player has held or are bust, check which had the highest score. That person wins.
5. Ask the user whether they want to play again.
