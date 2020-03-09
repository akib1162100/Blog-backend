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
        [RegularExpression(@"^[a-zA-Z0-9]*$",
        ErrorMessage = "Id format is incorrect.")]
        [MinLength(5)]
        public string UserId { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]*$",
        ErrorMessage = "Name format is incorrect.")]
        public string FullName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]*$",
        ErrorMessage = "Password format is incorrect.")]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
