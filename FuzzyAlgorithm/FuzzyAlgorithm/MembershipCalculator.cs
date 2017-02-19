using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyAlgorithm
{
    public class MembershipCalculator
    {
        public float CalculatePlateauProfile(float val, float left_low, float left_high, float right_high, float right_low)
        {
            //Relocate points by same amount, so beginning point is essentially at x=0
            //should work for positive and inverted plateaus
            val -= left_low;
            left_high -= left_low;
            right_low -= left_low;
            right_high -= left_low;
            left_low = 0;

            float pos_slope = 1 / (left_high - left_low);
            float neg_slope = 1 / (right_low - right_high);

            if (val < left_low || val > right_low)
                return 0.0f;
            else if (val >= left_high && val <= right_high)
                return 1.0f;
            else if (val < left_high)
                return (val - left_low) * pos_slope;
            else if (val > right_high)
                return (right_low - val) * neg_slope;

            return 0.0f;
        }

        public float CalculateSpikeProfile(float val, float lo, float high)
        {
            float point;
            val -= lo;

            if (lo < 0 && high < 0)
                high = -(high - lo);
            else if (lo < 0 && high > 0)
                high -= lo;
            else if (lo > 0 && high > 0)
                high -= lo;

            point = high / 2;
            lo = 0;

            if (val < point)
                return val / point;
            else if (val > point)
                return (high - val) / point;

            return 1.0f;
        }

        public float height_low(int L, int LL, int max, int y)
        {
            if (y < L)
                return 0;
            if (y > LL)
                return 1;

            return CalculatePlateauProfile(y, L, LL, max, max);
        }

        public float height_mid(int HH, int LL, int y)
        {
            if (y < HH || y > LL)
                return 0;

            return CalculateSpikeProfile(y, HH, LL);
        }

        public float height_high(int HH, int H, int min, int y)
        {
            if (y < HH)
                return 1;
            if (y > H)
                return 0;

            return CalculatePlateauProfile(y, min, min, HH, H);
        }
    }
}
