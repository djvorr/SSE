using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class Jump : FinisherDecorator
    {
        Finisher finisher;

        public Jump(Finisher finisher)
        { this.finisher = finisher; }

        public override string getFinisher()
        { return finisher.getFinisher() + ", Jump"; }

        public override int buildFinisher()
        { return finisher.buildFinisher() + 4; }
    }
}
