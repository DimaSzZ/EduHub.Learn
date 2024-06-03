using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Domain.ValueObjects;

namespace EduHub.StudentService.Application.Services.Dto.Student;

public record StudentResponseDto(
    Guid Id,
    string Avatar,
    string FirsName,
    string Surname,
    string Patronymic,
    Gender Gender,
    DateOnly DateBirth,
    Email Email,
    string Phone,
    string City,
    string Street,
    int NumberHouse
);