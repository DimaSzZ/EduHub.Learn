using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Student;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Application.Services.Interfaces.UoW;
using EduHub.StudentService.Application.Services.Validations.Student;
using EduHub.StudentService.Domain.Entities;
using EduHub.StudentService.Domain.ValueObjects;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Services;

/// <summary>
/// Сервис студентов
/// </summary>
public class StudentService : ServiceBase, IStudentService
{
    private readonly IMapper _mapper;
    private readonly IStudentUnitOfWork _unitOfWork;
    
    /// <summary>
    /// конструктор, принимающий все необходимые зависимости
    /// </summary>
    /// <param name="mapper">зависимость автомаппера</param>
    /// <param name="unitOfWork">зависимость UoW</param>
    public StudentService(IMapper mapper, IStudentUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _mapper = Guard.Against.Null(mapper);
        _unitOfWork = Guard.Against.Null(unitOfWork);
    }
    
    /// <summary>
    /// Асинхронное добавление студента в бд
    /// </summary>
    /// <param name="studentDto">Дто курса</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возврщаете дто добавленного студента</returns>
    public async Task<StudentResponseDto> AddAsync(StudentCreateDto studentDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(studentDto);
        
        await new StudentCreateDtoValidator().ValidateAndThrowAsync(studentDto, cancellationToken);
        
        var student = _mapper.Map<StudentCreateDto, Student>(studentDto);
        await _unitOfWork.StudentRepository.AddAsync(student, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<Student, StudentResponseDto>(student);
    }
    
    /// <summary>
    /// Асинхронное обновление студента в бд
    /// </summary>
    /// <param name="studentDto">модель курса</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает дто обновленного курса</returns>
    public async Task<StudentResponseDto> UpdateAsync(StudentUpdateDto studentDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(studentDto);
        
        await new StudentUpdateDtoValidator().ValidateAndThrowAsync(studentDto, cancellationToken);
        
        var student = await GetEntityByIdAsync<Student>(studentDto.Id, "id", cancellationToken);
        
        student.Update(
            studentDto.Avatar,
            new FullName(studentDto.FirstName, studentDto.Surname, studentDto.Patronymic),
            studentDto.Gender,
            studentDto.DateBirth,
            new Email(studentDto.Email),
            new Phone(studentDto.Phone),
            new Address(studentDto.City, studentDto.Street, studentDto.NumberHouse)
        );
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<Student, StudentResponseDto>(student);
    }
    
    /// <summary>
    /// Асинхронное удаление студента из бд
    /// </summary>
    /// <param name="id">id студента</param>
    /// <param name="cancellationToken">токен отмены</param>
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        Guard.Against.Default(id);
        
        var student = await GetEntityByIdAsync<Student>(id, "id", cancellationToken);
        
        await _unitOfWork.StudentRepository.DeleteAsync(student, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
    
    /// <summary>
    /// Асинхронное получение студентов
    /// </summary>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает дто всех студентов, которые есть в бд</returns>
    public async Task<List<StudentResponseDto>> GetListAsync(CancellationToken cancellationToken)
    {
        var students = await _unitOfWork.StudentRepository.GetAllAsync(cancellationToken);
        
        return _mapper.Map<List<StudentResponseDto>>(students);
    }
    
    /// <summary>
    /// Асинхронное получение всех студентов
    /// </summary>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает дто всех студентов</returns>
    public async Task<List<StudentResponseDto>> GetInfoStudentsAsync(CancellationToken cancellationToken)
    {
        var students = await _unitOfWork.StudentRepository.GetAllAsync(cancellationToken);
        
        return _mapper.Map<List<StudentResponseDto>>(students);
    }
}