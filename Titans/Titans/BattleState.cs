using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    interface BattleState
    {
        void Attack();
        Location Run();
        int Heal();
        void UseFinisher();
    }
}
