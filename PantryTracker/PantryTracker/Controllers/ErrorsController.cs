using Microsoft.AspNetCore.Mvc;

namespace PantryTracker.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}