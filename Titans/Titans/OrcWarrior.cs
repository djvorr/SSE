using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class OrcWarrior : Fighter
    {
        int health;
        bool isDead;

        public OrcWarrior()
        {
            health = 10;
            isDead = false;
        }

        public int getHealth()
        { return health; }

        public void strike()
        { Console.WriteLine("4 Damage!"); }

        public override string getRace()
        { return "Orc"; }

        public override Finisher getFinisher()
        {
            Finisher finisher3 = new Tornado();
            finisher3 = new Spin(finisher3);
            finisher3 = new Spin(finisher3);
            finisher3 = new Slash(finisher3);

            return finisher3;
        }
    }
}
