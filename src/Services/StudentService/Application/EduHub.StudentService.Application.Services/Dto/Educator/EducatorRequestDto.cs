using EduHub.StudentService.Domain.Entities.Enums;

namespace EduHub.StudentService.Application.Services.Dto.Educator;

public record EducatorRequestDto(string FirstName, string Surname, string Patronymic, Gender Gender, string Phone, int WorkExperience, DateOnly DateEmployment);