using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deko1._2
{
    class CSVUser : User
    {
        public List<CSVUser> readUsers()
        {
            //ADD try catch block ---------------------------------------------------
            List<CSVUser> users = File.ReadAllLines("../../data/users.csv")
                                           .Skip(1)
                                           .Select(v => CSVUser.setUser(v))
                                           .ToList();
            return users;
        }


        //iterate through to get all
        public static CSVUser setUser(string line)
        {
            string[] values = line.Split(',');
            CSVUser user = new CSVUser();
            user.UserID = Convert.ToInt16(values[0]);
            user.FirstName = Convert.ToString(values[1]);
            user.LastName = Convert.ToString(values[2]);
            user.Username = Convert.ToString(values[3]);
            user.UserType = Convert.ToString(values[4]);
            user.LastLoginTime = Convert.ToDateTime(values[5]);

            return user;
        }
    }
}
