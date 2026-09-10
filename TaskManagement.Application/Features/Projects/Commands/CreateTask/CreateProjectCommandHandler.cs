using Mapster;
using MediatR;
using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Application.Features.Projects.DTOs;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Features.Projects.Commands.CreateProject;

public class CreateProjectCommandHandler
    : IRequestHandler<CreateProjectCommand, ProjectDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ProjectDto> Handle(
        CreateProjectCommand request,
        CancellationToken cancellationToken)
    {
        var project = request.Adapt<Project>();

        await _unitOfWork.Projects.AddAsync(project);

        await _unitOfWork.CompleteAsync();

        return project.Adapt<ProjectDto>();
    }
}