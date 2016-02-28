using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuWay
{
    class Key
    {
        /// <summary>
        /// Gets the stored Encrypted Key. Decrypt locally using the shared private key.
        /// </summary>
        /// <returns></returns>
        public string EncryptedKey()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@"Key.txt");
            return file.ReadLine();
        }

        /* //create key; pretend doesnt exist.
        public void CreateKey(string passphrase)
        {
            En_De_cryption en = new En_De_cryption();
            string[] st = new string[1];
            st[0] = en.EncryptString("Kentucky", passphrase);
            System.IO.File.WriteAllLines(@"Key.txt", st);
        }*/
    }
}
