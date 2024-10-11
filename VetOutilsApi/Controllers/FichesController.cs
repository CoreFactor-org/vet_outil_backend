using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VetOutils.Services;

namespace VetOutilsApi.Controllers;

/// <summary>
/// This API Controller process
/// </summary>
[ApiController]
[Route("[controller]")]
[SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods")]
public sealed class FichesController : ControllerBase
{
    private readonly ILogger<FichesController> _logger;
    private readonly IGestionnaireDeFiches _gestionnaireDeFiches;

    /// <summary>
    /// Create a new SheetController
    /// </summary>
    public FichesController(ILogger<FichesController> logger, IGestionnaireDeFiches gestionnaireDeFiches)
    {
        _logger = logger;
        _gestionnaireDeFiches = gestionnaireDeFiches;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("newSheet")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult PostNewSheet([FromBody] SheetDto? dto)
    {
        if (dto == null)
        {
            return BadRequest();
        }
        return Ok("PostExemple called successfully");
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("postWithoutParamStub")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult PostWithoutParamStub()
    {
        return Ok("postWithParam called successfully");
    }

    [HttpGet]
    [AllowAnonymous]
    [Route("getWithReturnStub")]
    [Produces("application/json")]
    [ProducesResponseType<SheetDto[]>(StatusCodes.Status200OK)]
    public ActionResult<SheetDto[]> GetWithReturnStub()
    {
        return Ok(new SheetDto[]
        {
            new SheetDto { NumberProp = 1, TextProp = "Hello World 1" },
            new SheetDto { NumberProp = 2, TextProp = "Hello World 2" },
            new SheetDto { NumberProp = 3, TextProp = "Hello World 3" },
        });
    }

    [HttpGet]
    [AllowAnonymous]
    [Route("getStub")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetStub()
    {
        return Ok("getStub called successfully");
    }

}

public sealed record SheetDto
{
    public required int NumberProp { get; init; }
    public required string TextProp { get; init; }
}