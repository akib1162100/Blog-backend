using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Jwt
{
    public class JwtModel
    {
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string Key { get; set; }
        public int Expires { get; set; }
    }
}
