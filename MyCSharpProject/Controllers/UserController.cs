using Microsoft.AspNetCore.Mvc;

namespace MyCSharpProject.Controllers;

public class UserController : ControllerBase
{
    [HttpGet("")]
    public List<string> GetUser()
    {
        return new List<string>()
        {
            "Toan", "Khanh", "Le"
        };
    }
}