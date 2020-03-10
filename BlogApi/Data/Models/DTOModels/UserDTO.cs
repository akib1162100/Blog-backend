using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Data.Models
{
    public class UserDTO
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string JwtToken { get; set; }
    }
}
