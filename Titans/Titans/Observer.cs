using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public interface Observer
    {
        void updateAndSwarm(Location location);
    }
}
