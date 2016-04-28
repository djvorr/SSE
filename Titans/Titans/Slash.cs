using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class Slash : FinisherDecorator
    {
        Finisher finisher;

        public Slash(Finisher finisher)
        { this.finisher = finisher; }

        public override string getFinisher()
        { return finisher.getFinisher() + ", Slash"; }

        public override int buildFinisher()
        { return finisher.buildFinisher() + 12; }
    }
}
