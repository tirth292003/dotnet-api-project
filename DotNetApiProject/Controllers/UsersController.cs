using Microsoft.AspNetCore.Mvc;
using DotNetApiProject.Models;
using DotNetApiProject.Services;

namespace DotNetApiProject.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController()
        {
            _userService = new UserService();
        }

        [HttpGet]
        public IActionResult GetUsers() => Ok(_userService.GetAllUsers());

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _userService.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_userService.UpdateUser(id, user)) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (!_userService.DeleteUser(id)) return NotFound();
            return NoContent();
        }
    }
}
