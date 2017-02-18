using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyAlgorithm
{
    class TestMath
    {
        public void main()
        {
            himemship();



            Console.ReadLine();
        }

        private void himemship()
        {
            MembershipCalculator mc = new MembershipCalculator();

            float val = 0;
            float left_low = 20.0f;
            float left_high = 25.0f;
            float right_high = 30.0f;
            float right_low = 30.0f;

            /*              ___________
             *             /           
             *    ________/             
            */

            for (float i = 20.0f; i < 30; i += 0.1f)
            {
                val = i;
                float ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);
                Console.WriteLine(i.ToString() + "  " + ret);
            }
        }

        private void medmemship()
        {
            MembershipCalculator mc = new MembershipCalculator();

            float val = 0;
            float left_low = 5.0f;
            float left_high = 10.0f;
            float right_high = 20.0f;
            float right_low = 25.0f;

            /*              ___________
             *             /           \
             *    ________/             \__________
            */

            for (float i = 5.0f; i < 25; i += 0.1f)
            {
                val = i;
                float ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);
                Console.WriteLine(i.ToString() + "  " + ret);
            }
        }

        private void lowmemship()
        {
            MembershipCalculator mc = new MembershipCalculator();

            //low is about 1 -> 10

            float val = 0;
            float left_low = 1.0f;
            float left_high = 1.0f;
            float right_high = 5.0f;
            float right_low = 10.0f;

            /*     ___________
             *                \
             *                 \__________
            */

            for (float i = 0.0f; i < 10; i += 0.1f)
            {
                val = i;
                float ret = mc.CalculatePlateauProfile(val, left_low, left_high, right_high, right_low);
                Console.WriteLine(i.ToString() + "  " + ret);
            }
        }

        private void posneg()
        {
            Console.WriteLine(1 + 1);
            Console.WriteLine(1 - 1);
            Console.WriteLine(1 + (-1));
            Console.WriteLine(1 - (-1));
        }
    }
}
