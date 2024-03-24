using Microsoft.AspNetCore.Mvc;
using user_service.DTOs.User;
using user_service.Services;

namespace user_service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;
    
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllUsers()
    {
        return Ok(_userService.GetAllUsersAsync());
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> GetUserById(Guid id)
    {
        return Ok(_userService.GetUserByIdAsync(id));
    }
    
    [HttpPost]
    public async Task<ActionResult> AddUser(UserCreateDto createDto)
    {
        return Ok(_userService.AddUserAsync(createDto));
    }
    
    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult> UpdateUser(Guid id, UserUpdateDto userUpdateDto)
    {
        return Ok(_userService.UpdateUserAsync(id, userUpdateDto));
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteUserById(Guid id)
    {
        return Ok(_userService.DeleteUserAsync(id));
    }
}