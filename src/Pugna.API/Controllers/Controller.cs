using Microsoft.AspNetCore.Mvc;

namespace Pugna.API.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloWorldController : ControllerBase
{
    [HttpGet(Name = "Hello World")]
    public string Get()
    {
        return "Hello World";
    }
}
