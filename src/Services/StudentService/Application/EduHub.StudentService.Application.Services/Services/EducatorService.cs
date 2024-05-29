using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Educator;
using EduHub.StudentService.Application.Services.Exceptions.Realization;
using EduHub.StudentService.Application.Services.Interfaces.UoW;
using EduHub.StudentService.Application.Services.Validations;
using EduHub.StudentService.Domain.Entities;
using EduHub.StudentService.Domain.ValueObjects;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Services;

public class EducatorService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    
    public EducatorService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task AddNewEducator(EducatorRequestDto educatorDto, CancellationToken cancellationToken)
    {
        await new EducatorRequestDtoValidator().ValidateAndThrowAsync(educatorDto, cancellationToken);
        
        var educator = _mapper.Map<EducatorRequestDto, Educator>(educatorDto);
        var existingEducator = await _unitOfWork.EducatorRepository.Add(educator, cancellationToken);
        if (existingEducator != null)
            throw new EntityConflictException<Educator>();
        
        await _unitOfWork.SaveChanges();
    }
    
    public async Task UpdateEducator(EducatorRequestDto educatorDto, CancellationToken cancellationToken)
    {
        await new EducatorRequestDtoValidator().ValidateAndThrowAsync(educatorDto, cancellationToken);
        
        var educator = _mapper.Map<EducatorRequestDto, Educator>(educatorDto);
        var existingEducator = await _unitOfWork.EducatorRepository.Update(educator, cancellationToken);
        if (existingEducator == null)
            throw new EntityNotFoundException<Educator>();
        
        await _unitOfWork.SaveChanges();
    }
    
    public async Task DeleteEducator(Guid id, CancellationToken cancellationToken)
    {
        await _unitOfWork.EducatorRepository.Delete(id, cancellationToken);
        
        await _unitOfWork.SaveChanges();
    }
    
    public async Task<List<FullName>> GetListEducators(CancellationToken cancellationToken)
    {
        var educators = await _unitOfWork.EducatorRepository.GetAllEntities(cancellationToken);
        if (educators == null)
            throw new EntityNotFoundException<Educator>();
        
        return _mapper.Map<List<EducatorResponseDto>>(educators).Select(educator => educator.FullName).ToList();
    }
    
    public async Task<EducatorResponseDto> GetInfoEducator(Guid id, CancellationToken cancellationToken)
    {
        var educator = await _unitOfWork.EducatorRepository.GeEducatorById(id, cancellationToken);
        if (educator == null)
            throw new EntityNotFoundException<Educator>();
        
        return _mapper.Map<Educator, EducatorResponseDto>(educator);
    }
}