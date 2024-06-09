using EduHub.StudentService.Domain.Entities.Enums;

namespace EduHub.StudentService.Application.Services.Dto.Educator;

/// <summary>
/// Дто на обновление преподавателя
/// </summary>
/// <param name="Id">Id преподавателя</param>
/// <param name="FirstName">Имя</param>
/// <param name="Surname">Фамилия</param>
/// <param name="Patronymic">Отчество</param>
/// <param name="Gender">Пол</param>
/// <param name="Phone">Телефон</param>
/// <param name="WorkExperience">Опыт работы</param>
/// <param name="DateEmployment">Дата устройства на работу</param>
public record EducatorUpdateDto(
    Guid Id,
    string FirstName,
    string Surname,
    string Patronymic,
    Gender Gender,
    string Phone,
    int YearsExperience,
    DateOnly DateEmployment
);