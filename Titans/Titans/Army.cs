using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    class Army
    {
        public Archer archer { get; set; }
        public Fighter fighter { get; set; }
        ArmyFactory armyFactory;

        public Army(ArmyFactory armyFactory)
        {
            this.armyFactory = armyFactory;
        }

        public void RaiseArmy()
        {
            archer = armyFactory.createArcher();
            fighter = armyFactory.createFighter();
        }
    }
}
