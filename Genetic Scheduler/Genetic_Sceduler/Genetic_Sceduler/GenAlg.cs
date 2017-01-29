using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Sceduler
{
    class GenAlg
    {
        bool debug = true;

        List<string> lines = new List<string>();
        List<Class> classes = new List<Class>();
        List<Chromosome> chromosomes = new List<Chromosome>();

        int unitLength = 0;
        int chromosomeCount = 500;
        int numberIterations = 1000;

        public void main()
        {
            readFile();
            parseData();
            indexClasses();

            unitLength = Convert.ToString(classes.Count, 2).Length;

            generateChromosomes(500);
            fitChromosomes();

            displayChromosomes();

            runAlgorithm(numberIterations);

            if (debug)
            {
                Console.WriteLine("Done.");
                Console.Read();
            }
        }

        public void runAlgorithm(int count)
        {
            for (int i=0; i<count; i++)
            {
                Console.WriteLine("Iteration: " + i);

                splitList();
                reproduceList();
                fitChromosomes();

                displayChromosomes();
            }
        }
        
        public void splitList()
        {
            int split = chromosomeCount / 3;
            List<Chromosome> newlist = new List<Chromosome>();
            
            for(int i = 0; i <= split; i++)
            {
                newlist.Add(chromosomes[i]);
            }

            chromosomes = newlist;
        }


        #region Reproduce
        public void reproduceList()
        {
            List<Chromosome> temp = chromosomes;
            int count = chromosomes.Count;
            if (temp.Count % 2 != 0)
                count -= 1;
            for (int i=0; i<temp.Count-1; i+=2)
            {
                temp.Add(createChromosome(temp[i], temp[i + 1], false));
                temp.Add(createChromosome(temp[i], temp[i + 1], true));
            }

            chromosomes = temp;
        }

        public Chromosome createChromosome(Chromosome c1, Chromosome c2, bool flip)
        {
            int midpointA = 0;
            int midpointB = 0;

            if (c1.classes.Count % 2 != 0)
                midpointA = (c1.classes.Count - 1) / 2;
            else
                midpointA = c1.classes.Count / 2;

            if (c2.classes.Count % 2 != 0)
                midpointB = (c2.classes.Count - 1) / 2;
            else
                midpointB = c2.classes.Count / 2;

            return new Chromosome(subList(c1, c2, midpointA, midpointB, flip), unitLength);
        }

        public List<Class> subList(Chromosome c1, Chromosome c2, int midpointA, int midpointB, bool flip)
        {
            List<Class> temp = new List<Class>();

            try
            {
                if (flip)
                {
                    for (int i = 0; i <= midpointA; i++)
                        temp.Add(c1.classes[i]);

                    for (int i = midpointB; i < c2.classes.Count; i++)
                        temp.Add(c2.classes[i]);
                }
                else
                {
                    for (int i = 0; i <= midpointB; i++)
                        temp.Add(c2.classes[i]);

                    for (int i = midpointA; i < c1.classes.Count; i++)
                        temp.Add(c1.classes[i]);
                }
            }
            catch (Exception e) { }

            return temp;
        }
        #endregion


        #region Fitting
        private void fitChromosomes()
        {
            foreach (Chromosome c in chromosomes)
            {
                Evaluator evaluator = new Evaluator();

                c.fitness = evaluator.evaluate(c);
            }

            sortByFitness();
        }

        private void sortByFitness()
        {
            chromosomes.Sort((Chromosome c1, Chromosome c2) => c1.fitness.CompareTo(c2.fitness));
            chromosomes.Reverse();
        }
        #endregion


        #region Generating Chromosomes
        private void generateChromosomes(int count)
        {
            for (int c=0; c<count; c++)
            {
                Random rand = new Random();
                int y = rand.Next(1, 7);
                List<Class> chromosomeSet = new List<Class>();

                for (int x=0; x<y; x++)
                {
                    int z = rand.Next(1, classes.Count - 1);
                    if (getCourse(getBitset(z)) != null)
                        chromosomeSet.Add(getCourse(getBitset(z)));
                    System.Threading.Thread.Sleep(5);
                }

                chromosomes.Add(new Chromosome(chromosomeSet, unitLength));
            }
        }

        private Class getCourse(string bitset)
        {
            foreach (Class c in classes)
            {
                if (c.bitset == bitset)
                    return c;
            }

            return null;
        }

        #endregion


        #region BitSet Generation
        private void indexClasses()
        {
            int index = 0;
            foreach(Class c in classes)
            {
                c.bitset = getBitset(index);
                index += 1;
            }
        }

        private string getBitset(int index)
        {
            string bitset = Convert.ToString(index, 2);
            int numIndexes = classes.Count();
            int numBits = Convert.ToString(numIndexes, 2).Length;
            int len = bitset.Length;

            if (bitset.Length < numBits)
            {
                for (int i = 0; i < numBits - len; i++)
                    bitset = "0" + bitset;
            }

            return bitset;
        }

        #endregion


        #region Reading Data
        public void readFile()
        {
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader("DataBase.txt");
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }

            file.Close();
        }

        public void printLines()
        {
            foreach (string st in lines)
                Console.WriteLine(st);

            Console.Read();
        }
        #endregion


        #region Parsing Data
        public void parseData()
        {
            foreach (string line in lines)
            {
                if (line.Length > 1)
                {
                    Class course = new Class();

                    course.name = parseName(line);
                    course.days = parseDay(line);
                    course.teacher = parseTeacher(line);
                    course.department = parseDepartment(line);
                    course.time = parseTime(line);

                    course.evaluate();
                    classes.Add(course);
                }
            }
        }

        private string parseName(string line)
        {
            string st = "";
            try
            {
                string[] s = line.Split('-')[0].Trim().Split(' ');

                for (int i = 3; i < s.Length; i++)
                {
                    st = st + " " + s[i];
                }
            }
            catch (Exception e) { }

            return st;
        }

        private string parseDay(string line)
        {
            if (line.ToUpper().Contains("DISTANCE LEARNING"))
                return "Distance Learning";
            else if (line.ToUpper().Contains("INDEPENDENT STUDY"))
                return "Independent Study";
            else if (line.Contains(" TR "))
                return "TR";
            else if (line.Contains(" MWF "))
                return "MWF";
            else if (line.Contains(" MW "))
                return "MW";
            else if (line.Contains(" M "))
                return "M";
            else if (line.Contains(" W "))
                return "W";
            else if (line.Contains(" R "))
                return "R";
            else if (line.Contains(" T "))
                return "T";
            else if (line.Contains(" RW "))
                return "RW";
            else
                throw new Exception("Blank or space Day.");
        }

        private string parseTeacher(string line)
        {
            string st = "";
            try
            {
                st = line.Split('-')[1].Trim().Split(' ')[1];
            }
            catch (Exception e) { }

            return st;
        }

        private string parseDepartment(string line)
        {
            string st = "";
            try
            {
                st = line.Split(' ')[1];
            }
            catch (Exception e) { }

            return st;
        }

        private string parseTime(string line)
        {
            string st = "";
            try
            {
                st = line.Trim().Split('-')[2].Trim().Split(':')[0];
            }
            catch (Exception e) { }

            if (st == " " || st == "")
                throw new Exception("Blank or space Time.");

            return st;
        }

        #endregion


        #region Debugging Displays
        public void displayCourses()
        {
            foreach (Class c in classes)
            {
                Console.WriteLine(c.bitset + " " + c.department + " " + c.name + " " + c.teacher + " " + c.days + " " + c.time);
            }
        }

        public void displayChromosomes()
        {
            foreach (Chromosome c in chromosomes)
                c.displayChromosome();
            Console.WriteLine("\n\n----------------------------------------------------------------------\n\n");
        }

        public void displayChromosomeSets()
        {
            foreach (Chromosome c in chromosomes)
            {
                Console.WriteLine(c.chromSet);
            }
        }
        #endregion
    }
}
