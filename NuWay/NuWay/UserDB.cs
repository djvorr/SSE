using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuWay
{
    class UserDB
    {
        private List<User> users;

        /// <summary>
        /// creates a db object
        /// </summary>
        public UserDB()
        {
            users = new List<User>();
            getUsers();
        }

        /// <summary>
        /// reload the db
        /// </summary>
        public void Refresh()
        {
            users = new List<User>();
            getUsers();
        }

        /// <summary>
        /// set up the db
        /// </summary>
        private void getUsers()
        {
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(@"Users.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] strings = line.Split('.');
                User user = new User();
                user.username = strings[0];
                user.password = strings[1];
                user.role = strings[2];
                users.Add(user);
            }

            file.Close();
        }

        /// <summary>
        /// Add a user to the db
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        public void addUser(string encrypteruser, string encryptedpassword, string encryptedrole)
        {
            User temp = new User();
            temp.username = encrypteruser;
            temp.password = encryptedpassword;
            temp.role = encryptedrole;
            users.Add(temp);
            writeDb();
            Refresh();
        }

        /// <summary>
        /// Determine if user exists in the db
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>True if found, false if not</returns>
        public bool userExists(string encryptedusername, string encryptedpassword)
        {
            return getRole(encryptedusername, encryptedpassword) != "";
        }

        /// <summary>
        /// Return the encrypted role of a user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Role if found, "" if not.</returns>
        public string getRole(string encryptedusername, string encryptedpassword)
        {
            try
            {
                foreach (User user in users)
                {
                    if (user.username == encryptedusername && user.password == encryptedpassword)
                        return user.role;
                }
                return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// Checks on the availability of a username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool userTaken(string encryptedusername)
        {
            try
            {
                foreach (User user in users)
                {
                    if (user.username == encryptedusername)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// dump string version of users into text file
        /// </summary>
        public void writeDb()
        {
            string[] ready = prepList().ToArray();
            System.IO.File.WriteAllLines(@"Users.txt", ready);
        }

        /// <summary>
        /// Convert users list into string list
        /// </summary>
        /// <returns></returns>
        private List<string> prepList()
        {
            List<string> ret = new List<string>();

            foreach(User user in users)
            {
                ret.Add(user.username + "." + user.password + "." + user.role);
            }

            return ret;
        }
    }
}
