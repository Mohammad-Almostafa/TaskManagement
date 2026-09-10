using MediatR;
using TaskManagement.Application.Common.Interfaces;

namespace TaskManagement.Application.Features.Tasks.Commands.DeleteTask;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTaskCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        DeleteTaskCommand request,
        CancellationToken cancellationToken)
    {
        var task = await _unitOfWork.Tasks.GetByIdAsync(request.Id);

        if (task is null)
            throw new KeyNotFoundException(
                $"Task with ID {request.Id} was not found.");

        await _unitOfWork.Tasks.DeleteAsync(task);

        await _unitOfWork.CompleteAsync();
    }
}