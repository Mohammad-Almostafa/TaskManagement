using MediatR;
using TaskManagement.Application.Features.Projects.DTOs;

namespace TaskManagement.Application.Features.Projects.Queries.GetProjects;

public record GetProjectsQuery : IRequest<IEnumerable<ProjectDto>>;