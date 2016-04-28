using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    class Script
    {
        public void main()
        {
            Finisher finisher2 = new BodySlam();
            finisher2 = new Jump(finisher2);
            finisher2 = new Jump(finisher2);
            finisher2 = new Smash(finisher2);
            Console.WriteLine(finisher2.getFinisher() + finisher2.buildFinisher());

            Finisher finisher3 = new Tornado();
            finisher3 = new Spin(finisher3);
            finisher3 = new Spin(finisher3);
            finisher3 = new Slash(finisher3);
            Console.WriteLine(finisher3.getFinisher() + finisher3.buildFinisher());
        }
    }
}
