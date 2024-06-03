using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Student;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces;
using EduHub.StudentService.Application.Services.Interfaces.UoW;
using EduHub.StudentService.Application.Services.Validations.Student;
using EduHub.StudentService.Domain.Entities;
using EduHub.StudentService.Domain.ValueObjects;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Services;

public class StudentService : IStudentService
{
    private readonly IMapper _mapper;
    private readonly IPgUnitOfWork _unitOfWork;
    
    public StudentService(IMapper mapper, IPgUnitOfWork unitOfWork)
    {
        _mapper = Guard.Against.Null(mapper);
        _unitOfWork = Guard.Against.Null(unitOfWork);
    }
    
    public async Task<StudentResponseDto> AddAsync(StudentRequestDto studentDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(studentDto);
        
        await new StudentRequestDtoValidator().ValidateAndThrowAsync(studentDto, cancellationToken);
        
        var student = _mapper.Map<StudentRequestDto, Student>(studentDto);
        await _unitOfWork.StudentRepository.AddAsync(student, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<Student, StudentResponseDto>(student);
    }
    
    public async Task<StudentResponseDto> UpdateAsync(StudentRequestUpdateDto studentDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(studentDto);
        
        await new StudentRequestUpdateDtoValidator().ValidateAndThrowAsync(studentDto, cancellationToken);
        
        var student = _mapper.Map<StudentRequestUpdateDto, Student>(studentDto);
        
        var dbStudent = await _unitOfWork.StudentRepository.GetByIdAsync(studentDto.Id, cancellationToken);
        if (dbStudent == null)
        {
            throw new EntityNotFoundException<Student>();
        }
        
        dbStudent.Update(
            studentDto.Avatar,
            new FullName(studentDto.FirstName,studentDto.Surname,studentDto.Patronymic),
            studentDto.Gender,
            studentDto.DateBirth,
            new Email(studentDto.Email),
            new Phone(studentDto.Phone),
            new Address(studentDto.City,studentDto.Street,studentDto.NumberHouse)
            );
        await _unitOfWork.StudentRepository.UpdateAsync(dbStudent, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<Student, StudentResponseDto>(student);
    }
    
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        Guard.Against.Null(id);
        
        var dbStudent = await _unitOfWork.StudentRepository.GetByIdAsync(id,cancellationToken);
        if (dbStudent == null)
        {
            throw new EntityNotFoundException<Student>();
        }
        
        await _unitOfWork.StudentRepository.DeleteAsync(dbStudent, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<List<(string, string, string)>> GetListAsync(CancellationToken cancellationToken)
    {
        var students = await _unitOfWork.StudentRepository.GetAllAsync(cancellationToken);
        if (students == null)
        {
            throw new EntityNotFoundException<Student>();   
        }
        
        return students.Select(student => (student.FullName.FirstName, student.FullName.Surname, student.FullName.Patronymic)).ToList();
    }
    
    public async Task<List<StudentResponseDto>> GetInfoStudentsAsync(CancellationToken cancellationToken)
    {
        var students = await _unitOfWork.StudentRepository.GetAllAsync(cancellationToken);
        if (students == null)
        {
            throw new EntityNotFoundException<Student>();   
        }
        
        return _mapper.Map<List<StudentResponseDto>>(students);
    }
}