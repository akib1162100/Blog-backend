using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BlogApi.Data.Models;
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
            if(!blogDTO.IsValid())
            {
                return BadRequest();
            }
            var result = blogService.Add(blogDTO);
            if(result!=null)
            {
                return Created("localhost", result);
            }
            else
            {
                return BadRequest(); //TODO Servererror
            }
            
        }

        [HttpGet]
        public IActionResult GetAllBlogItems()
        {
            if (ModelState.IsValid)
            {
                return Ok(blogService.GetAll());
            }
            return BadRequest();
        }

        [HttpGet("{blogId}")]
        public IActionResult GetBlogItem(int blogId)
        {
            BlogDTO blogDTO = blogService.Get(blogId);
            if(blogDTO==null || !blogDTO.IsValid())
            {
                return BadRequest();
            }
            return Ok(blogDTO);
        }
    }

}
