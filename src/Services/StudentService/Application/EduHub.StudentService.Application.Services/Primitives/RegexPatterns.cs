namespace EduHub.StudentService.Application.Services.Primitives;

public static class RegexPatterns
{
    public const string NamePattern = @"^[\p{L}\s'-]+$";
    public const string PmrPhonePattern = @"^\+373(2\d{7}|[67]\d{7})$";
    public const string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    public const string FilePngJpgPattern = @"^https?://.*\.(png|jpg)$";
}