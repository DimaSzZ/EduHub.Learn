using EduHub.StudentService.Application.Services.Dto.Course;

namespace EduHub.StudentService.Application.Services.Interfaces.Services;

public interface ICourseService
{
    public Task<CourseResponseDto> AddAsync(CourseCreateDto courseDto, CancellationToken cancellationToken);
    public Task<CourseResponseDto> UpdateAsync(CourseUpdateDto courseDto, CancellationToken cancellationToken);
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    public Task<IList<CourseResponseDto>> GetListAsync(CancellationToken cancellationToken);
    
    public Task<CourseResponseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}