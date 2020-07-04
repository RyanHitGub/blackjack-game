using System;
using System.Collections.Generic;
using System.Text;

namespace BlackjackLibrary
{
    public class TotalCalculator
    {
        public static int CalculateTotal(Card[] hand)
        {
            int total = 0;

            for (int i = 0; i < hand.Length; i++)
            {
                total += hand[i].GetRank();
            }

            if (total > 21)
            {
                for (int i = 0; i < hand.Length; i++)
                {
                    if (hand[i].GetFace() == "A" && total > 21)
                    {
                        total -= 10;
                    }
                }
            }
            return total;
        }
    }
}
