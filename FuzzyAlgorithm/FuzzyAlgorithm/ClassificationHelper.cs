using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyAlgorithm
{
    class ClassificationHelper
    {
        public int _L = 1;
        public int _H = 2;

        Frame frame;
        Ship ship;

        /*
         * This is the search width radius on either side of the ship. I want it to be a bit wider than 
         * the range. I don't want to search the whole way across the frame, just
         * in the immediate area around the ship. I can probably get better results this way because the ship
         * will NOT collide with objects at the same y, if the object is not at the same x.
         */
        int width = 5;

        //should = 1, LH*2
        float LHPercentage = 0.40f;
        float CPercentage = 0.20f;

        public ClassificationHelper(Frame frame, Ship ship)
        {
            this.frame = frame;
            this.ship = ship;
        }

        public int getThreshold_Mid(int type)
        {
            int HH = getThreshold_HH();
            int LL = getThreshold_LL();

            int dist = LL - HH;

            if (type == _L)
                return LL - (int)(dist * LHPercentage);
            else if (type == _H)
                return HH + (int)(dist * LHPercentage);

            return -1;
        }

        /*
         * This function is designed to grab the highest threshold for the vertical position. Specifically, 
         * It starts from the ship's y-position on the map(centered) offset by the range and compares the 
         * current line and the line above it together, moving up until an object is found. An object is 
         * detected by finding a change from a 0 to a 1. Sometimes am object may be inline with the ship, 
         * but off to the side, so requiring a change from 0 to 1 should clear those false-positives.
         */
        public int getThreshold_HH()
        {
            int start = ship.getXIndex() - ship.getRadarRange();

            string bottom;
            string top;

            for(int i=start; i>1; i--)
            {
                bottom = frame.getLine(i);
                top = frame.getLine(i - 1);

                if (detectedObject(top, bottom))
                    return i;
            }

            return 0;
        }

        /* Same functionality as getThreshold_HH. The difference is this one goes down, using the top line
         * as the 0 and the bottom as the 1 for detection.
         */
        public int getThreshold_LL()
        {
            int start = ship.getXIndex() + ship.getRadarRange();

            string bottom;
            string top;

            for (int i = start; i < frame.getCount()-1; i++)
            {
                top = frame.getLine(i);
                bottom = frame.getLine(i + 1);

                if (detectedObject(bottom, top))
                    return i;
            }

            return frame.getCount() - 1;
        }

        private bool detectedObject(string a, string b)
        {
            Assert.AreEqual(a.Length, b.Length, "Strings are of different length.");

            int start = ship.getXIndex() - width;
            int end = ship.getXIndex() + width;

            for(int i=start; i<end; i++)
            {
                if (b[i] == '0' && a[i] == '1')
                    return true;
            }

            return false;
        }
    }
}
