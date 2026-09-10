using Mapster;
using MediatR;
using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Application.Features.Projects.DTOs;

namespace TaskManagement.Application.Features.Projects.Queries.GetProjects;

public class GetProjectsQueryHandler
    : IRequestHandler<GetProjectsQuery, IEnumerable<ProjectDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProjectsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProjectDto>> Handle(
        GetProjectsQuery request,
        CancellationToken cancellationToken)
    {
        var projects = await _unitOfWork.Projects.GetAllAsync();

        return projects.Adapt<IEnumerable<ProjectDto>>();
    }
}