using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyAlgorithm
{
    class FuzzyAlgorithm
    {
        Frame frame;
        Ship ship;

        public FuzzyAlgorithm(Frame frame, Ship ship)
        {
            this.frame = frame;
            this.ship = ship;
        }

        public void run()
        {
            doVertical();
        }

        public void doHorizontal()
        {
            


        }

        public void doVertical()
        {
            ClassificationHelper ch = new ClassificationHelper(frame, ship);
            MembershipCalculator mc = new MembershipCalculator();

            int HH = ch.getThreshold_HH();
            int H = ch.getThreshold_Mid(ch._H);
            int L = ch.getThreshold_Mid(ch._L);
            int LL = ch.getThreshold_LL();

            if (normalize(mc.height_high(HH, H, 1, ship.getYPosition())))
                Console.WriteLine("Move Down");
            else if (normalize(mc.height_low(L, LL, frame.getCount() - 1, ship.getXPosition())))
                Console.WriteLine("Move Up");
            else if (normalize(mc.height_mid(HH, LL, ship.getXPosition())))
                Console.WriteLine("No Height Change");
        }

        public bool normalize(float val)
        {
            if (val >= 0.5) 
                return true;
            else 
                return false;
        }
    }
}
