
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlogApi.ExceptionHandler
{
    public class ExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("akash");
            
            Console.WriteLine("ash");

            context.Result = new ObjectResult("500")
            {
                StatusCode = 500,
            };
            context.ExceptionHandled = true;
            
        }       
        
    }   
}