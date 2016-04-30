using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    class KnightsIterator
    {
        List<Hero> Hero;
        int index = -1;

        public KnightsIterator(List<Hero> Hero)
        {this.Hero = Hero;}

        public void reset()
        {
            index = -1;
        }

        public Hero next()
        {
            if (hasNext())
            {
                index += 1;
                return Hero[index];
            }

            return null;
        }

        public bool hasNext()
        { return !(index == Hero.Count - 1); }

        public bool isEmpty()
        { return Hero.Count == 0; }

        public int getIndex()
        { return index; }
    }
}
