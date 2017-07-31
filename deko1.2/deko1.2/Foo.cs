using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace deko1._2
{
    [XmlRoot("Root")]
    public class Foo
    {
        [XmlArray("users"), XmlArrayItem(typeof(Bar), ElementName = "user")]
        public List<Bar> BarList { get; set; }
    }
    
}
