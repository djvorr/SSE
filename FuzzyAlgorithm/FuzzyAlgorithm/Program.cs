using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            FrameReader reader = new FrameReader();
            List<Frame> frames = reader.ReadFrames(50);

            int frameWidth = frames[0].getCount() - 1;

            Ship ship = new Ship((int)(frameWidth/2), (int)(frameWidth/2), 3);

            FuzzyAlgorithm fa;

            int counter = 1;

            foreach (Frame f in frames)
            {
                Console.WriteLine("Frame " + counter + ":");
                fa = new FuzzyAlgorithm(f, ship);
                ship = fa.run();
                counter += 1;
            }

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
