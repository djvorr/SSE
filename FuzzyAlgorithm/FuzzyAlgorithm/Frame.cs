using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyAlgorithm
{
    class Frame
    {
        private List<string> lines = new List<string>();

        public void AddLine(string line)
        {
            lines.Add(line);
        }

        public string getLine(int index)
        { return lines[index]; }

        public int getCount()
        { return lines.Count; }
    }
}
