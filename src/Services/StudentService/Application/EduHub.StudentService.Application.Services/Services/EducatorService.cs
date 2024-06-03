using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Educator;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces;
using EduHub.StudentService.Application.Services.Interfaces.UoW;
using EduHub.StudentService.Application.Services.Validations.Educator;
using EduHub.StudentService.Domain.Entities;
using EduHub.StudentService.Domain.ValueObjects;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Services;

public class EducatorService : IEducatorService
{
    private readonly IMapper _mapper;
    private readonly IPgUnitOfWork _unitOfWork;
    
    public EducatorService(IMapper mapper, IPgUnitOfWork unitOfWork)
    {
        _mapper = Guard.Against.Null(mapper);
        _unitOfWork = Guard.Against.Null(unitOfWork);
    }
    
    public async Task<EducatorResponseDto> AddNewAsync(EducatorRequestDto educatorDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(educatorDto);
        
        await new EducatorRequestDtoValidator().ValidateAndThrowAsync(educatorDto, cancellationToken);
        
        var educator = _mapper.Map<EducatorRequestDto, Educator>(educatorDto);
        await _unitOfWork.EducatorRepository.AddAsync(educator, cancellationToken);
       
        
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<Educator, EducatorResponseDto>(educator);
    }
    
    public async Task<EducatorResponseDto> UpdateAsync(EducatorRequestUpdateDto educatorDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(educatorDto);
        
        await new EducatorRequestUpdateDtoValidator().ValidateAndThrowAsync(educatorDto, cancellationToken);
        
        var educator = _mapper.Map<EducatorRequestUpdateDto, Educator>(educatorDto);
        
        var dbEducator = await _unitOfWork.EducatorRepository.GetByIdAsync(educatorDto.Id, cancellationToken);
        if (dbEducator == null)
        {
            throw new EntityNotFoundException<Educator>();
        }
        
        dbEducator.Update(
            new FullName(educator.FullName.FirstName,educator.FullName.Surname,educator.FullName.Patronymic),
            educator.Gender,
            new Phone(educator.Phone.Value),
            educator.YearsExperience,
            educator.DateEmployment
            );
        
        await _unitOfWork.EducatorRepository.UpdateAsync(dbEducator, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<Educator, EducatorResponseDto>(educator);
    }
    
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        Guard.Against.Null(id);
        var dbEducator = await _unitOfWork.EducatorRepository.GetByIdAsync(id,cancellationToken);
        
        if (dbEducator == null)
        {
            throw new EntityNotFoundException<Educator>();
        }
        
        await _unitOfWork.EducatorRepository.DeleteAsync(dbEducator, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<List<(string, string, string)>> GetListAsync(CancellationToken cancellationToken)
    {
        var educators = await _unitOfWork.EducatorRepository.GetAllAsync(cancellationToken);
        if (educators == null)
        {
            throw new EntityNotFoundException<Educator>();   
        }
        
        return educators.Select(educator => (educator.FullName.FirstName,educator.FullName.Surname,educator.FullName.Patronymic)).ToList();
    }
    
    public async Task<EducatorResponseDto> GetInfoAsync(Guid id, CancellationToken cancellationToken)
    {
        Guard.Against.Null(id);
        var educator = await _unitOfWork.EducatorRepository.GetByIdAsync(id, cancellationToken);
        if (educator == null)
        {
            throw new EntityNotFoundException<Educator>();   
        }
        
        return _mapper.Map<Educator, EducatorResponseDto>(educator);
    }
}