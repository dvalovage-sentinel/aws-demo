using Microsoft.AspNetCore.Mvc;
using System;

[Route("api")]
public class HelloController : ControllerBase
{
    [HttpGet, Route("hello")]
    public IActionResult GetHello()
    {
        return Ok("You got hello!");
    }

    [HttpGet, Route("hello2")]
    public IActionResult GetHello2()
    {
        return Ok("You got hello too!");
    }
}