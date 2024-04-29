using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Domain.ValueObjects;

public class Phone : BaseValueObject
{
    public string ValidateFullName(Phone phone)
    {
        Guard.Against.NullOrEmpty(phone.PhoneNumber,nameof(phone.PhoneNumber));
        RegexModule.ValidatePhoneNumber(phone.PhoneNumber,nameof(phone.PhoneNumber));
        return phone.PhoneNumber;
    }
    public string PhoneNumber { get; }
}