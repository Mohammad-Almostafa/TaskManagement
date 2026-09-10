using Mapster;
using MediatR;
using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Application.Features.Tasks.DTOs;

namespace TaskManagement.Application.Features.Tasks.Queries.GetTasks;

public class GetTasksQueryHandler
    : IRequestHandler<GetTasksQuery, IEnumerable<TaskDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTasksQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TaskDto>> Handle(
        GetTasksQuery request,
        CancellationToken cancellationToken)
    {
        var tasks = await _unitOfWork.Tasks.GetAllAsync();

        return tasks.Adapt<IEnumerable<TaskDto>>();
    }
}