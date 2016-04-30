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
        List<NonHero> reinforcements;
        public int health = 8;

        public Monster()
        { reinforcements = new List<NonHero>(); }

        public Location getLocation()
        { return location; }

        public bool isDead()
        { return isAlive; }

        public void setLocation(Location location)
        { this.location = location; }

        public void callBackup()
        {
            reinforcements.Add(new Monster());
            reinforcements.Add(new Monster());
        }

        public int getHealth()
        { return health; }

        public void updateAndSwarm(Location location)
        {
            this.location = location;
        }

        public List<NonHero> getReinforcements()
        { return reinforcements; }

        public void takeDamage(int damage)
        { health -= damage; }
    }
}
