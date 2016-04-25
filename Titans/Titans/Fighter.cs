using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public abstract class Fighter
    {
        int health = 10;
        bool isDead = false;
        int damage = 2;

        public int getHealth()
        { return health; }

        public void strike()
        { Console.WriteLine(damage + " Damage!"); }

        public abstract string getRace();

        public abstract Finisher getFinisher();
    }
}
