using EduHub.StudentService.Application.Services.Dto.Educator;

namespace EduHub.StudentService.Application.Services.Interfaces.Services;

public interface IEducatorService
{
    /// <summary>
    /// Асинхронное добавление преподавателя в бд
    /// </summary>
    /// <param name="educatorDto">Дто преподавателя</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возврщаете дто добавленного преподавателя</returns>
    public Task<EducatorResponseDto> AddAsync(EducatorUpsertDto educatorDto, CancellationToken cancellationToken);
    
    /// <summary>
    /// Асинхронное обновление преподавателя в бд
    /// </summary>
    /// <param name="educatorDto">модель преподавателя</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возврщаете дто обновленного преподавателя</returns>
    public Task<EducatorResponseDto> UpdateAsync(Guid id ,EducatorUpsertDto educatorDto, CancellationToken cancellationToken);
    
    /// <summary>
    /// Асинхронное удаление преподавателя из бд
    /// </summary>
    /// <param name="id">Id преподавателя</param>
    /// <param name="cancellationToken">токен отмены</param>
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Асинхронное получение преподавателей
    /// </summary>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает дто всех преподавателей, которые есть в бд</returns>
    public Task<List<EducatorResponseDto>> GetListAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Асинхронное получение преподавателя по id
    /// </summary>
    /// <param name="id">id преподавателя</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает дто преподавателя, полученного по id</returns>
    public Task<EducatorResponseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}