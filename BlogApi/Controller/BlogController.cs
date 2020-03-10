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
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService blogService;
        public BlogController(IBlogService service) => blogService = service;

        public string FindUserIdFromJwt()
        {
            string userId = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid).Value;
            return userId;
        }
        [HttpPost]
        public IActionResult PostBlogItems(BlogDTO blogDTO)
        {
            string userId = FindUserIdFromJwt();
            var result = blogService.Add(blogDTO,userId);
            string relativeUri = $"{HttpContext.Request.GetDisplayUrl()}/ {result.blogDTO.Id.ToString()}";
            return Created(relativeUri, result.blogDTO);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllBlogItems()
        {
            var blogDTOs = blogService.GetAll();
            return Ok(blogDTOs);
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
            string userId = FindUserIdFromJwt();
            var result = blogService.Update(blogDTO, userId);
            if (result==DbResponse.NotAllowed)
            {
                return Forbid("This is not your post");
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
            string userId = FindUserIdFromJwt();
            var result = blogService.Delete(blogId,userId);
            if (result == DbResponse.Deleted)
            {
                return Ok("Successfully Deleted");
            }
            if(result==DbResponse.NotFound)
            {
                return BadRequest("Blog not found");
            }
            if(result==DbResponse.NotAllowed)
            {
                return Forbid("This is not your post");
            }
            return NoContent();
        }
    }    
}
