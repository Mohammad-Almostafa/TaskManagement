using MediatR;
using TaskManagement.Application.Features.Tasks.DTOs;

namespace TaskManagement.Application.Features.Tasks.Queries.GetTaskById;

public record GetTaskByIdQuery(int Id) : IRequest<TaskDto>;