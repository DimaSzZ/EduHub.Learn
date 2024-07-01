namespace EduHub.StudentService.Shared.Tests.Infrastructure.Interfaces;

public interface IGenerateDto<out TUpsert>
    where TUpsert : class
{
    TUpsert GetUpsertDto();
}