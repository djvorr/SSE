using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class Smash : FinisherDecorator
    {
        Finisher finisher;

        public Smash(Finisher finisher)
        { this.finisher = finisher; }

        public override string getFinisher()
        { return finisher.getFinisher() + ", Spin"; }

        public override int buildFinisher()
        { return finisher.buildFinisher() + 16; }
    }
}
