using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    class Knights
    {
        List<Hero> knights;
        public Knights()
        {
             knights = new List<Hero>();
        }

        public void addKnight(Hero hero)
        {
            knights.Add(hero);
        }

        public void removeKnight(Hero hero)
        {
            knights.Remove(hero);
        }

        public int Count()
        { return knights.Count; }

        public List<Hero> getKnights()
        { return knights; }
    }
}
