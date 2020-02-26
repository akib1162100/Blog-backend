using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BlogApi.Data.Models;
using BlogApi.Services;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace BlogApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
        public class BlogController : ControllerBase
    {
        private readonly PostService _PostServices;
        public BlogController(PostService service )=>_PostServices=service;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostBlogItems(BlogDTO blogDTO)
        {
            return Ok (_PostServices.Add(blogDTO));

        }
            
    }

}
