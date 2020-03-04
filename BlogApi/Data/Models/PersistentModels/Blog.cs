using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public User Reporter { get; set; }
        [ForeignKey("Reporter")]
        [Required]
        public string ReporterId { get; set; }

    }
}