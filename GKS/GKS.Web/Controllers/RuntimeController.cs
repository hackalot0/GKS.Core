using GKS.Web.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GKS.Web.Controllers;

public class RuntimeController(IRuntimeService runtimeService) : ControllerBase
{
    [HttpGet]
    public IActionResult Stats() => Ok(runtimeService.GetStats());

    [HttpGet]
    public IActionResult Stop()
    {
        var result = runtimeService.StopRequested();
        if (!result.IsHandled) return StatusCode((int)HttpStatusCode.NotImplemented);
        if (result.IsAllowed) return Ok();
        return Forbid();
    }
}