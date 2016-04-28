using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    class Boss : Monster
    {
        Monster boss;

        public Boss()
        {
            boss = new Monster();
        }
    }
}
