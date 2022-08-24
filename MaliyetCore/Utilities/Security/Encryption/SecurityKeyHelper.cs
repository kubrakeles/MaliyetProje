using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaliyetCore.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string SecurityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey)); //symnenic bizim security key imizi oluşturduğumuz 
        }
    }
}
