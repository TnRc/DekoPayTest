using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace deko1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVUser cUser = new CSVUser();
            JSONUser jUser = new JSONUser();
            XMLUser xUser = new XMLUser();

            //reads users from data files
            List<CSVUser> cUsers = cUser.readUsers();
            List<JSONUser> jUsers = jUser.readUsers();
            List<XMLUser> xUsers = xUser.readUsers();

            //merges JSON, XML & CSV to single IEnumerable
            var allUsers = cUsers.Concat<User>(jUsers).Concat<User>(xUsers); //use union for duplicate data???-----------------------------


            List<User> users = allUsers.ToList();
            users.Sort((x, y) => x.UserID.CompareTo(y.UserID));

            //testing
            printUsers(users);
        }

        public static void printUsers(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                output(user);
            }
        }

        private static void output(User user)
        {
            System.Diagnostics.Debug.WriteLine(user.FirstName + " " + user.UserID);
        }
    }
}
