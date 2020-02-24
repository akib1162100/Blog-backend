using System;
using System.ComponentModel.DataAnnotations;
namespace BlogApi.Models
{
    public class Blog
    {
        public int Id {get;set;}
        [Required]
        [StringLength(200)]
        public string Title {get;set;}
        [Required]

        public string Body {get;set;}
        [Required]
        [DataType(DataType.Date)]
        public DateTime publishedDate {get;set;}
        public DateTime updationDate {get;set;}

    }
}