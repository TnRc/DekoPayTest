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
    [Serializable()]
    public class XMLUser : User
    {
        public XMLUser() { }

        public List<XMLUser> readUsers(string path)
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

        //public void writeUsers<T>(IEnumerable<T> users, string path)
        //{
        //    if (users == null) { return; }

        //    try
        //    {
        //        XmlDocument xmlDocument = new XmlDocument();
        //        XmlSerializer serializer = new XmlSerializer(users.GetType());
        //        using (MemoryStream stream = new MemoryStream())
        //        {
        //            serializer.Serialize(stream, users);
        //            stream.Position = 0;
        //            xmlDocument.Load(stream);
        //            xmlDocument.Save(path);
        //            stream.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log exception here
        //    }
        //}

        
        public void writeUsers<T>(T users, string path, bool append = false) where T : new()
        {
            //TextWriter writer = null;
            var writer = new XmlSerializer(users.GetType());

            try
            {
                //var serializer = new XmlSerializer(typeof(T));
                //writer = new StreamWriter(path, append);
                //serializer.Serialize(writer, users);

                
                var file = new StreamWriter(path);
                writer.Serialize(file, users);

            }
            finally
            {
                //if (writer != null)
                //    writer.Close();
            }
        }
    }
}
