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
        public List<Class> classes = new List<Class>();
        //List<Chromosome> chromosomes = new List<Chromosome>();
        List<string> chromosomeKeys = new List<string>();

        float mutatePercentage = 0.10f;

        int unitLength = 0;
        int chromosomeCount = 1000;
        int numberIterations = 500;
        int cap = 0;

        public void main()
        {
            readFile();
            parseData();

            //displayCourses();

            indexClasses();

            unitLength = Convert.ToString(classes.Count, 2).Length;

            generateChromosomes(chromosomeCount);

            runAlgorithm(numberIterations);

            if (debug)
            {
                Console.WriteLine("Done.");
                Console.Read();
            }
        }

        public void runAlgorithm(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Iteration: " + i);

                FitAndPurge();
                fillList();
                mutate();
            }

            grabUnique();
            //displayChromosomes();
        }

        #region Display Output
        public void grabUnique()
        {
            IEnumerable<string> unique = chromosomeKeys.Distinct();

            foreach (string s in unique)
            {
                showChromosomeDetails(s);
            }
        }

        public void showChromosomeDetails(string chromosome)
        {
            Console.WriteLine("Occurances:" + count(chromosome));

            for (int i=0; i<chromosome.Length; i += unitLength)
            {
                string course = chromosome.Substring(i, unitLength);
                Class c = getCourse(course);
                c.printDetails();
            }
        }

        public int count(string value)
        {
            int count = 0;
            foreach (string s in chromosomeKeys)
            {
                if (s == value)
                    count += 1;
            }

            return count;
        }
        #endregion

        #region Mutations
        public void mutate()
        {
            for (int i=0; i < chromosomeKeys.Count; i++)
                chromosomeKeys[i] = bitwise(chromosomeKeys[i], buildMask(chromosomeKeys[i].Length));
        }

        public string bitwise(string key, string mask)
        {
            string bitwise = "";
            for (int i=0; i<key.Length; i++)
            {
                if (mask[i] == '1')
                {
                    if (key[i] == '1')
                        bitwise += 0;
                    else
                        bitwise += 1;
                }
                else
                    bitwise += key[i];
            }

            return doctor(bitwise);
        }

        public string doctor(string chromosome)
        {
            string temp = "";
            string sub = "";

            for (int i=0; i<chromosome.Length; i+=unitLength)
            {
                sub = chromosome.Substring(i, unitLength);
                temp += examine(sub);
            }

            return temp;
        }

        public string examine(string word)
        {
            string bitset = word;
            string temp = "";
            bool MSO = false;
            while(Convert.ToInt32(bitset, 2) > classes.Count - 1)
            {
                temp = "";
                MSO = false;
                for (int i = 0; i < bitset.Length; i++)
                {
                    if (bitset[i] == '1' && !MSO)
                    {
                        temp += '0';
                        MSO = true;
                    }
                    else
                        temp += bitset[i];
                }
                bitset = temp;
            }

            return bitset;
        }

        public string buildMask(int size)
        {
            string st = "";
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                int r = rand.Next(1, 1000);
                if (r < 1000 * mutatePercentage)
                    st += "1";
                else
                    st += "0";
            }

            return st;
        }
        #endregion

        //working 3:39 P
        #region Breaking Chromosomes, Matching Halves, and Filling Empty Space
        private void fillList()
        {
            Random rand = new Random();
            
            while(chromosomeKeys.Count < chromosomeCount - cap)
            {
                string c1 = chromosomeKeys[rand.Next(chromosomeKeys.Count)];
                System.Threading.Thread.Sleep(5);
                string c2 = chromosomeKeys[rand.Next(chromosomeKeys.Count)];
                System.Threading.Thread.Sleep(5);

                chromosomeKeys.Add(getChromosome(c1, c2, false));
                chromosomeKeys.Add(getChromosome(c1, c2, true));
            }

            //int count = chromosomeKeys.Count;
            //if (count % 2 != 0)
            //    count -= 1;
            //for (int i = 0; i < count - 1; i += 1)
            //{
            //    chromosomeKeys.Add(getChromosome(chromosomeKeys[i], chromosomeKeys[i + 1], false));
            //    chromosomeKeys.Add(getChromosome(chromosomeKeys[i], chromosomeKeys[i + 1], true));
            //}

            //if (chromosomeKeys.Count < chromosomeCount)
            //{
            //    generateChromosomes(chromosomeCount - chromosomeKeys.Count);
            //}

            //if (chromosomeKeys.Count > chromosomeCount)
            //{
            //    chromosomeKeys.RemoveRange(chromosomeCount, chromosomeKeys.Count - chromosomeCount);
            //    System.Threading.Thread.Sleep(500);
            //}

            //while (chromosomeKeys.Count > chromosomeCount)
            //chromosomeKeys.Remove(chromosomeKeys[chromosomeKeys.Count - 1]);

            
        }

        private string getChromosome(string c1, string c2, bool flip)
        {
            string newChrom = "";
            if (flip)
            {
                newChrom += breakChromosome(c2, false);
                newChrom += breakChromosome(c1, true);
            }
            else
            {
                newChrom += breakChromosome(c1, false);
                newChrom += breakChromosome(c2, true);
            }

            if (newChrom == "")
                throw new Exception("Error concatenating new chromosome.");

            return newChrom;
        }

        private string breakChromosome(string chromosome, bool back)
        {
            string half = "";

            int numClasses = chromosome.Length / unitLength;
            int midpoint = 0;

            if (numClasses % 2 == 0)
                midpoint = numClasses / 2;
            else
                midpoint = (numClasses - 1) / 2;

            if (back)
            {
                for (int i = 0; i < midpoint * unitLength; i += unitLength)
                    half += chromosome.Substring(i, unitLength);
            }
            else
            {
                for (int i = midpoint * unitLength; i < chromosome.Length; i += unitLength)
                    half += chromosome.Substring(i, unitLength);
            }

            if (half == "")
                throw new Exception("Parsing Error while breaking Chromosome into halves.");

            return half;
        }
        #endregion

        //working 2:41 P
        #region Fitting and Purging
        private void FitAndPurge()
        {
            Evaluator evaluator = new Evaluator(this, unitLength);

            int threshold = getThreshold(evaluator);

            for (int i=chromosomeKeys.Count-1; i>=0; i--)
            {
                if (evaluator.evaluate(chromosomeKeys[i]) < threshold)
                    chromosomeKeys.Remove(chromosomeKeys[i]);
            }
        }

        private int getThreshold(Evaluator evaluator)
        {

            List<double> vals = new List<double>();

            foreach (string c in chromosomeKeys)
                vals.Add(evaluator.evaluate(c));

            vals.Sort();

            int thresIndex = vals.Count / 3;

            int threshold = (int)vals[vals.Count - thresIndex];

            vals.Clear();

            return threshold;
        }
        #endregion

        //working 1:46 P
        #region Generating Chromosomes
        private void generateChromosomes(int count)
        {
            string chrom = "";
            Random rand = new Random();
            for (int c = 0; c < count; c++)
            {
                chrom = "";
                int y = rand.Next(1, 7);

                for (int x = 0; x < y; x++)
                {
                    int z = rand.Next(1, classes.Count - 1);
                    if (getCourse(getBitset(z)) != null)
                        chrom += getCourse(getBitset(z)).bitset;
                    System.Threading.Thread.Sleep(5);
                }

                chromosomeKeys.Add(chrom);
            }
        }

        public Class getCourse(string bitset)
        {
            foreach (Class c in classes)
            {
                if (c.bitset == bitset)
                    return c;
            }

            throw new Exception("Null Course.");
        }

        #endregion

        //working 1:46 P
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

        //working 1:46 P
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

        //working 1:46 P
        #region Parsing Data
        public void parseData()
        {
            Class course = new Class();
            foreach (string line in lines)
            {
                if (line.Length > 1)
                {
                    course = new Class();

                    course.name = parseName(line);
                    course.days = parseDay(line);
                    course.teacher = parseTeacher(line);
                    course.department = parseDepartment(line);
                    course.time = parseTime(line);

                    course.evaluate();
                    classes.Add(course);
                }
            }

            lines.Clear();
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
            Console.WriteLine("\n\n----------------------------------------------------------------------\n\n");
            foreach (string c in chromosomeKeys)
                Console.WriteLine(c);
            Console.WriteLine("\n\n----------------------------------------------------------------------\n\n");
        }

        #endregion
    }
}
