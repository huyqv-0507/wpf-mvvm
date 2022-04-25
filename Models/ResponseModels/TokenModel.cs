using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppLogin.Models.ResponseModels
{
    public class TokenModel
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string AccountID { get; set; }
        public string UnitID { get; set; }
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public string Phone { get; set; }
        [JsonProperty(".issued")]
        public DateTime Issued { get; set; }
        [JsonProperty(".expires")]
        public DateTime Expires { get; set; }
    }
}
