using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class Monster : NonHero
    {
        public Location location;
        bool isAlive = false;

        public Location getLocation()
        { return location; }

        public bool isDead()
        { return isAlive; }

        public void setLocation(Location location)
        { this.location = location; }

        public List<Monster> callBackup()
        {
            List<Monster> reinforcements = new List<Monster>();

            reinforcements.Add(new Monster());
            reinforcements.Add(new Monster());

            return reinforcements;
        }

        public int getHealth()
        { return 8; }

        public void updateAndSwarm(Location location)
        {
            this.location = location;
        }
    }
}
