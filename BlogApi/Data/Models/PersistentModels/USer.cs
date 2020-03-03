using System;
using System.ComponentModel.DataAnnotations;
namespace BlogApi.Data.Models
{
    public class User
    {
        public string UserID {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}