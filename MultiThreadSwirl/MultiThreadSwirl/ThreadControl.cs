using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MultiThreadSwirl
{
    public class ThreadControl
    {
        public Line line;
        Clock clock;
        Incrementor inc;

        public ThreadControl(Line line, Clock clock, int linedensity)
        {
            this.line = line;
            this.clock = clock;
            inc = new Incrementor(linedensity, line.getAngle());
        }

        public void HandleEvent()
        {
            line.setAngle(inc.getNext());
            //Console.WriteLine("handling");
            listen();
        }

        public void listen()
        {
            //Console.WriteLine("listening");
            while (!clock.flagStatus()) ;
            System.Threading.Thread.Sleep(500);
            HandleEvent();
        }
    }
}
