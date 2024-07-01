using EduHub.StudentService.Application.Services.Dto.Enrollment;

namespace EduHub.StudentService.Application.Services.Interfaces.Services;

public interface IEnrollmentService
{
    /// <summary>
    /// Асинхронное добавление зачисления в бд
    /// </summary>
    /// <param name="enrollmentUpsertDto">Дто зачисления</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возврщаете дто добавленного преподавателя</returns>
    public Task<EnrollmentResponseDto> AddAsync(EnrollmentUpsertDto enrollmentUpsertDto, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает все зачисления студента, с указанным id
    /// </summary>
    /// <param name="id">id студента</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает список зачислений студента</returns>
    public Task<List<EnrollmentResponseDto>> GetStudentEnrollmentsAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает все доступные зачисления
    /// </summary>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает все зачисления, что удалось получить через бд</returns>
    public Task<List<EnrollmentResponseDto>> GetListEnrollmentsAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Удаляет зачисление, с указанным id
    /// </summary>
    /// <param name="id">id зачисления</param>
    /// <param name="cancellationToken">токен отмены</param>
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}