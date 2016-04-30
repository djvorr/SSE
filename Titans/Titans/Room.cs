using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class Room
    {
        Bounds bounds;
        public Room(int xBound, int yBound)
        {
            bounds = new Bounds(xBound, yBound);
        }

        public Bounds getBounds()
        { return bounds; }
    }
}
