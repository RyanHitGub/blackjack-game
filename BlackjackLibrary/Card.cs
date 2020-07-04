using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackLibrary
{
    public class Card
    {
        private char suit;
        private int rank;
        private string face;

        private string[] faceList = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private int[] rankList = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };

        public enum Suit { Spade = 'S', Heart = 'H', Diamond = 'D', Club = 'C' };
        public enum Rank { Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Jack = 10, Queen = 10, King = 10, Ace = 11 };

        public char GetSuit()
        {
            return suit;
        }

        public int GetRank()
        {
            return rank;
        }

        public string GetFace()
        {
            return face;
        }

        public void SetSuit(char s)
        {
            suit = s;
        }

        public void SetRank(int i)
        {
            rank = rankList[i];
        }

        public void SetFace(int i)
        {
            face = faceList[i];
        }
    }
}
