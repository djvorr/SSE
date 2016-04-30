using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    class PortalSpell : Portal
    {
        public void useSpell(Hero hero, int portal)
        {
            location = hero.getLocation();
            location.setX(location.getX() + 1);
            location.setX(location.getX() + 1);

            hero.removeItemFromInventory(new Spell(portal));
        }
    }
}
