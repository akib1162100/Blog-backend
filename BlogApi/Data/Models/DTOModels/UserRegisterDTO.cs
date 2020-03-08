using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Data.Models
{
    public class UserRegisterDTO
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z1-10]{6,40}$",
        ErrorMessage = "Id format is in correct.")]
        public string UserId { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]{1,50}$",
        ErrorMessage = "Name format is in correct.")]
        public string FullName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z1-10@#$%&*]{6,40}$",
        ErrorMessage = "Password format is in correct.")]
        public string Password { get; set; }
    }
}
