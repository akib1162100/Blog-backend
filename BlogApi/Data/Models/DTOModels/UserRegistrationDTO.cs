using System;
using System.ComponentModel.DataAnnotations;
namespace BlogApi.Data.Models
{
    public class UserRegistrationDTO
    {
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "UserId should be in Alphanumeric")]
        [MinLength(6)]
        [MaxLength(100)]
        public string UserID {get;set;}
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "FirstName should be in Alphabate")]
        [MinLength(3)]
        [MaxLength(100)]
        public string FirstName {get;set;}
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "LastName should be in Alphabate")]
        [MinLength(3)]
        [MaxLength(100)]
        public string LastName {get;set;}
        [MinLength(6)]
        public string? Password {get;set;}
    }
}