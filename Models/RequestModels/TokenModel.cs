using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppLogin.Models.RequestModels
{
    public class TokenModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string GrantType { get; set; } = "password";
        public int Type { get; set; } = 0;
    }
}
