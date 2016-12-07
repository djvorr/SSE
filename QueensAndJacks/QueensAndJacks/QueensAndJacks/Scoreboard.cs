using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueensAndJacks
{
    public class Scoreboard
    {
        private List<int> score = new List<int>(new int[] {0, 0, 0, 0});

        public void addPoints(int player, int points)
        {
            throw new System.NotImplementedException();
        }

        public List<int> getScore()
        {
            return score;
        }
    }
}