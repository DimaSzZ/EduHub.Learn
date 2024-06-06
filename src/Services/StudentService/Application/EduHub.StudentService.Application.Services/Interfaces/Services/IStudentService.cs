using EduHub.StudentService.Application.Services.Dto.Student;

namespace EduHub.StudentService.Application.Services.Interfaces.Services;

public interface IStudentService
{
    public Task<StudentResponseDto> AddAsync(StudentCreateDto studentDto, CancellationToken cancellationToken);
    public Task<StudentResponseDto> UpdateAsync(StudentUpdateDto studentDto, CancellationToken cancellationToken);
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    public Task<List<StudentResponseDto>> GetListAsync(CancellationToken cancellationToken);
    public Task<List<StudentResponseDto>> GetInfoStudentsAsync(CancellationToken cancellationToken);
}