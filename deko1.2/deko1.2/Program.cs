using System;
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

            List<CSVUser> cUsers = cUser.readUsers();
            List<JSONUser> jUsers = jUser.readUsers();
            List<XMLUser> xUsers = xUser.readUsers();

            var allUsers = cUsers.Concat<User>(jUsers).Concat<User>(xUsers);


            printUsers(cUsers, jUsers, xUsers);
        }

        public static void printUsers(List<CSVUser> cUser, List<JSONUser> jUser, List<XMLUser> xUser)
        {
            foreach (var user in cUser)
            {
                output(user);
            }

            foreach (var user in jUser)
            {
                output(user);
            }

            foreach (var user in xUser)
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
