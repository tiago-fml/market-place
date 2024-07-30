using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using user_service.DTOs.User;
using user_service.Services;

namespace user_service.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] //(Roles = "Admin")
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetAllUsers()
    {
        try
        {
            return Ok(await userService.GetAllUsersAsync());
        }
        catch (Exception e)
        {
            return BadRequest($"Error in method {nameof(GetAllUsers)}" + e.Message);
        }
    }
    
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult> GetUserById(Guid id)
    {
        try
        {
            var user = await userService.GetUserByIdAsync(id);
            if (user != null)
            {
                return Ok(user);
            }
            
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest($"Error in method {nameof(GetUserById)}" + e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult> AddUser(UserCreateDto createDto)
    {
        try
        {
            return Ok(await userService.AddUserAsync(createDto));
        }
        catch (Exception e)
        {
            return BadRequest($"Error in method {nameof(AddUser)}" + e.Message);
        }
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateUser(Guid id, UserUpdateDto userUpdateDto)
    {
        try
        {
            var updatedUser = await userService.UpdateUserAsync(id, userUpdateDto);
            if (updatedUser != null)
            {
                return Ok();
            }

            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest($"Error in method {nameof(UpdateUser)}" + e.Message);
        }
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteUserById(Guid id)
    {
        try
        {
            var deletedUser = await userService.DeleteUserAsync(id);
            if (deletedUser != null)
            {
                return Ok(deletedUser);
            }
            
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest($"Error in method {nameof(DeleteUserById)}" + e.Message);
        }
    }
}