using System;
using System.ComponentModel.DataAnnotations;
namespace BlogApi.Data.Models
{
    public class BlogDTO
    {
        public int Id {get;set;}
        [Required]
        [StringLength(200)]
        public string Title {get;set;}
        [Required]
        public string Body {get;set;}  
        [DataType(DataType.Date)]
        public DateTime PublishedDate {get;set;}
    }
}