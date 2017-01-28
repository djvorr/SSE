using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Sceduler
{
    class GenAlg
    {
        bool promptMode = false;

        List<string> lines = new List<string>();
        List<Class> classes = new List<Class>();
        List<Chromosome> chromosomes = new List<Chromosome>();

        public void main()
        {
            readFile();
            parseData();
            indexClasses();

            generateChromosomes(500);
            displayChromosomes();
            
            Console.Read();
        }



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

                chromosomes.Add(new Chromosome(chromosomeSet, Convert.ToString(classes.Count, 2).Length));
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
            else if (line.ToUpper().Contains("INDEPENDENT STUDY "))
                return "Independent Study";
            else if (line.Contains(" TR "))
                return "TR";
            else if (line.Contains(" MWF "))
                return "MWF";
            else if (line.Contains("MW"))
                return "MW";

            return "";
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
                st = line.Split('-')[2].Trim().Split(':')[0];
            }
            catch (Exception e) { }

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
            {
                Console.WriteLine(c.chromSet);
            }
        }
        #endregion
    }
}
