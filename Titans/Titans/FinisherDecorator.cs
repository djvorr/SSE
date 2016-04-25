using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public abstract class FinisherDecorator : Finisher
    {
        public abstract string getFinisher();
    }
}
