using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadSwirl
{
    public class Center
    {
        int x;
        int y;

        public Center(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getX()
        { return x; }

        public int getY()
        { return y; }
    }
}
