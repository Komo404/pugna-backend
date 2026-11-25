using Microsoft.AspNetCore.Mvc;

namespace Pugna.API.Controllers;

public class AuthController : ControllerBase
{
    [NonAction]
    public IActionResult? Register(string accountName, string displayName, string email, string password)
    {
        return null;
    }

    [NonAction]
    public IActionResult? Login(string email, string password)
    {
        return null;
    }

    [NonAction]
    public IActionResult? Logout()
    {
        return null;
    }

    [NonAction]
    public IActionResult? Me()
    {
        return null;
    }

    [NonAction]
    public IActionResult? DeleteAccount()
    {
        return null;
    }
}
