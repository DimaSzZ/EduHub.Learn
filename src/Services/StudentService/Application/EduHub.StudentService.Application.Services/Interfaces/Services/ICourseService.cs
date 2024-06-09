using EduHub.StudentService.Application.Services.Dto.Course;

namespace EduHub.StudentService.Application.Services.Interfaces.Services;

public interface ICourseService
{
    /// <summary>
    /// Асинхронное добавление курс в бд
    /// </summary>
    /// <param name="courseDto">Дто курса</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает дто добавленного курса</returns>   
    public Task<CourseResponseDto> AddAsync(CourseCreateDto courseDto, CancellationToken cancellationToken);
    
    /// <summary>
    /// Асинхронное обновление курс в бд
    /// </summary>
    /// <param name="courseDto">модель курса</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает дто обновленного курса</returns>
    public Task<CourseResponseDto> UpdateAsync(CourseUpdateDto courseDto, CancellationToken cancellationToken);
    
    /// <summary>
    /// Асинхронное удаление курса из бд
    /// </summary>
    /// <param name="id">Id курса</param>
    /// <param name="cancellationToken">токен отмены</param>
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Асинхронное получение курсов
    /// </summary>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает дто всех курсов, которые есть в бд</returns>
    public Task<IList<CourseResponseDto>> GetListAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Асинхронное получение курса по id
    /// </summary>
    /// <param name="id">id курса</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает дто курса, полученного по id</returns>
    public Task<CourseResponseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}