namespace EduHub.StudentService.Application.Services.Exceptions.Base;

public abstract class BaseConflictException : Exception
{
    protected BaseConflictException(string message) : base(message)
    {
    }
}