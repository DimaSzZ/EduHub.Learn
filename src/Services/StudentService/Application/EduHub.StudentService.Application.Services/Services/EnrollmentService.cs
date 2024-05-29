using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Enrollment;
using EduHub.StudentService.Application.Services.Exceptions.Realization;
using EduHub.StudentService.Application.Services.Interfaces.UoW;
using EduHub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Services;

public class EnrollmentService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    
    public EnrollmentService( IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task AddStudentToCourse(EnrollmentRequestDto enrollmentRequestDto, CancellationToken cancellationToken)
    {
        var enrollment = _mapper.Map<EnrollmentRequestDto, Enrollment>(enrollmentRequestDto);
        
        if (await _unitOfWork.CoursesRepository.GetCourseById(enrollment.CourseId, cancellationToken) == null)
            throw new EntityNotFoundException<Course>();
        if (await _unitOfWork.StudentRepository.GetStudentById(enrollment.StudentId, cancellationToken) == null)
            throw new EntityNotFoundException<Student>();
        
        var existingEnrollment = await _unitOfWork.EnrollmentRepository.Add(enrollment, cancellationToken);
        if (existingEnrollment != null)
            throw new EntityConflictException<Enrollment>();
        
        await _unitOfWork.SaveChanges();
    }
    
    public async Task<List<EnrollmentResponseDto>> GetStudentEnrollments(Guid id,CancellationToken cancellationToken)
    {
        var student = await _unitOfWork.StudentRepository.GetStudentById(id, cancellationToken);
        if (student == null)
            throw new EntityNotFoundException<Student>();
        
        var enrollments = await _unitOfWork.EnrollmentRepository.GetStudentEnrollments(student,cancellationToken);
        return _mapper.Map<List<EnrollmentResponseDto>>(enrollments);
    }
    
    public async Task<List<Guid>> GetListStudents(CancellationToken cancellationToken)
    {
        var enrollments = await _unitOfWork.EnrollmentRepository.GetAllEntities(cancellationToken);
        if (enrollments == null)
            throw new EntityNotFoundException<Enrollment>();
        
        return _mapper.Map<List<EnrollmentResponseDto>>(enrollments).Select(enrollment => enrollment.Id).ToList();
    }
    
    public async Task DeleteEnrollment(Guid id, CancellationToken cancellationToken)
    {
        await _unitOfWork.EnrollmentRepository.Delete(id, cancellationToken);
        
        await _unitOfWork.SaveChanges();
    }
}