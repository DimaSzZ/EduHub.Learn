using EduHub.StudentService.Application.Services.Dto.Course;

namespace EduHub.StudentService.Application.Services.Interfaces;

public interface ICourseService
{
    public Task<CourseResponseDto> AddAsync(CourseRequestDto courseDto, CancellationToken cancellationToken);
    public Task<CourseResponseDto> UpdateAsync(CourseRequestUpdateDto courseDto, CancellationToken cancellationToken);
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    public Task<IList<CourseResponseDto>> GetListAsync(CancellationToken cancellationToken);
    
    public Task<CourseResponseDto> GetBuIdAsync(Guid id, CancellationToken cancellationToken);
}