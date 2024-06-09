namespace EduHub.StudentService.Application.Services.Exceptions.Base;

/// <summary>
/// Базовый класс исключения, служащий для выбрасывания 404 исключений
/// </summary>
public abstract class BaseNotFoundException : Exception
{
    protected BaseNotFoundException(string message) : base(message)
    {
    }
}