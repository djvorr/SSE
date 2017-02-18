using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyAlgorithm
{
    public class FuzzyOperator
    {
        //working 1:53 AM 2/18
        #region Fuzzy Controls
        public float and(float a, float b)
        { return min(a, b); }

        public float or(float a, float b)
        { return max(a, b); }

        public float not(float a)
        { return (1 - a); }
        #endregion

        //working 1:53 AM 2/18
        #region Min and Max
        public float max(float a, float b)
        {
            if (a > b)
                return a;
            else
                return b;
        }

        public float min(float a, float b)
        {
            if (a < b)
                return a;
            else
                return b;
        }
        #endregion
    }
}
