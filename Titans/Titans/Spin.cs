using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class Spin : FinisherDecorator
    {
        Finisher finisher;

        public Spin(Finisher finisher)
        { this.finisher = finisher; }

        public override string getFinisher()
        { return finisher.getFinisher() + ", Spin"; }

        public override int buildFinisher()
        { return finisher.buildFinisher() + 8; }
    }
}
