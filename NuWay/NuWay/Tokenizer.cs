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
        
        //return second token
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
        /*
        public List<string> doubleTokenize(string token, char delimiter)
        {
            List<String> tokens = new List<String>();
            List<int> indexes = new List<int>();

            int i = 0;
            indexes.Add(-1);
            foreach(char c in token)
            {
                if (c == delimiter)
                    indexes.Add(i);
                i++;
            }
            indexes.Add(token.Length - 1);

            for (int k=0; k<indexes.Count-1; k++)
            {
                tokens.Add(token.Substring(indexes[k]+1,indexes[k+1]));
            }
            

            return tokens;
        }
        */
    }
}
