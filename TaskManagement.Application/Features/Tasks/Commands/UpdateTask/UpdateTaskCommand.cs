using MediatR;
using TaskManagement.Application.Features.Tasks.DTOs;

public record UpdateTaskCommand(
    int Id,
    string Title,
    string Description,
    int ProjectId
) : IRequest<TaskDto>;