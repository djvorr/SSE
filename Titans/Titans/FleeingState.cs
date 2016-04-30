using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    class FleeingState
    {
        NonHero enemy;
        int speed = 4;

        public FleeingState(NonHero enemy)
        { this.enemy = enemy; }

        public void Attack()
        {
            enemy.takeDamage(0);
            Console.WriteLine("You cannot attack while fleeing!");
        }

        public Location Run(Location location)
        {
            int x=location.getX(), y=location.getY(), d=location.getDirection();

            if (d == 0)
                y -= speed;
            else if (d == 1)
                x += speed;
            else if (d == 2)
                y += speed;
            else if (d == 3)
                x -= speed;

            return new Location(x, y, d);
        }

        public int Heal()
        {
            return 0;
            Console.WriteLine("You cannot heal while fleeing!");
        }

        public void UseFinisher()
        { 
            enemy.takeDamage(0);
            Console.WriteLine("You cannot use a finisher while fleeing!");
        }
    }
}
