namespace EduHub.StudentService.Application.Services.Exceptions.Base;

/// <summary>
/// Базовый класс исключения, служащий для выбрасывания контфликтных исключений
/// </summary>
public abstract class BaseConflictException : Exception
{
    protected BaseConflictException(string message) : base(message)
    {
    }
}