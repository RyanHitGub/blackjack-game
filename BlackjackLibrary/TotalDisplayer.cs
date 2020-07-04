using System;
using System.Collections.Generic;
using System.Text;

namespace BlackjackLibrary
{
    public class TotalDisplayer
    {
        public static string DisplayTotal(int total)
        {
            if (total < 21)
            {
                return (total.ToString());
            }
            else if (total == 21)
            {
                return (total.ToString() + " Blackjack!");
            }
            else
            {
                return (total.ToString() + " Bust!");
            }
        }
    }
}
