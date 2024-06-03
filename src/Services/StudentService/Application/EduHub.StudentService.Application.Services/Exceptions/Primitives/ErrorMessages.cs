namespace EduHub.StudentService.Application.Services.Exceptions.Primitives;

public static class ErrorMessages
{
    public const string NotFound = "{0}  not found.";
    public const string Conflict = "{0} with id '{1}' is conflicted.";
    public const string Required = "{0} is required";
    public const string MaxLength = "The object {0} has exceeded the maximum length";
    public const string MinLength = "The object {0} has exceeded the minimum length";
    public const string BadName = "The object {0} was named incorrectly";
    public const string BadPhone = "Incorrect phone number";
    public const string NotDefault = "Object gender {0} should not be default";
    public const string BadDate = "Incorrect Date";
    public const string BadEmail = "Incorrect Email";
    public const string BadFile = "Object {0} has incorrect format file";
}