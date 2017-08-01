using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace deko1._2
{
    class Program
    {

        static void Main(string[] args)
        {
            User user = new User();
            CSVUser cUser = new CSVUser();
            JSONUser jUser = new JSONUser();
            XMLUser xUser = new XMLUser();

            //reads users from data files
            List<CSVUser> cUsers = cUser.readUsers("../../data/users.csv");
            List<JSONUser> jUsers = jUser.readUsers("../../data/users.json");
            List<XMLUser> xUsers = xUser.readUsers("../../data/users.xml");

            //merges JSON, XML & CSV to single IEnumerable
            var allUsers = user.mergeUsers(cUsers, jUsers, xUsers);

            //converted IEnumerable to List
            List<User> users = allUsers.ToList();

            //Sorted UserID in ASC
            user.sortUsersAsc(users);

            //output (testing)
            printUsers(users);

            //write new user list to data files
            cUser.writeUsers(users, "../../allData/users.csv");
            jUser.writeUsers(users, "../../allData/users.json");
            xUser.writeUsers(users, "../../allData/users.xml");



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
            System.Diagnostics.Debug.WriteLine(user.UserID + " " + user.FirstName + " " + user.LastName);
        }
    }
}
