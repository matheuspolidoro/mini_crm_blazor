using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mini_CRM_Blazor.Server.Models;
using Mini_CRM_Blazor.Server.Services;
using Mini_CRM_Blazor.Shared.Models;

namespace Mini_CRM_Blazor.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationUsersService _applicationUsersService;
        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationUsersService applicationUsersService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationUsersService = applicationUsersService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) return BadRequest("User does not exist");

            var singInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!singInResult.Succeeded) return BadRequest("Invalid password");

            await _signInManager.SignInAsync(user, request.RememberMe);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest parameters)
        {
            var user = new ApplicationUser
            {
                UserName = parameters.UserName,
                Email = parameters.Email,
            };
            var result = await _userManager.CreateAsync(user, parameters.Password);
            if (!result.Succeeded) return BadRequest(result.Errors.FirstOrDefault()?.Description);

            return await Login(new LoginRequest
            {
                Email = parameters.Email,
                Password = parameters.Password
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet]
        public CurrentUser CurrentUserInfo()
        {
            return new CurrentUser
            {
                IsAuthenticated = User.Identity.IsAuthenticated,
                UserName = User.Identity.Name,
                Claims = User.Claims
                .ToDictionary(c => c.Type, c => c.Value)
            };
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToRole(string userEmail, string role)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var result = await _applicationUsersService.AddUserToRole(userEmail, role);
                
                if(result.Sucess)
                    return Ok(result);

                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
