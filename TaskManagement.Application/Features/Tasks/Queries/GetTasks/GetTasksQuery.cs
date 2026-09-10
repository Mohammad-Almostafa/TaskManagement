using MediatR;
using TaskManagement.Application.Features.Tasks.DTOs;

namespace TaskManagement.Application.Features.Tasks.Queries.GetTasks;

public record GetTasksQuery : IRequest<IEnumerable<TaskDto>>;