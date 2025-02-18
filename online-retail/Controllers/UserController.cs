using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using online_retail.Models.ViewModels;
using online_retail.Services.Interface;

namespace online_retail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            List<UserModel> users = await _userService.GetAll();
            return Ok(users);
        }
        [HttpGet("getById/{{id}}")]
        public async Task<IActionResult> GetById(Guid userId)
        {
            UserModel users = await _userService.GetById(userId);
            return Ok(users);
        }
        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserModel userModel)
        {
            UserModel createdUser = await _userService.CreateUser(userModel);
            return Ok(createdUser);
        }
        [HttpDelete("deleteUser/{{id}}")]
        public async Task<IActionResult> DeleteUserById(Guid id)
        {
            bool isDeleted = await _userService.DeleteUserById(id);

            if (!isDeleted)
                return NotFound(new { message = "User not found" });

            return Ok(new { message = "User deleted successfully" });
        }
        [HttpPut("updateUserById/{{id}}")]
        public async Task<IActionResult> UpdateUserById(Guid id, [FromBody] UserModel updatedUser)
        {
            if (updatedUser == null)
            {
                return BadRequest("User data is required.");
            }

            var existingUser = _userService.GetById(id);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            UserModel user = await _userService.UpdateUserById(id, updatedUser);
            return Ok(user);
        }

    }

}

