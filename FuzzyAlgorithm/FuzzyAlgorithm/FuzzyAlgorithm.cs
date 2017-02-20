using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyAlgorithm
{
    class FuzzyAlgorithm
    {
        private static int _U = 0;
        private static int _UL = 1;
        private static int _UR = 2;
        private static int _L = 3;
        private static int _R = 4;
        private static int _D = 5;
        private static int _DL = 6;
        private static int _DR = 7;
        private static int _NC = 8;

        Frame frame;
        Ship ship;

        ClassificationHelper ch;
        MembershipCalculator mc;
        FuzzyOperator fo;

        public FuzzyAlgorithm(Frame frame, Ship ship)
        {
            this.frame = frame;
            this.ship = ship;

            ch = new ClassificationHelper(frame, ship);
            mc = new MembershipCalculator();
            fo = new FuzzyOperator();
        }

        public Ship run()
        {
            //doHorizontal();
            //doVertical();

            Correct();
            return ship;
        }

        public void Correct()
        {
            while (calculateCorrection() != _NC)
                calculateCorrection();
        }

        public int calculateCorrection()
        {
            int vHH = ch.getThreshold_HH(ClassificationHelper.HORIZ);
            int vH = ch.getThreshold_Mid(ch._H, ClassificationHelper.HORIZ);
            int vL = ch.getThreshold_Mid(ch._L, ClassificationHelper.HORIZ);
            int vLL = ch.getThreshold_LL(ClassificationHelper.HORIZ);

            int hHH = ch.getThreshold_HH(ClassificationHelper.VERT);
            int hH = ch.getThreshold_Mid(ch._H, ClassificationHelper.VERT);
            int hL = ch.getThreshold_Mid(ch._L, ClassificationHelper.VERT);
            int hLL = ch.getThreshold_LL(ClassificationHelper.VERT);

            int correction = 8;

            //up
            if (normalize(fo.and(mc.height_low(vL, vLL, frame.getCount() - 1, ship.getYPosition()), mc.height_mid(hHH, hLL, ship.getXPosition()))))
                correction = _U;
            //down
            else if (normalize(fo.and(mc.height_high(vHH, vH, 1, ship.getYPosition()), mc.height_mid(hHH, hLL, ship.getXPosition()))))
                correction = _D;
            //left
            else if (normalize(fo.and(mc.height_mid(vHH, vLL, ship.getYPosition()), mc.height_low(hL, hLL, frame.getCount() - 1, ship.getXPosition()))))
                correction = _L;
            //right
            else if (normalize(fo.and(mc.height_mid(vHH, vLL, ship.getYPosition()), mc.height_high(hHH, hH, 1, ship.getXPosition()))))
                correction = _R;
            //up, right
            else if (normalize(fo.and(mc.height_low(vL, vLL, frame.getCount() - 1, ship.getYPosition()), mc.height_high(hHH, hH, 1, ship.getXPosition()))))
                correction = _UR;
            //up, left
            else if (normalize(fo.and(mc.height_low(vL, vLL, frame.getCount() - 1, ship.getYPosition()), mc.height_low(hL, hLL, frame.getCount() - 1, ship.getXPosition()))))
                correction = _UL;
            //down, left
            else if (normalize(fo.and(mc.height_high(vHH, vH, 1, ship.getYPosition()), mc.height_low(hL, hLL, frame.getCount() - 1, ship.getXPosition()))))
                correction = _DL;
            //down, right
            else if (normalize(fo.and(mc.height_high(vHH, vH, 1, ship.getYPosition()), mc.height_high(hHH, hH, 1, ship.getXPosition()))))
                correction = _DR;
            //no change
            else if (normalize(fo.and(mc.height_mid(vHH, vLL, ship.getYPosition()), mc.height_mid(hHH, hLL, ship.getXPosition()))))
                correction = _NC;

            makeCorrection(correction);

            return correction;
        }

        public void makeCorrection(int direction)
        {
            if (direction == _U)
            {
                ship.adjustY(-1);
                Console.WriteLine("\tMove UP");
            }
            if (direction == _UL)
            {
                ship.adjustX(-1);
                ship.adjustY(-1);
                Console.WriteLine("\tMove UP LEFT");
            }
            if (direction == _UR)
            {
                ship.adjustY(-1);
                ship.adjustX(1);
                Console.WriteLine("\tMove UP RIGHT");
            }
            if (direction == _L)
            {
                ship.adjustX(-1);
                Console.WriteLine("\tMove LEFT");
            }
            if (direction == _R)
            {
                ship.adjustX(1);
                Console.WriteLine("\tMove RIGHT");
            }
            if (direction == _D)
            {
                ship.adjustY(1);
                Console.WriteLine("\tMove DOWN");
            }
            if (direction == _DL)
            {
                ship.adjustY(1);
                ship.adjustX(-1);
                Console.WriteLine("\tMove DOWN LEFT");
            }
            if (direction == _DR)
            {
                ship.adjustY(1);
                ship.adjustX(1);
                Console.WriteLine("\tMove DOWN RIGHT");
            }
            if (direction == _NC)
                Console.WriteLine("\tNO CHANGE");
        }

        public void doHorizontal()
        {
            int HH = ch.getThreshold_HH(ClassificationHelper.HORIZ);
            int H = ch.getThreshold_Mid(ch._H, ClassificationHelper.HORIZ);
            int L = ch.getThreshold_Mid(ch._L, ClassificationHelper.HORIZ);
            int LL = ch.getThreshold_LL(ClassificationHelper.HORIZ);

            if (normalize(mc.height_high(HH, H, 1, ship.getXPosition())))
                Console.WriteLine("Move Left");
            else if (normalize(mc.height_low(L, LL, frame.getCount() - 1, ship.getXPosition())))
                Console.WriteLine("Move Right");
            else if (normalize(mc.height_mid(HH, LL, ship.getXPosition())))
                Console.WriteLine("No Direction Change");
        }

        public void doVertical()
        {
            int HH = ch.getThreshold_HH(ClassificationHelper.VERT);
            int H = ch.getThreshold_Mid(ch._H, ClassificationHelper.VERT);
            int L = ch.getThreshold_Mid(ch._L, ClassificationHelper.VERT);
            int LL = ch.getThreshold_LL(ClassificationHelper.VERT);

            if (normalize(mc.height_high(HH, H, 1, ship.getYPosition())))
                Console.WriteLine("Move Down");
            else if (normalize(mc.height_low(L, LL, frame.getCount() - 1, ship.getYPosition())))
                Console.WriteLine("Move Up");
            else if (normalize(mc.height_mid(HH, LL, ship.getYPosition())))
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
