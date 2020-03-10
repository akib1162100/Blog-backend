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
using Microsoft.AspNetCore.Authorization;

namespace BlogApi.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService blogService;
        public BlogController(IBlogService service) => blogService = service;

        [HttpPost]
        public IActionResult PostBlogItems(BlogDTO blogDTO)
        {
            string userId = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid).Value;
            var result = blogService.Add(blogDTO,userId);
            string relativeUri = $"{HttpContext.Request.GetDisplayUrl()}/ {result.blogDTO.Id.ToString()}";
            if(result.response==DbResponse.DoesnotExists)
            {
                return BadRequest("User not in Database");
            }
            if(result.response==DbResponse.Failed)
            {
                return BadRequest("Post failed");
            }
            return Created(relativeUri, result.blogDTO);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllBlogItems()
        {
            var blogs = blogService.GetAll();
            if (blogs == null)
            {
                return NotFound();
            }
            return Ok(blogs);
        }
        [HttpGet("{blogId}")]
        [AllowAnonymous]
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
            string userId = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid).Value;
            var result = blogService.Update(blogDTO, userId);
            string relativeUri = $"{HttpContext.Request.GetDisplayUrl()}/ {blogDTO.Id.ToString()}";
            if (result== DbResponse.DoesnotExists)
            {
                return BadRequest("User not in Database");
            }
            if (result==DbResponse.NotAllowed)
            {
                return BadRequest("This is not your post");
            }
            if (result == DbResponse.Updated)
            {
                return Ok("Successfully Updated");
            }
            else if (result == DbResponse.NotFound)
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
            string userId = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid).Value;
            var result = blogService.Delete(blogId,userId);
            if(result==DbResponse.DoesnotExists)
            {
                return BadRequest("User not in database");
            }
            if (result == DbResponse.Deleted)
            {
                return Ok("Successfully Deleted");
            }
            return NoContent();
        }
    }    
}
