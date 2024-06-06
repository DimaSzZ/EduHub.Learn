using EduHub.StudentService.Application.Services.Dto.Enrollment;

namespace EduHub.StudentService.Application.Services.Interfaces.Services;

public interface IEnrollmentService
{
    public Task<EnrollmentResponseDto> AddAsync(EnrollmentCreateDto enrollmentCreateDto, CancellationToken cancellationToken);
    public Task<List<EnrollmentResponseDto>> GetStudentEnrollmentsAsync(Guid id, CancellationToken cancellationToken);
    public Task<List<EnrollmentResponseDto>> GetListStudentsAsync(CancellationToken cancellationToken);
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}