using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public interface Character
    {
        Location getLocation();
        bool isDead();
        void setLocation(Location location);
    }
}
