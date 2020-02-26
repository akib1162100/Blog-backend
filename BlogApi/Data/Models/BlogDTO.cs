using System;
using System.ComponentModel.DataAnnotations;
namespace BlogApi.Data.Models
{
    public class BlogDTO
    {
        [Required]
        [StringLength(200)]
        public string Title {get;set;}
        [Required]

        public string Body {get;set;}
    }
}