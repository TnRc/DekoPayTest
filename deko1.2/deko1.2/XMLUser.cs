using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace deko1._2
{
    public class XMLUser : User
    {
        public List<XMLUser> readUsers()
        {
            string path = "../../data/users.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            
            List<XMLUser> users = new List<XMLUser>();

            foreach (XmlNode node in doc.DocumentElement)
            {
                XMLUser user = new XMLUser();
                user.UserID = int.Parse(node["userid"].InnerText);
                user.FirstName = node["firstname"].InnerText;
                user.LastName = node["surname"].InnerText;
                user.Username = node["username"].InnerText;
                user.UserType = node["type"].InnerText;
                user.LastLoginTime = DateTime.Parse(node["lastlogintime"].InnerText);

                users.Add(user);
            }

            return users;

        }
    }
}
