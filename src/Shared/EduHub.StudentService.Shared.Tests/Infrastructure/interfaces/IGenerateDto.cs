namespace EduHub.StudentService.Shared.Tests.Infrastructure.Interfaces;

public interface IGenerateDto<TCreate, TUpdate>
    where TCreate : class
    where TUpdate : class
{
    TCreate GetCreateDto();
    TUpdate GetUpdateDto();
}