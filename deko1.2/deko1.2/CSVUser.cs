using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;

namespace deko1._2
{
    class CSVUser : User
    {
        public List<CSVUser> readUsers(string path)
        {
            //ADD try catch block ---------------------------------------------------
            List<CSVUser> users = File.ReadAllLines(path)
                                           .Skip(1)
                                           .Select(v => CSVUser.getCSVUser(v))
                                           .ToList();
            return users;
        }


        //iterate through to get all
        public static CSVUser getCSVUser(string line)
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

        public void writeUsers<T>(IEnumerable<T> users, string path)
        {
            Type itemType = typeof(T);
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(string.Join(", ", props.Select(p => p.Name)));

                foreach (var user in users)
                {
                    writer.WriteLine(string.Join(", ", props.Select(p => p.GetValue(user, null))));
                }
            }
        }

    }
}
