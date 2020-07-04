using System;
using System.Collections.Generic;
using System.Text;

namespace BlackjackLibrary
{
    public class Participant
    {
        private string name;
        private Card[] hand;

        public string Name
        {
            get { return name; }
            set
            {
                if (value != null)
                {
                    name = value;
                }
            }
        }

        public void SetHand(Card[] hand)
        {
            this.hand = hand;
        }

        public Card[] GetHand()
        {
            return hand;
        }

        public Card[] CreateHand(Card[] deck)
        {
            int handSize = 2;

            hand = new Card[handSize];
            int cardOnTop = deck.Length - 1;
            int reduceByAmount;

            for (int i = 0; i < hand.Length; i++)
            {
                hand[i] = deck[cardOnTop];
                cardOnTop--;
            }

            reduceByAmount = (deck.Length - 1) - cardOnTop;
            deck = Resizer.ResizeDeck(deck, reduceByAmount);

            return deck;
        }

        public Card[] TakeHit(Card[] deck, Card[] hand)
        {
            int handSize = hand.Length;
            Card[] temp = new Card[handSize];
            temp = hand;
            hand = new Card[handSize += 1];
            for (int i = 0; i < hand.Length; i++)
            {
                if (i < hand.Length - 1)
                {
                    hand[i] = temp[i];
                }
                else
                {
                    hand[i] = deck[deck.Length - 1];
                }
            }
            return hand;
        }
    }
}
