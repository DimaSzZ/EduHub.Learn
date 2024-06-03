using EduHub.StudentService.Domain.Entities.Enums;

namespace EduHub.StudentService.Application.Services.Dto.Student;

public record StudentRequestUpdateDto(
    Guid Id,
    string Avatar,
    string FirstName,
    string Surname,
    string Patronymic,
    Gender Gender,
    DateOnly DateBirth,
    string Email,
    string Phone,
    string City,
    string Street,
    int NumberHouse
);