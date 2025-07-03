using Microsoft.AspNetCore.Mvc;
using MyCSharpProject.Model;
using MyCSharpProject.Service;

namespace MyCSharpProject.Controllers;

[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("test")]
    public string test()
    {
        return "Hello World";
    }
    
    [HttpGet]
    public async Task<List<User>> GetUser()
    {
        return await _userService.GetUsers();
    }
    
    [HttpGet("{id}")]
    public async Task<User> GetUser([FromRoute]Guid id)
    {
        return await _userService.GetUser(id);
    }
    
    [HttpPost]
    public async Task<Guid> AddUser([FromBody] User user)
    {
        user.UserId = Guid.NewGuid();
        return await _userService.AddUser(user);
    }
    
    [HttpPut("")]
    public async Task<Guid> UpdateUser([FromBody] User user)
    {
        return await _userService.UpdateUser(user);
    }
    
    [HttpDelete("{id}")]
    public async Task<Guid> DeleteUser([FromRoute] Guid id)
    {
        return await _userService.DeleteUser(id);
    }
}