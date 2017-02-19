using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyAlgorithm
{
    class FrameReader
    {
        string path = ("dumbitdownforstupid.txt");
        int numFrames = 10;

        List<Frame> frames = new List<Frame>();

        public List<Frame> ReadFrames(int count=10)
        {
            numFrames = count;
            string line;
            int i = 0;
            Frame f = new Frame();

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                if (i < numFrames && line.Length > 1)
                {
                    if (line[0] == '_')
                    {
                        i += 1;
                        frames.Add(f);
                        f = new Frame();
                    }
                    else
                    {
                        f.AddLine(line);
                    }
                }
                else if (i == numFrames)
                    break;
            }

            file.Close();

            return frames;
        }
    }
}
