using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Sceduler
{
    class Evaluator
    {
        public double weight_Days = 0.05;
        public double weight_Teacher = 0.10;
        public double weight_Department = 0.15;
        public double weight_Time = 0.10;

        public double weight_unconflicted = 0.25;
        public double weight_unduplicated = 0.25;

        public double weight_numClasses = 0.15;
        public double weight_num = 0.15;

        private int sumDays = 0;
        private int sumTeachers = 0;
        private int sumDepartment = 0;
        private int sumTime = 0;

        public int fitness_scaler = 100;


        public double evaluate(Chromosome chromosome)
        {
            double fitness = -1;

            doSummations(chromosome);
            fitness = factorWeights();
            fitness += evaluateConflicts(chromosome);
            fitness += evaluateDuplicates(chromosome);
            fitness += evaluateClassNumber(chromosome);

            return fitness * fitness_scaler;
        }

        #region Schedule Length
        public double evaluateClassNumber(Chromosome chromosome)
        {
            return weight_numClasses * quantifyClassNumber(chromosome);
        }

        public int quantifyClassNumber(Chromosome chromosome)
        {
            if (chromosome.getClassNumber() > 4 && chromosome.getClassNumber() == 5)
                return 2;
            else if (chromosome.getClassNumber() == 6)
                return 1;
            else
                return 0;
        }
        #endregion

        #region Base Fitness Calculations W/O Conflicts
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

        private double factorWeights()
        {
            return sumDays * weight_Days + 
                sumDepartment * weight_Department + 
                sumTeachers * weight_Teacher + 
                sumTime * weight_Time;
        }

        #endregion

        #region Evaluate Duplicates
        private double evaluateDuplicates(Chromosome chromosome)
        {
            return weight_unduplicated * countDuplicates(chromosome);
        }

        private int countDuplicates(Chromosome chromosome)
        {
            int i = 0;

            foreach (Class c in chromosome.classes)
            {
                int sum = 0;
                foreach (Class c2 in chromosome.classes)
                {
                    if (c.bitset == c2.bitset)
                        sum += 1;
                }

                //will have at least one same - equivalent to itself
                i += sum - 1;
            }

            if (i < 0)
                throw new Exception("Day conflict less than 0.");

            //smaller number of duplicates needs a higher reward
            return 6 - i;
        }
        #endregion

        #region Conflicts
        private double evaluateConflicts(Chromosome chromosome)
        {
            return weight_unconflicted * countTimeConflicts(chromosome);                
        }

        private int countTimeConflicts(Chromosome chromosome)
        {
            int i = 0;

            foreach (Class c in chromosome.classes)
            {
                int sum = 0;
                foreach (Class c2 in chromosome.classes)
                {
                    if (sameDays(c.days.Trim(), c2.days.Trim()) && c.time.Trim() == c2.time.Trim() && c.name.Trim() != c2.name.Trim())
                        sum += 1;
                }

                i += sum;
            }

            if (i < 0)
                throw new Exception("Time conflict less than 0.");

            //smaller number of duplicates needs a higher reward
            return 6 - i;
        }

        private bool sameDays(string day1, string day2)
        {
            if (day1.Contains("M") && day2.Contains("M"))
                return true;
            if (day1.Contains("T") && day2.Contains("T"))
                return true;
            if (day1.Contains("W") && day2.Contains("W"))
                return true;
            if (day1.Contains("R") && day2.Contains("R"))
                return true;
            if (day1.Contains("F") && day2.Contains("F"))
                return true;

            return false;
        }

        #endregion
    }
}
