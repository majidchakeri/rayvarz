using Maharat.Data.DTOs.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using rayverz.Data.Entities;
using rayverz.Services.Auth;

namespace rayverz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthManager _authManager;

        public AuthController(UserManager<User> userManager, IAuthManager authManager)
        {
            _userManager = userManager;
            _authManager = authManager;
        }

        [HttpPost, Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

                var result = await _userManager.CreateAsync(new User
                {
                    UserName = registerDTO.UserName,
                    Email = $"{registerDTO.UserName}@email.com",
                    NewsletterUserStates = new List<NewsletterUserState>()
                }, registerDTO.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    return BadRequest(ModelState);
                }

                var newUser = await _userManager.FindByNameAsync(registerDTO.UserName);
                if(!await _authManager.ValidateUser(registerDTO.UserName, registerDTO.Password))
                {
                    return Unauthorized();
                }

                return Accepted(new
                {
                    Id = newUser.Id, Token = await _authManager.CreateToken(),
                });

        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _authManager.ValidateUser(userLoginDTO.UserName, userLoginDTO.Password))
            {
                return Unauthorized();
            }
            var user = _userManager.FindByNameAsync(userLoginDTO.UserName);
            if (user == null)
            {
                return NotFound();
            } else
            {
                return Accepted(new { Id = user.Id, Token = await _authManager.CreateToken()});
            }

        }
    }
}
