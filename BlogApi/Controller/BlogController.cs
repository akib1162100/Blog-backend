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
        // private readonly IMapper _mapper;
        public BlogController(PostService service)=>_PostServices=service;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostBlogItems(BlogDTO blogDTO)
        {
            Blog bg= _PostServices.Add(blogDTO);

            return Created("localhost", bg);
        }
    
        
    }

    }
