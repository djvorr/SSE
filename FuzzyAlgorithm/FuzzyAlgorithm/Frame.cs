using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        public string getLine(int index, int direction)
        {
            ClassificationHelper c = new ClassificationHelper(new Frame(), new Ship(1,1,1));
            if (direction == ClassificationHelper.VERT)
                return lines[index];

            return getColumn(index);
        }

        private string getColumn(int index)
        {
            string col = "";

            for (int y=0; y<lines.Count(); y++)
            {
                for (int x=0; x<lines[y].Length; x++)
                {
                    if (x == index)
                        col += lines[y][x];
                }
            }

            Assert.IsTrue(col.Length == lines[0].Length, "Column returned is incorrect size.");

            return col;
        }

        public int getCount()
        { return lines.Count; }
    }
}
