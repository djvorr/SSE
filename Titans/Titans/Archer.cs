using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public interface Archer
    {
        string getRace();
        int getHealth();
        void launchArrow();
        void die();
    }
}
