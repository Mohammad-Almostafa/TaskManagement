namespace TaskManagement.Application.Features.Projects.DTOs;

public record ProjectDto(
    int Id,
    string Name,
    string Description,
    DateTime CreatedAt,
    DateTime UpdatedAt
);
