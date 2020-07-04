using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackLibrary
{
    public class Resizer
    {
        public static Card[] ResizeDeck(Card[] deck, int resizeByAmount)
        {
            Card[] newDeck = new Card[deck.Length - resizeByAmount];

            for (int i = 0; i < newDeck.Length; i++)
            {
                newDeck[i] = deck[i];
            }

            return newDeck;
        }
    }
}
