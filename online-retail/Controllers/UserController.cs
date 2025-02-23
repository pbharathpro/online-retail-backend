using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using online_retail.Models.ViewModels;
using online_retail.Repositories.Entities;
using online_retail.Services.Interface;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [Authorize(Roles = "admin")]
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        List<UserModel> users = await _userService.GetAll();
        return Ok(users);
    }

    [Authorize] 
    [HttpGet("getProfile")]
    public async Task<IActionResult> GetProfile()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return Unauthorized(new { message = "Invalid token" });

        var user = await _userService.GetById(Guid.Parse(userId));
        return Ok(user);
    }

    [Authorize(Roles = "admin")]
    [HttpPost("createUser")]
    public async Task<IActionResult> CreateUser([FromBody] UserModel userModel)
    {
        UserModel createdUser = await _userService.CreateUser(userModel);
        return Ok(createdUser);
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("deleteUser/{id}")]
    public async Task<IActionResult> DeleteUserById(Guid id)
    {
        bool isDeleted = await _userService.DeleteUserById(id);
        if (!isDeleted)
            return NotFound(new { message = "User not found" });

        return Ok(new { message = "User deleted successfully" });
    }
}
