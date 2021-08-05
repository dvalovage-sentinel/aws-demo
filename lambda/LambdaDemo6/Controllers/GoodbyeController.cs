using Microsoft.AspNetCore.Mvc;
using System;

[Route("api")]
public class GoodbyeController : ControllerBase
{
    [HttpGet, Route("goodbye")]
    public IActionResult GetHello()
    {
        return Ok("I said good day!");
    }

    [Route("/{**catchAll}")]
    public IActionResult CatchAll(string catchAll)
    {
        return NotFound($"Route not found: {catchAll}");
    }
}