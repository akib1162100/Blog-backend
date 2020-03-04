using Microsoft.AspNetCore.Mvc;
using BlogApi.Services;
using BlogApi.Data.Models;
using BlogApi.Data;

namespace BlogApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json", new string[]{"application/xml"})]
    [Produces("application/json", new string[]{"application/xml"})] 
    public class AuthController: ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(AuthServices services)
        {
            this._authService=services;
        }
        [HttpPost("[action]")]
        public IActionResult Registration(UserRegistrationDTO userRegistrationDTO)
        {
            DbResponse status=_authService.Register(userRegistrationDTO);
            if(status==DbResponse.Added)
            {
                return Ok("Successfully Registered");
            }
            if(status==DbResponse.Exists)
            {
                return BadRequest("UserId Taken");
            }
            return BadRequest();
        }
        [HttpPost("[action]")]
        public IActionResult Login(UserLoginDTO userLoginDTO)
        {
           var result= _authService.Login(userLoginDTO);
            
            if(result.response==DbResponse.DoesNotExists)
            {
                return BadRequest("User doesn't exist");
            }
            if(result.response==DbResponse.PasswordMissmach)
            {
                return BadRequest("Invalid password");
            }
            return Ok(result.userDTO);
        }
    }
}