using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.models
{
    class UserAccount
    {
        [JsonProperty(PropertyName = "userId")]
        public int UserId { get; set; }
        [JsonProperty(PropertyName = "username")]
        public String Username { get; set; }
        [JsonProperty(PropertyName = "password")]
        public String Password { get; set; }
        [JsonProperty(PropertyName = "url")]
        public String Url { get; set; }
        [JsonProperty(PropertyName = "database")]
        public String Database { get; set; }
        
        [JsonProperty(PropertyName = "fullname")]
        public String FullName { get; set; }
        [JsonProperty(PropertyName = "partnerId")]
        public int PartnerId { get; set; }
        [JsonProperty(PropertyName = "role")]
        public string Role { get; set; }
        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        public UserAccount() { }

        public UserAccount(String url, String database, int uid, int partnerId, String username, String password, string image,string role)
        {
            this.UserId = uid;
            this.Url = url;
            this.Database = database;            
            this.Password = password;
            this.Role = role;
            this.FullName = username;
            this.PartnerId = partnerId;
            this.Image = image;
            
        }
    }
}
