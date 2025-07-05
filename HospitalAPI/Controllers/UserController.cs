using HospitalBusiness.Interfaces; 
using HospitalModels.DTOs;
using HospitalModels.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

//-----for -----register-------//
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            await _userManager.RegisterAsync(userDTO);
            return Ok(new { message = "Registration Successfully " });
        }

//-------for---login-----//
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserDTO userDto)
        {
            var user = await _userManager.AuthenticateAsync(userDto);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            return Ok(new
            {
                message = "Login successful",
                username = user.Username
                // Note:----- Never return password in response in real-world apps-----//
            });
        }
    }
}
