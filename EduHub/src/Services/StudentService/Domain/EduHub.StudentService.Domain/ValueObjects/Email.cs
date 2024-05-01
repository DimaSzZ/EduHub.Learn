using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Domain.ValueObjects;

public class Email : BaseValueObject
{
    public string ValidateEmail(Email email)
    {
        Guard.Against.NullOrEmpty(email.EmailValue,nameof(email.ValidateEmail));
        return email.EmailValue;
    }
    
    public string EmailValue { get; }
}