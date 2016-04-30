using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class Hero : Character
    {
        List<Object> inventory = new List<object>();

        public Location location;
        bool isAlive = false;

        public Location getLocation()
        { return location; }

        public bool isDead()
        { return isAlive; }

        public void setLocation(Location location)
        { this.location = location; }

        public int getHealth()
        { return 10; }

        public void addItemToInventory(Object item)
        { inventory.Add(item); }

        public void removeItemFromInventory(Object item)
        {
            if (inventory.Contains(item))
                inventory.Remove(item);
        }
    }
}
