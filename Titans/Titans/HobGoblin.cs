using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class HobGoblin : Fighter
    {
        int health;
        bool isDead;

        public HobGoblin()
        {
            health = 8;
            isDead = false;
        }

        public int getHealth()
        { return health; }

        public void strike()
        { Console.WriteLine("2 Damage!"); }

        public override string getRace()
        { return "Goblin"; }

        public override Finisher getFinisher()
        {
            Finisher finisher2 = new BodySlam();
            finisher2 = new Jump(finisher2);
            finisher2 = new Jump(finisher2);
            finisher2 = new Smash(finisher2);

            return finisher2;
        }
    }
}
