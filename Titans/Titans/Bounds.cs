using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class Bounds
    {
        int BoundX, BoundY;

        public Bounds(int x, int y)
        {
            BoundX = x;
            BoundY = y;
        }

        public int getBoundX()
        { return BoundX; }

        public int getBoundY()
        { return BoundY; }

        public void setBoundX(int newBoundX)
        { BoundX = newBoundX; }

        public void setBoundY(int newBoundY)
        { BoundY = newBoundY; }
    }
}
