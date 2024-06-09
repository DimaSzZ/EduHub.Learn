using EduHub.StudentService.Application.Services.Dto.Student;

namespace EduHub.StudentService.Application.Services.Interfaces.Services;

public interface IStudentService
{
    /// <summary>
    /// Асинхронное добавление студента в бд
    /// </summary>
    /// <param name="studentDto">Дто курса</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возврщаете дто добавленного студента</returns>
    public Task<StudentResponseDto> AddAsync(StudentCreateDto studentDto, CancellationToken cancellationToken);
    
    /// <summary>
    /// Асинхронное обновление студента в бд
    /// </summary>
    /// <param name="studentDto">модель курса</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает дто обновленного курса</returns>
    public Task<StudentResponseDto> UpdateAsync(StudentUpdateDto studentDto, CancellationToken cancellationToken);
    
    /// <summary>
    /// Асинхронное удаление студента из бд
    /// </summary>
    /// <param name="id">id студента</param>
    /// <param name="cancellationToken">токен отмены</param>
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Асинхронное получение студентов
    /// </summary>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает дто всех студентов, которые есть в бд</returns>
    public Task<List<StudentResponseDto>> GetListAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Асинхронное получение всех студентов
    /// </summary>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает дто всех студентов</returns>
    public Task<List<StudentResponseDto>> GetListStudentsAsync(CancellationToken cancellationToken);
}