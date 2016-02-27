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

        public UserDB()
        {
            users = new List<User>();
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
            System.IO.StreamReader file = new System.IO.StreamReader("c:\\test.txt");
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
        public void addUser(string user, string password, string role)
        {
            User temp = new User();
            temp.username = user;
            temp.password = password;
            temp.role = role;
            users.Add(temp);

        }

        /// <summary>
        /// Determine if user exists in the db
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool userExists(string username, string password)
        {
            return getRole(username, password) != "";
        }

        /// <summary>
        /// Return the role of a user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string getRole(string username, string password)
        {
            try
            {
                foreach (User user in users)
                {
                    if (user.username == username && user.password == password)
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
        public bool userTaken(string username)
        {
            try
            {
                foreach (User user in users)
                {
                    if (user.username == username)
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
