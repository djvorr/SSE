using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Sceduler
{
    class Chromosome
    {
        public string chromSet = "";
        public List<Class> classes;
        public int unitSize = 0;

        public Chromosome(List<Class> courses, int unitLength)
        {
            this.classes = courses;
            this.unitSize = unitLength;
        }


    }
}
