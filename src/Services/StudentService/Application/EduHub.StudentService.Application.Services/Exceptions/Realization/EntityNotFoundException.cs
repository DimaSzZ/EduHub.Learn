using EduHub.StudentService.Application.Services.Exceptions.Base;

namespace EduHub.StudentService.Application.Services.Exceptions.Realization;

public class EntityNotFoundException<T> : BaseNotFoundException
{
    public EntityNotFoundException() : base(ExceptionsInfo.NotFound)
    {
    }
}