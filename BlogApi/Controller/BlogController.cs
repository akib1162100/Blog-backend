using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BlogApi.Data.Models;
using BlogApi.Data;
using Microsoft.AspNetCore.Http.Extensions;
using BlogApi.Services;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using System;
using System.Linq;

namespace BlogApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService blogService;
        public BlogController(BlogService service) => blogService = service;

        [HttpPost]
        public IActionResult PostBlogItems(BlogDTO blogDTO)
        {
            var result = blogService.Add(blogDTO);
            string relativeUri = $"{HttpContext.Request.GetDisplayUrl()}/ {result.Id.ToString()}";
            return Created(relativeUri, result);
        }
        [HttpGet]
        public IActionResult GetAllBlogItems()
        {
            var getAllBlogs = blogService.GetAll();
            if (getAllBlogs == null)
            {
                return NotFound();
            }
            return Ok(getAllBlogs);
        }
        [HttpGet("{blogId}")]
        public IActionResult GetBlogItem(int blogId)
        {
            BlogDTO blogDTO = blogService.Get(blogId);
            if (blogDTO == null)
            {
                return NotFound();
            }
            return Ok(blogDTO);
        }

        [HttpPut]
        public IActionResult PutItem(BlogDTO blogDTO)
        {
            var result = blogService.Update(blogDTO);
            string relativeUri = $"{HttpContext.Request.GetDisplayUrl()}/ {blogDTO.Id.ToString()}";
            if (result == MessageEnum.Updated)
            {
                return NoContent();
            }
            else if (result == MessageEnum.NotFound)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }
        [HttpDelete("{blogId}")]
        public IActionResult DeletePost(int blogId)
        {
            var result = blogService.Delete(blogId);
            if (result == MessageEnum.Deleted)
            {
                return Ok("Successfully Deleted");
            }
            return NoContent();
        }
    }    
}
