
namespace TaskManagement.Application.Features.Tasks.DTOs;

public record TaskDto(
    int Id,
    string Title,
    string Description,
    int ProjectId
);

