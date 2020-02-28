using System;
using System.ComponentModel.DataAnnotations;
namespace BlogApi.Data.Models
{
    public class BlogDTO
    {
        public int? Id {get;set;}
       
        public string Title {get;set;}
        public string Body {get;set;}  
        public DateTime PublishedDate {get;set;}
        public bool IsValid()
        {
            if(Title==null || Body==null || PublishedDate==null)
            {
                return false;
            }
            return true;
        }
    }
}