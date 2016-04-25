using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public abstract class Finisher
    {
        string finisher = " ";

        public string getFinisher()
        { return finisher; }

        public abstract int buildFinisher();
    }
}
