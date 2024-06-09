using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Educator;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Application.Services.Interfaces.UoW;
using EduHub.StudentService.Application.Services.Validations.Educator;
using EduHub.StudentService.Domain.Entities;
using EduHub.StudentService.Domain.ValueObjects;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Services;

/// <summary>
/// Сервис преподавателей
/// </summary>
public class EducatorService : IEducatorService
{
    private readonly IMapper _mapper;
    private readonly IStudentUnitOfWork _unitOfWork;
    
    /// <summary>
    /// конструктор, принимающий все необходимые зависимости
    /// </summary>
    /// <param name="mapper">зависимость автомаппера</param>
    /// <param name="unitOfWork">зависимость UoW</param>
    public EducatorService(IMapper mapper, IStudentUnitOfWork unitOfWork)
    {
        _mapper = Guard.Against.Null(mapper);
        _unitOfWork = Guard.Against.Null(unitOfWork);
    }
    
    public async Task<EducatorResponseDto> AddAsync(EducatorCreateDto educatorDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(educatorDto);
        
        await new EducatorCreateDtoValidator().ValidateAndThrowAsync(educatorDto, cancellationToken);
        
        var educator = _mapper.Map<EducatorCreateDto, Educator>(educatorDto);
        await _unitOfWork.EducatorRepository.AddAsync(educator, cancellationToken);
        
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<Educator, EducatorResponseDto>(educator);
    }
    
    public async Task<EducatorResponseDto> UpdateAsync(EducatorUpdateDto educatorDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(educatorDto);
        
        await new EducatorUpdateDtoValidator().ValidateAndThrowAsync(educatorDto, cancellationToken);
        
        var educator = await GetByIdOrThrowAsync(educatorDto.Id, cancellationToken);
        
        educator.Update(
            new FullName(educatorDto.FirstName, educatorDto.Surname, educatorDto.Patronymic),
            educatorDto.Gender,
            new Phone(educatorDto.Phone),
            educatorDto.YearsExperience,
            educatorDto.DateEmployment
        );
        
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<Educator, EducatorResponseDto>(educator);
    }
    
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var educator = await GetByIdOrThrowAsync(id, cancellationToken);
        
        await _unitOfWork.EducatorRepository.DeleteAsync(educator, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<List<EducatorResponseDto>> GetListAsync(CancellationToken cancellationToken)
    {
        var educators = await _unitOfWork.EducatorRepository.GetAllAsync(cancellationToken);
        
        return _mapper.Map<List<EducatorResponseDto>>(educators);
    }
    
    public async Task<EducatorResponseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var educator = await GetByIdOrThrowAsync(id, cancellationToken);
        
        return _mapper.Map<Educator, EducatorResponseDto>(educator);
    }
    
    private async Task<Educator> GetByIdOrThrowAsync(Guid id, CancellationToken cancellationToken)
    {
        Guard.Against.Default(id);
        var entity = await _unitOfWork.EducatorRepository.GetByIdAsync(id, cancellationToken);
        if (entity == null)
        {
            throw new EntityNotFoundException<Educator>(nameof(Educator.Id), id);
        }
        
        return entity;
    }
}