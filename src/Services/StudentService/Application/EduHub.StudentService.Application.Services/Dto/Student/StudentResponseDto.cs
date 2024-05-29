using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Domain.ValueObjects;

namespace EduHub.StudentService.Application.Services.Dto.Student;

public record StudentResponseDto(Guid Id, string Avatar, FullName FullName, Gender Gender,
    DateOnly DateBirth, Email Email, Phone Phone, Address Address);