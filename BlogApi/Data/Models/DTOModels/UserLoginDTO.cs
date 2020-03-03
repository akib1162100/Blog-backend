using System;
using System.ComponentModel.DataAnnotations;
namespace BlogApi.Data.Models
{
    public class UserLoginDTO
    {
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "UserId should be in Alphanumeric")]
        [MinLength(6)]
        [MaxLength(100)]
        public string UserID {get;set;}
        [MinLength(6)]
        public string Password {get;set;}
    }
}