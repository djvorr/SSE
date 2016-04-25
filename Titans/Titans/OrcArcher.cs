using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class OrcArcher : Archer
    {
        int health;
        bool isDead;

        public OrcArcher()
        {
            health = 9;
            isDead = false;
        }

        public string getRace()
        { return "Orc"; }

        public int getHealth()
        { return health; }

        public void launchArrow()
        { Console.WriteLine("3 Damage!"); }

        public void die()
        { isDead = true; }
    }
}
