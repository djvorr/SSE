using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;


namespace Titans
{
    public interface TeleportBehavior
    {
        System.Drawing.Color getColor();
        Location getDestination();
        int getMagicRequirement();
    }
}
