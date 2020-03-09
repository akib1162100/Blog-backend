using BlogApi.Data;
using BlogApi.Data.Models;
using BlogApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private IUserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost("[action]")]
        public IActionResult Registration(UserRegisterDTO registerDTO)
        {
            DbResponse status = _userService.Registration(registerDTO);
            if (status == DbResponse.Exists)
            {
                return BadRequest("UserId Taken");
            }
            if (status == DbResponse.Added)
            {
                return Ok("Successfully Registered");
            }
            return BadRequest();
        }
        [HttpPost("[action]")]
        public IActionResult Login(UserLoginDTO userLoginDTO)
        {
            var result = _userService.Login(userLoginDTO);
            if (result.response == DbResponse.DoesnotExists)
            {
                return BadRequest("User not in Database");
            }
            if (result.response == DbResponse.Failed)
            {
                return BadRequest("Password is not valid");
            }
            return Ok(result.userDTO.JwtToken);
        }
    }
}
