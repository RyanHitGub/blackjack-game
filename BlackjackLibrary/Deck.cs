using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackLibrary
{
    public class Deck
    {
        const int DECKSIZE = 52;

        //methods
        public Card[] PopulateDeck()
        {
            Card[] cards = new Card[DECKSIZE];
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i] = new Card();
                if (i < 13)
                {
                    cards[i].SetSuit((char)Card.Suit.Club);
                    cards[i].SetFace(i);
                    cards[i].SetRank(i);
                }
                else if (i < 26)
                {
                    cards[i].SetSuit((char)Card.Suit.Diamond);
                    cards[i].SetFace(i - 13);
                    cards[i].SetRank(i - 13);
                }
                else if (i < 39)
                {
                    cards[i].SetSuit((char)Card.Suit.Heart);
                    cards[i].SetFace(i - 26);
                    cards[i].SetRank(i - 26);
                }
                else
                {
                    cards[i].SetSuit((char)Card.Suit.Spade);
                    cards[i].SetFace(i - 39);
                    cards[i].SetRank(i - 39);
                }
            }
            return cards;
        }

        public Card[] ShuffleDeck(Card[] deck)
        {
            Randomiser.Randomise(deck);
            return deck;
        }

        public Card[] DealDeck(Card[] deck, Player[] players, House house)
        {
            deck = house.CreateHand(deck);
            for (int i = 0; i < players.Length; i++)
            {
                deck = players[i].CreateHand(deck);
            }

            return deck;
        }

    }
}
