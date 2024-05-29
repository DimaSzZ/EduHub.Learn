using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Domain.ValueObjects;

namespace EduHub.StudentService.Application.Services.Dto.Educator;

public record EducatorResponseDto(Guid Id,FullName FullName, Gender Gender, Phone Phone, int WorkExperience, DateOnly DateEmployment);