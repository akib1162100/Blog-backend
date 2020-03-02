using System;
using System.ComponentModel.DataAnnotations;
namespace BlogApi.Data.Models
{
    public class BlogDTO
    {
        public int? Id {get;set;}
        [Required]
        public string Title {get;set;} 
        [Required]
        public string Body {get;set;}  
        [Required]
        public DateTime PublishedDate {get;set;}
    }
}