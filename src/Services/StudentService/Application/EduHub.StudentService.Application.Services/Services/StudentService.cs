using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Student;
using EduHub.StudentService.Application.Services.Exceptions.Realization;
using EduHub.StudentService.Application.Services.Interfaces.UoW;
using EduHub.StudentService.Application.Services.Validations;
using EduHub.StudentService.Domain.Entities;
using EduHub.StudentService.Domain.ValueObjects;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Services;

public class StudentService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    
    public StudentService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task AddNewStudent(StudentRequestDto studentDto, CancellationToken cancellationToken)
    {
        await new StudentRequestDtoValidator().ValidateAndThrowAsync(studentDto, cancellationToken);
        
        var student = _mapper.Map<StudentRequestDto, Student>(studentDto);
        var existingStudent = await _unitOfWork.StudentRepository.Add(student, cancellationToken);
        if (existingStudent != null)
            throw new EntityConflictException<Student>();
        
        await _unitOfWork.SaveChanges();
    }
    
    public async Task UpdateStudent(StudentRequestDto studentDto, CancellationToken cancellationToken)
    {
        await new StudentRequestDtoValidator().ValidateAndThrowAsync(studentDto, cancellationToken);
        
        var student = _mapper.Map<StudentRequestDto, Student>(studentDto);
        var existingStudent = await _unitOfWork.StudentRepository.Update(student, cancellationToken);
        if (existingStudent == null)
            throw new EntityNotFoundException<Student>();
        
        await _unitOfWork.SaveChanges();
    }
    
    public async Task DeleteStudent(Guid id, CancellationToken cancellationToken)
    {
        await _unitOfWork.StudentRepository.Delete(id, cancellationToken);
        
        await _unitOfWork.SaveChanges();
    }
    
    public async Task<List<FullName>> GetListStudents(CancellationToken cancellationToken)
    {
        var students = await _unitOfWork.StudentRepository.GetAllEntities(cancellationToken);
        if (students == null)
            throw new EntityNotFoundException<Student>();
        
        return _mapper.Map<List<StudentResponseDto>>(students).Select(student => student.FullName).ToList();
    }
    
    public async Task<List<StudentResponseDto>> GetInfoStudents(CancellationToken cancellationToken)
    {
        var students = await _unitOfWork.StudentRepository.GetAllEntities(cancellationToken);
        if (students == null)
            throw new EntityNotFoundException<Student>();
        
        return _mapper.Map<List<StudentResponseDto>>(students);
    }
}