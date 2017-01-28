using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Sceduler
{
    class Class
    {
        public string bitset = "";
        public string name = "";
        public string days = "";
        public string teacher = "";
        public string department = "";
        public string time = "";

        public int val_Days = 0;
        public int val_Teacher = 0;
        public int val_Department = 0;
        public int val_Time = 0;

        public void evaluate()
        {
            evalDays();
            evalDepartment();
            evalTeacher();
            evalTime();
        }

        private void evalDays()
        {
            if (days == "MWF")
                val_Days = 3;
            else if (days == "MW")
                val_Days = 2;
            else if (days == "TH")
                val_Days = 1;
            else
                val_Days = 0;
        }

        private void evalTeacher()
        {
            if (teacher == "MacNeil" || teacher == "Ekong" || teacher == "Barnett" || teacher == "Choi" || teacher == "Allen")
                val_Teacher = 3;
            else if (teacher == "Hamby" || teacher == "McClellan" || teacher == "Cozart" || teacher == "Hill" || teacher == "Mines")
                val_Teacher = 2;
            else if (teacher == "Jenkins" || teacher == "Moses" || teacher == "Sumner" || teacher == "Moody" || teacher == "Zhao")
                val_Teacher = 1;
            else
                val_Teacher = 0;
        }

        private void evalDepartment()
        {
            if (department == "EGR" || department == "ECE")
                val_Department = 2;
            else if (department == "CSC")
                val_Department = 1;
            else
                val_Department = 0;
        }

        private void evalTime()
        {
            int timeInt = -1;

            bool pass = Int32.TryParse(time, out timeInt);

            if (pass)
            {
                if (timeInt < 10 && timeInt > 6)
                    val_Time = 0;
                else if (timeInt == 11 || timeInt == 12 || timeInt == 1)
                    val_Time = 2;
                else if (timeInt == -1)
                    val_Time = 3;
                else
                    val_Time = 1;
            }
            else
            {
                if (time == "Distance Learning")
                    val_Time = 5;
                else if (time == "Independent Study")
                    val_Time = 4;
            }
        }
    }
}
