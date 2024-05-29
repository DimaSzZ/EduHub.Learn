namespace EduHub.StudentService.Application.Services.Exceptions.Base;

public abstract class BaseNotFoundException : Exception
{
    protected BaseNotFoundException(string message) : base(message)
    {
    }
}