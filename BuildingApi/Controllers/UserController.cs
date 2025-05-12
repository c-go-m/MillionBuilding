using BuildingApi.Controllers.Common;
using BusinessRules.Interface;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilities.Jwt;

namespace BuildingApi.Controllers
{
    public class UserController : BaseController<User, IUserService>
    {
        public UserController(IUserService service) : base(service)
        {
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var result = await service.ValidateUserAsync(user);
            if (!result)
            {
                return Unauthorized("Invalid username or password");
            }
            return Ok(Jwt.GenerateToken(user.UserName));
        }

    }
}
