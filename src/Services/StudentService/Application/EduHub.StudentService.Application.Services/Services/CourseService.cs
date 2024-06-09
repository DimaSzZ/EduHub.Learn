using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Course;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Application.Services.Interfaces.UoW;
using EduHub.StudentService.Application.Services.Validations.Course;
using EduHub.StudentService.Domain.Entities;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Services;

/// <summary>
/// Сервис курсов
/// </summary>
public class CourseService : ICourseService
{
    private readonly IMapper _mapper;
    private readonly IStudentUnitOfWork _unitOfWork;
    
    /// <summary>
    /// конструктор, принимающий все необходимые зависимости
    /// </summary>
    /// <param name="mapper">зависимость автомаппера</param>
    /// <param name="unitOfWork">зависимость UoW</param>
    public CourseService(IMapper mapper, IStudentUnitOfWork unitOfWork)
    {
        _mapper = Guard.Against.Null(mapper);
        _unitOfWork = Guard.Against.Null(unitOfWork);
    }
    
    public async Task<CourseResponseDto> AddAsync(CourseCreateDto courseDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(courseDto);
        
        await new CourseCreateDtoValidator().ValidateAndThrowAsync(courseDto, cancellationToken);
        
        var course = _mapper.Map<CourseCreateDto, Course>(courseDto);
        await _unitOfWork.CoursesRepository.AddAsync(course, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<Course, CourseResponseDto>(course);
    }
    
    public async Task<CourseResponseDto> UpdateAsync(CourseUpdateDto courseDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(courseDto);
        
        await new CourseUpdateDtoValidator().ValidateAndThrowAsync(courseDto, cancellationToken);
        
        var course = await GetByIdOrThrowAsync(courseDto.Id, cancellationToken);
        
        course.Update(courseDto.Name, courseDto.Description, courseDto.EducatorId);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<Course, CourseResponseDto>(course);
    }
    
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        Guard.Against.Default(id);
        
        var course = await GetByIdOrThrowAsync(id, cancellationToken);
        
        await _unitOfWork.CoursesRepository.DeleteAsync(course, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<IList<CourseResponseDto>> GetListAsync(CancellationToken cancellationToken)
    {
        var courses = await _unitOfWork.CoursesRepository.GetAllAsync(cancellationToken);
        
        return _mapper.Map<List<CourseResponseDto>>(courses).ToList();
    }
    
    public async Task<CourseResponseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Guard.Against.Default(id);
        var course = await GetByIdOrThrowAsync(id, cancellationToken);
        
        return _mapper.Map<Course, CourseResponseDto>(course);
    }
    
    private async Task<Course> GetByIdOrThrowAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CoursesRepository.GetByIdAsync(id, cancellationToken);
        if (entity == null)
        {
            throw new EntityNotFoundException<Course>(nameof(Course.Id), id);
        }
        
        return entity;
    }
}