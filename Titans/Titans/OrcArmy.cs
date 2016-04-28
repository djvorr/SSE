using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class OrcArmy : ArmyFactory
    {
        public Archer createArcher()
        { return new OrcArcher(); }

        public Fighter createFighter()
        { return new OrcWarrior(); }
    }
}
