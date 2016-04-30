using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    class DeadState
    {
        public void Attack()
        { Console.WriteLine("You are dead!"); }

        public Location Run(Location location)
        {
            Console.WriteLine("You are dead!");

            return location;
        }

        public int Heal()
        {
            Console.WriteLine("You are dead!");
            return 0;
        }

        public void UseFinisher()
        { Console.WriteLine("You are dead!"); }
    }
}
