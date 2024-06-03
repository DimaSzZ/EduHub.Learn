namespace EduHub.StudentService.Application.Services.Exceptions.Regular;

public static class RegexPatterns
{
    public const string NamePattern = @"^[\p{L}]+$";
    public const string PmrPhonePattern = @"^\+373(?:2\d{7}|[67]\d{7})$";
    public const string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    public const string FilePngJpgPattern = @"\.(png|jpg";
}