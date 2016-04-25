using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    class GoblinArcherAdapter : Character, Observer
    {
        GoblinArcher goblin; 

        public Location getLocation()
        { return goblin.getLocation(); }

        public bool isDead()
        { return goblin.getHealth() == 0; }

        public void setLocation(Location location)
        { goblin.setLocation(location); }

        public List<GoblinArcher> callBackup()
        {
            List<GoblinArcher> reinforcements = new List<GoblinArcher>();

            reinforcements.Add(new GoblinArcher());
            reinforcements.Add(new GoblinArcher());

            return reinforcements;
        }

        public int getHealth()
        { return 8; }

        public void updateAndSwarm(Location location)
        {
            goblin.setLocation(location);
        }
    }
}
