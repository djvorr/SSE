using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    class GoblinArcherAdapter : NonHero
    {
        GoblinArcher goblin;
        List<NonHero> reinforcements;

        public GoblinArcherAdapter(GoblinArcher goblin)
        {
            this.goblin = goblin;
            reinforcements = new List<NonHero>(); 
        }

        public Location getLocation()
        { return goblin.getLocation(); }

        public bool isDead()
        { return goblin.getHealth() == 0; }

        public void setLocation(Location location)
        { goblin.setLocation(location); }

        public void callBackup()
        {
            reinforcements.Add(new GoblinArcherAdapter(new GoblinArcher()));
            reinforcements.Add(new GoblinArcherAdapter(new GoblinArcher()));
        }

        public int getHealth()
        { return 8; }

        public void updateAndSwarm(Location location)
        {
            goblin.setLocation(location);
        }

        public List<NonHero> getReinforcements()
        { return reinforcements; }

        public void takeDamage(int damage)
        { goblin.health -= damage; }
    }
}
