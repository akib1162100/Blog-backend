using Microsoft.EntityFrameworkCore;
using BlogApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
        public class BlogController : ControllerBase
        {
            private readonly BlogContext _context;
            public BlogController(BlogContext context)=>_context=context;

            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public ActionResult<Blog>PostBlogItems(Blog blog)
            {
                _context.Blogs.Add(blog);
                _context.SaveChanges();

                return Created("localhost", blog);
            }
    
        
        }

    }
