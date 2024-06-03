using EduHub.StudentService.Application.Services.Dto.Enrollment;

namespace EduHub.StudentService.Application.Services.Interfaces;

public interface IEnrollmentService
{
    public Task<EnrollmentResponseDto> AddStudentToCourseAsync(EnrollmentRequestDto enrollmentRequestDto, CancellationToken cancellationToken);
    public Task<List<EnrollmentResponseDto>> GetStudentEnrollmentsAsync(Guid id, CancellationToken cancellationToken);
    public Task<List<Guid>> GetListStudentsAsync(CancellationToken cancellationToken);
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}