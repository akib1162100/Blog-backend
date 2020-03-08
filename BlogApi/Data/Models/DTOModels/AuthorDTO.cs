using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Data.Models
{
    public class AuthorDTO
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string FullName { get; set; }
    }
}
