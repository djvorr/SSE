using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyAlgorithm
{
    class Ship
    {
        private int x;
        private int y;
        private int radarRange;

        public Ship(int x, int y, int radarRange)
        {
            this.x = x;
            this.y = y;
            this.radarRange = radarRange;
        }

        public int getXIndex()
        { return x; }

        public int getYIndex()
        { return y; }

        public int getXPosition()
        { return x + 1; }

        public int getYPosition()
        { return y + 1; }

        public int getRadarRange()
        { return radarRange; }

        public void adjustX(int x)
        { this.x += x; }

        public void adjustY(int y)
        { this.y += y; }
    }
}
