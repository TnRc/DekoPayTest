using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deko1._2
{
    class JSONUser : User
    {

        public List<JSONUser> readUsers()
        {
            using (StreamReader r = new StreamReader("../../data/users.json"))
            {
                string json = r.ReadToEnd();
                var format = "dd-MM-yyyy HH:mm:ss"; // datetime format
                var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
                List<JSONUser> users = JsonConvert.DeserializeObject<List<JSONUser>>(json, dateTimeConverter);
                return users;
            }
        }
    }
}

