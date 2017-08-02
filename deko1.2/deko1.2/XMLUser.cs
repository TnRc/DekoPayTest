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
    [Serializable]
    public class XMLUser : User
    {
        public XMLUser() { }

        public List<XMLUser> readUsers(string path)
        {
            try
            {
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
            catch (IOException e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return null;
            }

        }

        public void writeUsers(IEnumerable<User> ieUsers, string path)
        {
            List<User> users = new List<User>();
            users = ieUsers.ToList();
            try
            {
                UserList userList = new UserList();
                userList.Users = new List<User>();

                foreach (var user in users)
                {
                    userList.Users.Add(new User()
                    {
                        UserID = user.UserID,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Username = user.Username,
                        UserType = user.UserType,
                        LastLoginTime = user.LastLoginTime
                    });
                }

                //removes the xsi and xsd in root tag
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
                XmlSerializer serializer = new XmlSerializer(typeof(UserList));
                serializer.Serialize(stream, userList, ns);
                stream.Dispose();
            }
            catch (IOException e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }
    }
}
