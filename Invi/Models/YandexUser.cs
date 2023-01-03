using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invi.Models
{
    public class YandexUser
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string display_name { get; set; }
        public List<string> emails { get; set; }
        public string default_email { get; set; }
        public DefaultPhone default_phone { get; set; }
        public string real_name { get; set; }
        public bool is_avatar_empty { get; set; }
        public string birthday { get; set; }
        public string default_avatar_id { get; set; }
        public List<string> openid_identities { get; set; }
        public string login { get; set; }
        public string old_social_login { get; set; }
        public string sex { get; set; }
        public string id { get; set; }
        public string client_id { get; set; }
        public string psuid { get; set; }
    }

    public class DefaultPhone
    {
        public int id { get; set; }
        public string number { get; set; }
    }
}
