using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuWay
{
    class CustomMeals
    {
        private string meal1;
        private string meal2;
        private string meal3;
        private string meal4;
        private string meal5;
        private string meal6;
        private string meal7;
        private string meal8;
        private string meal9;
        private string meal10;

        public CustomMeals(string meal1, string meal2, string meal3, string meal4, string meal5, string meal6, string meal7, string meal8, string meal9, string meal10)
        {
            this.meal1 = meal1;
            this.meal2 = meal2;
            this.meal3 = meal3;
            this.meal4 = meal4;
            this.meal5 = meal5;
            this.meal6 = meal6;
            this.meal7 = meal7;
            this.meal8 = meal8;
            this.meal9 = meal9;
            this.meal10 = meal10;
        }

        public string Meal1 { get { return meal1; } }
        public string Meal2 { get { return meal2; } }
        public string Meal3 { get { return meal3; } }
        public string Meal4 { get { return meal4; } }
        public string Meal5 { get { return meal5; } }
        public string Meal6 { get { return meal6; } }
        public string Meal7 { get { return meal7; } }
        public string Meal8 { get { return meal8; } }
        public string Meal9 { get { return meal9; } }
        public string Meal10 { get { return meal10; } }

    }
}
