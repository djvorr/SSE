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
        public double fitness = 0;

        public Chromosome(List<Class> courses, int unitLength)
        {
            this.classes = courses;
            this.unitSize = unitLength;
        }

        public void displayChromosome()
        {
            Console.WriteLine("Fitness: " + fitness);
            foreach (Class c in classes)
            {
                if (c.time != "Distance Learning" && c.time != "Independent Study")
                    Console.WriteLine(c.bitset + " " + c.department + " " + c.name + " " + c.teacher + " " + c.days + " " + c.time);
                else
                    Console.WriteLine(c.bitset + " " + c.department + " " + c.name + " " + c.teacher + " " + c.days);
            }
        }

        public int getClassNumber()
        {
            return classes.Count();
        }


    }
}
