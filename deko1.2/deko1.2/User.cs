using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace deko1._2
{
    [Serializable]
    [XmlRoot("Root")]
    public class User
    {
        [JsonProperty("user_id")]
        [XmlElement("userid")]
        public int UserID { get; set; }

        [JsonProperty("first_name")]
        [XmlElement("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        [XmlElement("surname")]
        public string LastName { get; set; }

        [JsonProperty("username")]
        [XmlElement("username")]
        public string Username { get; set; }

        [JsonProperty("user_type")]
        [XmlElement("type")]
        public string UserType { get; set; }

        [JsonProperty("last_login_time")]
        [XmlElement("lastlogintime")]
        public DateTime LastLoginTime { get; set; }

        public User() { }

        public User(int id)
        {
            UserID = id;
        }

        public void sortUsersAsc(List<User> users)
        {
            users.Sort((x, y) => x.UserID.CompareTo(y.UserID));
        }

        public IEnumerable<User> mergeUsers(List<CSVUser> cUsers, List<JSONUser> jUsers, List<XMLUser> xUsers)
        {

            return cUsers.Concat<User>(jUsers).Concat<User>(xUsers); //use union for duplicate data???;
        }

        //public void CSVUser(int id, string fname, string lname, string username, string type, DateTime login)
        //{
        //    UserID = id;
        //    FirstName = fname;
        //    LastName = lname;
        //    Username = username;
        //    UserType = type;
        //    LastLoginTime = login;
        //}

    }


}
