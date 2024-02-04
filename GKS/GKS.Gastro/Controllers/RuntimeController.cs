using GKS.Gastro.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GKS.Gastro.Controllers;

public class RuntimeController(IRuntimeService runtimeService) : ControllerBase
{
    [HttpGet]
    public IActionResult Stats()
    {
        return Ok(runtimeService.GetStats());
    }
}