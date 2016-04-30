using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public interface NonHero : Character, Observer
    {
        Location getLocation();
        bool isDead();
        void setLocation(Location location);
        void callBackup();
        int getHealth();
        void updateAndSwarm(Location location);
        List<NonHero> getReinforcements();
        void takeDamage(int damage);
    }
}
