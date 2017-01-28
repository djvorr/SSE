using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Sceduler
{
    class Evaluator
    {
        public float weight_Days = 1;
        public float weight_Teacher = 1;
        public float weight_Department = 1;
        public float weight_Time = 1;

        public float weight_conflicted = 0.01f;
        public float weight_duplicated = 0.01f;  

        private int sumDays = 0;
        private int sumTeachers = 0;
        private int sumDepartment = 0;
        private int sumTime = 0;


        public float evaluate(Chromosome chromosome)
        {
            float fitness = -1;

            doSummations(chromosome);
            fitness = factorWeights();
            fitness = factorOthers(chromosome);

            return fitness;
        }

        private void doSummations(Chromosome chrom)
        {
            sumDays = 0;
            sumTeachers = 0;
            sumDepartment = 0;
            sumTime = 0;

            foreach (Class c in chrom.classes)
            {
                sumDays += c.val_Days;
                sumTeachers += c.val_Teacher;
                sumDepartment += c.val_Department;
                sumTime += c.val_Time;
            }
        }

        private float factorWeights()
        {
            return sumDays * weight_Days + 
                sumDepartment * weight_Department + 
                sumTeachers * weight_Teacher + 
                sumTime * weight_Time;
        }
    }
}
