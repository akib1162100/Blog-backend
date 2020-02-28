using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BlogApi.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using BlogApi.Services;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using System;

namespace BlogApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
        public class BlogController : ControllerBase
    {
        private readonly IBlogService blogService;
        public BlogController(BlogService service)=>blogService=service;

        [HttpPost]
        public IActionResult PostBlogItems(BlogDTO blogDTO)
        {
            if (ModelState.IsValid && blogDTO.IsValid())
            {
                var result = blogService.Add(blogDTO);
                string relativeUri = $"{HttpContext.Request.GetDisplayUrl()}/ {result.Id.ToString()}";
                return Created(relativeUri, result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetAllBlogItems()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getAllBlogs = blogService.GetAll();
            if(getAllBlogs==null)
            {
                return NotFound();
            }
            return Ok(getAllBlogs);
        }

        [HttpGet("{blogId}")]
        public IActionResult GetBlogItem(int blogId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            BlogDTO blogDTO = blogService.Get(blogId);
            if(blogDTO==null)
            {
                return NotFound();
            }
            return Ok(blogDTO);
        }

        [HttpPut]
        public IActionResult PutItem(BlogDTO blogDTO)
        {
            if (ModelState.IsValid && blogDTO.IsValid())
            {
                var result = blogService.Update(blogDTO);
                string relativeUri = $"{HttpContext.Request.GetDisplayUrl()}/ {blogDTO.Id.ToString()}";
                if(result!=0)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest(); //TODO: sending proper Response 
                }
            }
            else
            {
                return BadRequest();
            }
        }
       
    }

}
