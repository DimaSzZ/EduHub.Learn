using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Course;
using EduHub.StudentService.Application.Services.Exceptions.Realization;
using EduHub.StudentService.Application.Services.Interfaces.UoW;
using EduHub.StudentService.Application.Services.Validations;
using EduHub.StudentService.Domain.Entities;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Services;

public class CourseService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    
    public CourseService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task AddNewCourse(CourseRequestDto courseDto, CancellationToken cancellationToken)
    {
        await new CourseRequestDtoValidator().ValidateAndThrowAsync(courseDto, cancellationToken);
        
        var course = _mapper.Map<CourseRequestDto, Course>(courseDto);
        var existingCourse = await _unitOfWork.CoursesRepository.Add(course, cancellationToken);
        if (existingCourse != null)
            throw new EntityConflictException<Course>();
        
        await _unitOfWork.SaveChanges();
    }
    
    public async Task UpdateCourse(CourseRequestDto courseDto, CancellationToken cancellationToken)
    {
        await new CourseRequestDtoValidator().ValidateAndThrowAsync(courseDto, cancellationToken);
        
        var course = _mapper.Map<CourseRequestDto, Course>(courseDto);
        var existingCourse = await _unitOfWork.CoursesRepository.Update(course, cancellationToken);
        if (existingCourse == null)
            throw new EntityNotFoundException<Course>();
        
        await _unitOfWork.SaveChanges();
    }
    
    public async Task DeleteCourse(Guid id, CancellationToken cancellationToken)
    {
        await _unitOfWork.CoursesRepository.Delete(id, cancellationToken);
        
        await _unitOfWork.SaveChanges();
    }
    
    public async Task<List<string>> GetListCourses(CancellationToken cancellationToken)
    {
        var courses = await _unitOfWork.CoursesRepository.GetAllEntities(cancellationToken);
        if (courses == null)
            throw new EntityNotFoundException<Course>();
        
        return _mapper.Map<List<CourseResponseDto>>(courses).Select(course => course.Name).ToList();
    }
    
    public async Task<CourseResponseDto> GetInfoCourse(Guid id, CancellationToken cancellationToken)
    {
        var course = await _unitOfWork.CoursesRepository.GetCourseById(id, cancellationToken);
        if (course == null)
            throw new EntityNotFoundException<Course>();
        
        return _mapper.Map<Course, CourseResponseDto>(course);
    }
}