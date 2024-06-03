using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Course;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces;
using EduHub.StudentService.Application.Services.Interfaces.UoW;
using EduHub.StudentService.Application.Services.Validations.Course;
using EduHub.StudentService.Domain.Entities;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Services;

public class CourseService : ICourseService
{
    private readonly IMapper _mapper;
    private readonly IPgUnitOfWork _unitOfWork;
    
    public CourseService(IMapper mapper, IPgUnitOfWork unitOfWork)
    {
        _mapper = Guard.Against.Null(mapper);
        _unitOfWork = Guard.Against.Null(unitOfWork);
    }
    
    public async Task<CourseResponseDto> AddAsync(CourseRequestDto courseDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(courseDto);
        
        await new CourseRequestDtoValidator().ValidateAndThrowAsync(courseDto, cancellationToken);
        
        var course = _mapper.Map<CourseRequestDto, Course>(courseDto);
        await _unitOfWork.CoursesRepository.AddAsync(course, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<Course, CourseResponseDto>(course);
    }
    
    public async Task<CourseResponseDto> UpdateAsync(CourseRequestUpdateDto courseDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(courseDto);
        
        await new CourseRequestUpdateDtoValidator().ValidateAndThrowAsync(courseDto, cancellationToken);
        
        var course = _mapper.Map<CourseRequestUpdateDto, Course>(courseDto);
        
        var dbCourse = await _unitOfWork.CoursesRepository.GetByIdAsync(courseDto.Id,cancellationToken);
        if (dbCourse == null)
        {
            throw new EntityNotFoundException<Course>();
        }
        
        dbCourse.Update(course.Name,course.Description,course.EducatorId);
        await _unitOfWork.CoursesRepository.UpdateAsync(dbCourse, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<Course, CourseResponseDto>(course);
    }
    
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        Guard.Against.Null(id);
        
        var dbCourse = await _unitOfWork.CoursesRepository.GetByIdAsync(id, cancellationToken);
        if (dbCourse == null)
        {
            throw new EntityNotFoundException<Course>();
        }
        
        await _unitOfWork.CoursesRepository.DeleteAsync(dbCourse, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<IList<CourseResponseDto>> GetListAsync(CancellationToken cancellationToken)
    {
        var courses = await _unitOfWork.CoursesRepository.GetAllAsync(cancellationToken);
        if (courses == null)
        {
            throw new EntityNotFoundException<Course>();   
        }
        
        return _mapper.Map<List<CourseResponseDto>>(courses).ToList();
    }
    
    public async Task<CourseResponseDto> GetBuIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Guard.Against.Null(id);
        var course = await _unitOfWork.CoursesRepository.GetByIdAsync(id, cancellationToken);
        if (course == null)
        {
            throw new EntityNotFoundException<Course>();    
        }
        
        return _mapper.Map<Course, CourseResponseDto>(course);
    }
}