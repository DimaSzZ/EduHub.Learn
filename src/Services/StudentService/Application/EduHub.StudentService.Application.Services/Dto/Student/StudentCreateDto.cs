using EduHub.StudentService.Domain.Entities.Enums;

namespace EduHub.StudentService.Application.Services.Dto.Student;

/// <summary>
/// Дто на создание студента
/// </summary>
/// <param name="Avatar">ссылка на аватарку</param>
/// <param name="FirstName">Имя</param>
/// <param name="Surname">Фамилия</param>
/// <param name="Patronymic">Отчество</param>
/// <param name="Gender">Пол</param>
/// <param name="DateBirth">Дата рождения</param>
/// <param name="Email">Почтовый ящик</param>
/// <param name="Phone">Номер</param>
/// <param name="City">Город</param>
/// <param name="Street">Улица</param>
/// <param name="NumberHouse">Номер дома</param>
public record StudentCreateDto(
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