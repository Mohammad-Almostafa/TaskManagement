using Mapster;
using MediatR;
using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Application.Features.Tasks.DTOs;

namespace TaskManagement.Application.Features.Tasks.Commands.UpdateTask;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, TaskDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTaskCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TaskDto> Handle(
        UpdateTaskCommand request,
        CancellationToken cancellationToken)
    {
        var task = await _unitOfWork.Tasks.GetByIdAsync(request.Id);

        if (task is null)
            throw new KeyNotFoundException($"Task with ID {request.Id} was not found.");

        request.Adapt(task);

        await _unitOfWork.Tasks.UpdateAsync(task);

        await _unitOfWork.CompleteAsync();

        return task.Adapt<TaskDto>();
    }
}