using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace deko1._2
{
    public class User
    {
        [JsonProperty("user_id")]
        public int UserID { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("user_type")]
        public string UserType { get; set; }

        [JsonProperty("last_login_time")]
        public DateTime LastLoginTime { get; set; }
        

    }


}
