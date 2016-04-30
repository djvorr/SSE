using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class LairTeleport : TeleportBehavior
    {
        public void Teleport(Hero hero, Monster monster)
        { monster.setLocation(hero.getLocation()); }

        public System.Drawing.Color getColor()
        { return System.Drawing.Color.Green; }

        public Location getDestination()
        { return (new Location(2000, 2000)); }

        public int getMagicRequirement()
        { return 20; }
    }
}
