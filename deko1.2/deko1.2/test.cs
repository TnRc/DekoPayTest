using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace deko1._2
{
    [Serializable()]
    public class test
    {

        public string name = "";
        public int ID = 0;

        public test(string inputName, int inputID)
        {
            name = inputName;
            ID = inputID;
        }

        public test() { }
    }
}
