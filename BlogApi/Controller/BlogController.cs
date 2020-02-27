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
        private readonly BlogService _PostServices;
        public BlogController(BlogService service )=>_PostServices=service;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostBlogItems(BlogDTO blogDTO)
        {
            return Ok (_PostServices.Add(blogDTO));

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllBlogItems()
        {
            return Ok(_PostServices.GetAll());
        }

        [HttpGet("{blogDTO}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllBlogItem(int blogDTO)
        {      
            return Ok(_PostServices.Get(blogDTO));
        }


    }

}
