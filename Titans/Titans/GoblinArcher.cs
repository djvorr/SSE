using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class GoblinArcher : Archer
    {
        int health;
        bool isDead;
        Location location;

        public GoblinArcher()
        {
            health = 9;
            isDead = false;
        }

        public Location getLocation()
        { return this.location; }

        public void setLocation(Location location)
        { this.location = location; }

        public string getRace()
        { return "Goblin"; }

        public int getHealth()
        { return health; }

        public void launchArrow()
        { Console.WriteLine("2 Damage!"); }

        public void die()
        { isDead = true; }
    }
}
