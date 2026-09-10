using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.Projects.Commands.CreateProject;
using TaskManagement.Application.Features.Projects.Queries.GetProjects;

namespace TaskManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly ISender _sender;

    public ProjectsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetProjects()
    {
        var result = await _sender.Send(new GetProjectsQuery());

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProjectCommand command)
    {
        var result = await _sender.Send(command);

        return Ok(result);
    }
}