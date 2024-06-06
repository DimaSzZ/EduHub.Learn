using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Course;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Application.Services.Interfaces.UoW;
using EduHub.StudentService.Application.Services.Validations.Course;
using EduHub.StudentService.Domain.Entities;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Services;

/// <summary>
/// Сервис курсов
/// </summary>
public class CourseService : ServiceBase, ICourseService
{
    private readonly IMapper _mapper;
    private readonly IStudentUnitOfWork _unitOfWork;
        
    /// <summary>
    /// конструктор, принимающий все необходимые зависимости
    /// </summary>
    /// <param name="mapper">зависимость автомаппера</param>
    /// <param name="unitOfWork">зависимость UoW</param>
    public CourseService(IMapper mapper, IStudentUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _mapper = Guard.Against.Null(mapper);
        _unitOfWork = Guard.Against.Null(unitOfWork);
    }
    
    /// <summary>
    /// Асинхронное добавление курс в бд
    /// </summary>
    /// <param name="courseDto">Дто курса</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает дто добавленного курса</returns>
    public async Task<CourseResponseDto> AddAsync(CourseCreateDto courseDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(courseDto);
        
        await new CourseCreateDtoValidator().ValidateAndThrowAsync(courseDto, cancellationToken);
        
        var course = _mapper.Map<CourseCreateDto, Course>(courseDto);
        await _unitOfWork.CoursesRepository.AddAsync(course, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<Course, CourseResponseDto>(course);
    }
    
    /// <summary>
    /// Асинхронное обновление курс в бд
    /// </summary>
    /// <param name="courseDto">модель курса</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает дто обновленного курса</returns>
    public async Task<CourseResponseDto> UpdateAsync(CourseUpdateDto courseDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(courseDto);
        
        await new CourseUpdateDtoValidator().ValidateAndThrowAsync(courseDto, cancellationToken);
        
        var course = await GetEntityByIdAsync<Course>(courseDto.Id, "id", cancellationToken);
        
        course.Update(courseDto.Name, courseDto.Description, courseDto.EducatorId);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<Course, CourseResponseDto>(course);
    }
    
    /// <summary>
    /// Асинхронное удаление курса из бд
    /// </summary>
    /// <param name="id">Id курса</param>
    /// <param name="cancellationToken">токен отмены</param>
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        Guard.Against.Default(id);
        
        var course = await GetEntityByIdAsync<Course>(id, "id", cancellationToken);
        
        await _unitOfWork.CoursesRepository.DeleteAsync(course, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
    
    /// <summary>
    /// Асинхронное получение курсов
    /// </summary>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает дто всех курсов, которые есть в бд</returns>
    public async Task<IList<CourseResponseDto>> GetListAsync(CancellationToken cancellationToken)
    {
        var courses = await _unitOfWork.CoursesRepository.GetAllAsync(cancellationToken);
        
        return _mapper.Map<List<CourseResponseDto>>(courses).ToList();
    }
    
    /// <summary>
    /// Асинхронное получение курса по id
    /// </summary>
    /// <param name="id">id курса</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает дто курса, полученного по id</returns>
    public async Task<CourseResponseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Guard.Against.Default(id);
        var course = await GetEntityByIdAsync<Course>(id, "id", cancellationToken);
        
        return _mapper.Map<Course, CourseResponseDto>(course);
    }
}