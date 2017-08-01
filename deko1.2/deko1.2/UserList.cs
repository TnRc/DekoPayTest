using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace deko1._2
{
    //class is used to write users to xml file
    [XmlRoot("UserList")]
    public class UserList
    {
        [XmlArray("users"), XmlArrayItem(typeof(User), ElementName = "user")]
        public List<User> Users { get; set; }
    }
}
