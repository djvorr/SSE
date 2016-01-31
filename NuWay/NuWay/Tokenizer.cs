using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuWay
{
    class Tokenizer
    {
        private String token = " ";

        public Tokenizer(string token)
        {
            this.token = token;
        }

        public string tokenize(char delimiter)
        {
            string result = "";
            bool found = false;

            foreach (Char c in token)
            {
                if (found == true)
                    result += c.ToString();
                if (c == delimiter)
                    found = true;
            }

            return result;
        }
    }
}
