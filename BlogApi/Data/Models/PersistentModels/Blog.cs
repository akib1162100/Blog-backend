using System;
using System.ComponentModel.DataAnnotations;
namespace BlogApi.Data.Models
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
        public DateTime PublishedDate {get;set;}
        public DateTime UpdationDate {get;set;}

    }
}