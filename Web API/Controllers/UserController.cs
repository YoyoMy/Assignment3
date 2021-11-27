using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FileData;
using Model;
using Microsoft.EntityFrameworkCore;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<DbSet<User>>> GetUsers()
        {
            try{
                DbSet<User> users = await userService.GetUsersAsync();
                return Ok(users);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

       [HttpGet("validate")]
        public async Task<ActionResult<User>> ValidateUser([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                var user = await userService.ValidateUser(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody]User user)
        {
            try{
                await userService.AddUserAsync(user);
                return Ok();
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
