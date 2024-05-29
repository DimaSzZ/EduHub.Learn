using EduHub.StudentService.Application.Services.Exceptions.Base;

namespace EduHub.StudentService.Application.Services.Exceptions.Realization;

public class EntityConflictException<T> : BaseConflictException
{
    public EntityConflictException() : base(ExceptionsInfo.Conflict)
    {
    }
}