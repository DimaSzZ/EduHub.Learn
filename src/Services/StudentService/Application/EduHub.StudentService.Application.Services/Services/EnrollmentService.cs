using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Enrollment;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Application.Services.Interfaces.UoW;
using EduHub.StudentService.Application.Services.Validations.Enrollment;
using EduHub.StudentService.Domain.Entities;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Services;

/// <summary>
/// Сервис зачислений
/// </summary>
public class EnrollmentService : ServiceBase, IEnrollmentService
{
    private readonly IMapper _mapper;
    private readonly IStudentUnitOfWork _unitOfWork;
    
    /// <summary>
    /// конструктор, принимающий все необходимые зависимости
    /// </summary>
    /// <param name="mapper">зависимость автомаппера</param>
    /// <param name="unitOfWork">зависимость UoW</param>
    public EnrollmentService(IMapper mapper, IStudentUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _mapper = Guard.Against.Null(mapper);
        _unitOfWork = Guard.Against.Null(unitOfWork);
    }
    
    /// <summary>
    /// Асинхронное добавление зачисления в бд
    /// </summary>
    /// <param name="enrollmentCreateDto">Дто зачисления</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возврщаете дто добавленного преподавателя</returns>
    public async Task<EnrollmentResponseDto> AddAsync(EnrollmentCreateDto enrollmentCreateDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(enrollmentCreateDto);
        
        await new EnrollmentCreateDtoValidator().ValidateAndThrowAsync(enrollmentCreateDto, cancellationToken);
        
        var enrollment = _mapper.Map<EnrollmentCreateDto, Enrollment>(enrollmentCreateDto);
        
        await GetEntityByIdAsync<Course>(enrollment.CourseId, "id", cancellationToken);
        
        await GetEntityByIdAsync<Student>(enrollment.StudentId, "id", cancellationToken);
        
        await _unitOfWork.EnrollmentRepository.AddAsync(enrollment, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<Enrollment, EnrollmentResponseDto>(enrollment);
    }
    
    /// <summary>
    /// Получает все зачисления студента, с указанным id
    /// </summary>
    /// <param name="id">id студента</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает список зачислений студента</returns>
    public async Task<List<EnrollmentResponseDto>> GetStudentEnrollmentsAsync(Guid id, CancellationToken cancellationToken)
    {
        Guard.Against.Default(id);
        
        var student = await GetEntityByIdAsync<Student>(id, "id", cancellationToken);
        
        var enrollments = await _unitOfWork.EnrollmentRepository.GetListByStudentIdAsync(student.Id, cancellationToken);
        return _mapper.Map<List<EnrollmentResponseDto>>(enrollments);
    }
    
    /// <summary>
    /// Получает все доступные зачисления
    /// </summary>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает все зачисления, что удалось получить через бд</returns>
    public async Task<List<EnrollmentResponseDto>> GetListStudentsAsync(CancellationToken cancellationToken)
    {
        var enrollments = await _unitOfWork.EnrollmentRepository.GetAllAsync(cancellationToken);
        
        return _mapper.Map<List<EnrollmentResponseDto>>(enrollments).ToList();
    }
    
    /// <summary>
    /// Удаляет зачисление, с указанным id
    /// </summary>
    /// <param name="id">id зачисления</param>
    /// <param name="cancellationToken">токен отмены</param>
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        Guard.Against.Default(id);
        
        var enrollment = await GetEntityByIdAsync<Enrollment>(id, "id", cancellationToken);
        
        await _unitOfWork.EnrollmentRepository.DeleteAsync(enrollment, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}