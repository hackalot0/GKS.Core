using GKS.Web.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GKS.Web.Controllers;

public class RuntimeController(IRuntimeService runtimeService) : ControllerBase
{
    [HttpGet]
    public IActionResult Stats()
    {
        return Ok(runtimeService.GetStats());
    }
}