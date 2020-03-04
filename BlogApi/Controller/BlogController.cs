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
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace BlogApi.Controller
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService blogService;
        public BlogController(BlogService service) => blogService = service;

        [HttpPost]
        public IActionResult PostBlogItems(BlogDTO blogDTO)
        {
            string userId = HttpContext.User.Claims.FirstOrDefault(claim=>claim.Type==System.Security.Claims.ClaimTypes.Sid).Value;
            var result = blogService.Add(blogDTO,userId);
            string relativeUri = $"{HttpContext.Request.GetDisplayUrl()}/ {result.Id.ToString()}";
            return Created(relativeUri, result);
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
            if (result == DbResponse.Updated)
            {
                return NoContent();
            }
            else if (result == DbResponse.NotFound)
            {
                return NotFound();
            }
            else if(result==DbResponse.Forbidden)
            {
                return Forbid("Not your post");
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
            if(result==DbResponse.Forbidden)
            {
                return Forbid("Not Your post");
            }
            if (result == DbResponse.Deleted)
            {
                return Ok("Successfully Deleted");
            }
            return NoContent();
        }
    }    
}
