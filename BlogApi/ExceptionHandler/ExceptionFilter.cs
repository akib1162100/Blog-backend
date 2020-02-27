
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using BlogApi.ExceptionHandler.Model;

namespace BlogApi.ExceptionHandler
{
    public class ExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var exception = context.Exception;
            if(exception==null)
                return;
            while(exception?.InnerException!=null)
            {
                exception=exception.InnerException;
            }

            ExceptionModel exceptionModel=new ExceptionModel
            {
                Source=exception.Source,
                Message=exception.Message, 
            };
            context.Result=new ObjectResult(exceptionModel)
            {
                StatusCode=exceptionModel.Status
            };
            context.ExceptionHandled = true;
        }       
    }   
}