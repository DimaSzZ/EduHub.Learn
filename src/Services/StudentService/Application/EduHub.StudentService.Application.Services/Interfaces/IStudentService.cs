using EduHub.StudentService.Application.Services.Dto.Student;

namespace EduHub.StudentService.Application.Services.Interfaces;

public interface IStudentService
{
    public Task<StudentResponseDto> AddAsync(StudentRequestDto studentDto, CancellationToken cancellationToken);
    public Task<StudentResponseDto> UpdateAsync(StudentRequestUpdateDto studentDto, CancellationToken cancellationToken);
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    public Task<List<(string, string, string)>> GetListAsync(CancellationToken cancellationToken);
    public Task<List<StudentResponseDto>> GetInfoStudentsAsync(CancellationToken cancellationToken);
}