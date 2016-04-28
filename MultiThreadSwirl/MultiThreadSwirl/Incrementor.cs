using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadSwirl
{
    public class Incrementor
    {
        double curr = 0;
        double inc;

        public Incrementor(int density, double current)
        {
            this.inc = (Math.PI/2)/density;
            this.curr = current;
        }

        public double getNext()
        { return curr += inc; }
    }
}
