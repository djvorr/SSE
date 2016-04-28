using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    class Barracks
    {
        public Army getArmy(string race)
        {
            Army army = null;
            ArmyFactory armyFactory = null;

            if (race == "Goblin")
                armyFactory = new GoblinArmy();
            else if (race == "Orc")
                armyFactory = new OrcArmy();

            if (armyFactory != null)
                army = new Army(armyFactory);

            return army;
        }
    }
}
