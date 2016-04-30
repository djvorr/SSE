using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    class DefensiveState
    {
        NonHero enemy;
        int speed = 1;

        public DefensiveState(NonHero enemy)
        { this.enemy = enemy; }

        public void Attack()
        { enemy.takeDamage(1); }

        public Location Run(Location location)
        {
            int x=location.getX(), 
                y=location.getY(), 
                d=location.getDirection();

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
        { return 3;}

        public void UseFinisher()
        { enemy.takeDamage(2); }
    }
}
