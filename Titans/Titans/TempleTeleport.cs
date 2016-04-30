using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class TempleTeleport : TeleportBehavior
    {
        public void Teleport(Hero hero)
        { hero.setLocation(new Location(0, 0)); }

        public System.Drawing.Color getColor()
        { return System.Drawing.Color.Purple; }

        public Location getDestination()
        { return (new Location(1000, 1000)); }

        public int getMagicRequirement()
        { return 10; }
    }
}
