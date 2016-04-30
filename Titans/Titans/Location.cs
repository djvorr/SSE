using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class Location
    {
        private int X;
        private int Y;
        private int direction;

        public Location(int x, int y, int direction = 0)
        {
            X = x;
            Y = y;
            this.direction = direction;
        }

        public int getX()
        { return X; }

        public int getY()
        { return Y; }

        public void setX(int newX)
        { X = newX; }

        public void setY(int newY)
        { Y = newY; }

        public int getDirection()
        { return direction; }

        public void setDirection(int newDirection)
        { direction = newDirection; }

    }
}
