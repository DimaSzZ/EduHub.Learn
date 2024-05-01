using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Domain.ValueObjects;

public class FullName : BaseValueObject
{
    
    public (string,string,string) ValidateFullName()
    {
        Guard.Against.NullOrEmpty(Name, nameof(Name));
        Guard.Against.NullOrEmpty(Surname, nameof(Surname));
        Guard.Against.NullOrEmpty(Patronymic, nameof(Patronymic));
        
        // Проверяем максимальную длину каждого компонента ФИО
        Guard.Against.OutOfRange(Name.Length, nameof(Name), 2, 60);
        Guard.Against.OutOfRange(Surname.Length, nameof(Surname), 2, 60);
        Guard.Against.OutOfRange(Patronymic.Length, nameof(Patronymic), 2, 60);

        return  (Name, Surname, Patronymic);
    }
    
    public string Name { get; }
    
    public string Surname { get;}
    
    public string Patronymic { get; }
}