using AsyncInn.Models.API;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;

        public UserController(IUserService service)
        {
            userService = service;
        }


        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterUser data)
        {
            var User = await userService.Register(data, this.ModelState);
            
            if (ModelState.IsValid) return User;
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Register(LoginData data)
        {
            var user = await userService.Authenticate(data.Username, data.Password);
            if (user != null) return user;
            return Unauthorized();
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<UserDTO>> Me()
        {
            // Following the [Authorize] phase, this.User will be ... you.
            // Put a breakpoint here and inspect to see what's passed to our getUser method
            return await userService.GetUser(this.User);
        }
    }
}
