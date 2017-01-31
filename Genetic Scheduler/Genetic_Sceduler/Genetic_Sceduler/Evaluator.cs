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

        private int sumDays = 0;
        private int sumTeachers = 0;
        private int sumDepartment = 0;
        private int sumTime = 0;

        public int fitness_scaler = 100;

        private GenAlg ga;
        private int unitSize = 0;

        public Evaluator(GenAlg g, int unitLength)
        {
            this.ga = g;
            this.unitSize = unitLength;
        }


        public double evaluate(string chromosome)
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
        public double evaluateClassNumber(string chromosome)
        {
            return weight_numClasses * quantifyClassNumber(chromosome);
        }

        public int quantifyClassNumber(string chromosome)
        {
            if (getClassCount(chromosome) > 4 && getClassCount(chromosome) == 5)
                return 2;
            else if (getClassCount(chromosome) == 6)
                return 1;
            else
                return 0;
        }

        public int getClassCount(string chromosome)
        {
            return chromosome.Length / unitSize;
        }
        #endregion

        //working 4:47 P
        #region Base Fitness Calculations W/O Conflicts
        private void doSummations(string chrom)
        {
            sumDays = 0;
            sumTeachers = 0;
            sumDepartment = 0;
            sumTime = 0;

            for(int i=0; i<chrom.Length; i+=unitSize)
            {
                string sub = chrom.Substring(i, unitSize);

                sumDays += ga.getCourse(sub).val_Days;
                sumTeachers += ga.getCourse(sub).val_Teacher;
                sumDepartment += ga.getCourse(sub).val_Department;
                sumTime += ga.getCourse(sub).val_Time;
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
        private double evaluateDuplicates(string chromosome)
        {
            return weight_unduplicated * countDuplicates(chromosome);
        }

        private int countDuplicates(string chromosome)
        {
            int i = 0;
            string course1 = "";
            string course2 = "";

            for (int x = 0; x < chromosome.Length; x += unitSize)
            {
                course1 = chromosome.Substring(x, unitSize);
                int sum = 0;

                for (int y = 0; y < chromosome.Length; y += unitSize)
                {
                    course2 = chromosome.Substring(y, unitSize);

                    if (ga.getCourse(course1).bitset.Trim() == ga.getCourse(course2).bitset.Trim())
                         sum += 1;
                }

                i += sum - 1;
            }

            if (i < 0)
                throw new Exception("Day conflict less than 0.");

            //smaller number of duplicates needs a higher reward
            return 6 - i;
        }
        #endregion

        #region Conflicts
        private double evaluateConflicts(string chromosome)
        {
            return weight_unconflicted * countTimeConflicts(chromosome);
        }

        private int countTimeConflicts(string chromosome)
        {
            int i = 0;
            string course1 = "";
            string course2 = "";

            for (int x=0; x<chromosome.Length; x += unitSize)
            {
                course1 = chromosome.Substring(i, unitSize);
                int sum = 0;

                for (int y = 0; y<chromosome.Length; y += unitSize)
                {
                    course2 = chromosome.Substring(i, unitSize);

                    if (sameDays(ga.getCourse(course1).days.Trim(), ga.getCourse(course2).days.Trim()) && 
                        ga.getCourse(course1).time.Trim() == ga.getCourse(course2).time.Trim() && 
                        ga.getCourse(course1).name.Trim() != ga.getCourse(course2).name.Trim())
                    {
                        sum += 1;
                    }
                }

                i += sum;
            }

            if (i < 0)
                throw new Exception("Time conflict less than 0.");

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
