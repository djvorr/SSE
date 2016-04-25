using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class GoblinArmy : ArmyFactory
    {
        public Archer createArcher()
        { return new GoblinArcher(); }

        public Fighter createFighter()
        { return new HobGoblin(); }
    }
}
