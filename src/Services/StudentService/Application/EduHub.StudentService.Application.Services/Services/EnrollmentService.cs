using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Enrollment;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces;
using EduHub.StudentService.Application.Services.Interfaces.UoW;
using EduHub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly IMapper _mapper;
    private readonly IPgUnitOfWork _unitOfWork;
    
    public EnrollmentService( IMapper mapper, IPgUnitOfWork unitOfWork)
    {
        _mapper = Guard.Against.Null(mapper);
        _unitOfWork = Guard.Against.Null(unitOfWork);
    }
    
    public async Task<EnrollmentResponseDto> AddStudentToCourseAsync(EnrollmentRequestDto enrollmentRequestDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(enrollmentRequestDto);
        
        var enrollment = _mapper.Map<EnrollmentRequestDto, Enrollment>(enrollmentRequestDto);
        
        if (await _unitOfWork.CoursesRepository.GetByIdAsync(enrollment.CourseId, cancellationToken) == null)
        {
            throw new EntityNotFoundException<Course>();    
        }
        
        if (await _unitOfWork.StudentRepository.GetByIdAsync(enrollment.StudentId, cancellationToken) == null)
        {
            throw new EntityNotFoundException<Student>();   
        }
        
        await _unitOfWork.EnrollmentRepository.AddAsync(enrollment, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<Enrollment,EnrollmentResponseDto>(enrollment);
    }
    
    public async Task<List<EnrollmentResponseDto>> GetStudentEnrollmentsAsync(Guid id,CancellationToken cancellationToken)
    {
        Guard.Against.Null(id);
        
        var student = await _unitOfWork.StudentRepository.GetByIdAsync(id, cancellationToken);
        if (student == null)
        {
            throw new EntityNotFoundException<Student>();   
        }
        
        var enrollments = await _unitOfWork.EnrollmentRepository.GetListByStudentIdAsync(student.Id,cancellationToken);
        return _mapper.Map<List<EnrollmentResponseDto>>(enrollments);
    }
    
    public async Task<List<Guid>> GetListStudentsAsync(CancellationToken cancellationToken)
    {
        var enrollments = await _unitOfWork.EnrollmentRepository.GetAllAsync(cancellationToken);
        if (enrollments == null)
        {
            throw new EntityNotFoundException<Enrollment>();   
        }
        
        return _mapper.Map<List<EnrollmentResponseDto>>(enrollments).Select(enrollment => enrollment.Id).ToList();
    }
    
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        Guard.Against.Null(id);
        var dbEnrollment = await _unitOfWork.EnrollmentRepository.GetByIdAsync(id,cancellationToken);
        if (dbEnrollment == null)
        {
            throw new EntityNotFoundException<Enrollment>();
        }
        
        await _unitOfWork.EnrollmentRepository.DeleteAsync(dbEnrollment, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync();
    }
}