using MegaTec_Task.DTOs;
using MegaTec_Task.Models;
using MegaTec_Task.Services;
using Microsoft.AspNetCore.Mvc;

namespace MegaTec_Task.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PeopleController : ControllerBase
{
    private readonly IPersonService _personService;

    public PeopleController(IPersonService personService)
    {
        ArgumentNullException.ThrowIfNull(personService);
        _personService = personService;
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<ActionResult<Person>> Create([FromForm] PersonCreateDto dto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        try
        {
            var person = await _personService.CreatePersonAsync(dto, cancellationToken);
            return StatusCode(StatusCodes.Status201Created, person);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Person>>> GetAll(CancellationToken cancellationToken)
    {
        var people = await _personService.GetAllPeopleAsync(cancellationToken);
        return Ok(people);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IReadOnlyList<Person>>> Search([FromQuery] string? name, CancellationToken cancellationToken)
    {
        var people = await _personService.SearchByNameAsync(name ?? string.Empty, cancellationToken);
        return Ok(people);
    }

    [HttpGet("export-pdf")]
    public async Task<IActionResult> ExportPdf(CancellationToken cancellationToken)
    {
        var pdf = await _personService.ExportPeoplePdfAsync(cancellationToken);
        return File(pdf, "application/pdf", "people.pdf");
    }
}
