﻿using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Educator;
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
public class EducatorService : ServiceBase, IEducatorService
{
    private readonly IMapper _mapper;
    private readonly IStudentUnitOfWork _unitOfWork;
    
    /// <summary>
    /// конструктор, принимающий все необходимые зависимости
    /// </summary>
    /// <param name="mapper">зависимость автомаппера</param>
    /// <param name="unitOfWork">зависимость UoW</param>
    public EducatorService(IMapper mapper, IStudentUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _mapper = Guard.Against.Null(mapper);
        _unitOfWork = Guard.Against.Null(unitOfWork);
    }
    
    /// <summary>
    /// Асинхронное добавление преподавателя в бд
    /// </summary>
    /// <param name="educatorDto">Дто преподавателя</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возврщаете дто добавленного преподавателя</returns>
    public async Task<EducatorResponseDto> AddAsync(EducatorCreateDto educatorDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(educatorDto);
        
        await new EducatorCreateDtoValidator().ValidateAndThrowAsync(educatorDto, cancellationToken);
        
        var educator = _mapper.Map<EducatorCreateDto, Educator>(educatorDto);
        await _unitOfWork.EducatorRepository.AddAsync(educator, cancellationToken);
        
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<Educator, EducatorResponseDto>(educator);
    }
    
    /// <summary>
    /// Асинхронное обновление преподавателя в бд
    /// </summary>
    /// <param name="educatorDto">модель преподавателя</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возврщаете дто обновленного преподавателя</returns>
    public async Task<EducatorResponseDto> UpdateAsync(EducatorUpdateDto educatorDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(educatorDto);
        
        await new EducatorUpdateDtoValidator().ValidateAndThrowAsync(educatorDto, cancellationToken);
        
        var educator = await GetEntityByIdAsync<Educator>(educatorDto.Id, "id", cancellationToken);
        
        educator.Update(
            new FullName(educator.FullName.FirstName, educator.FullName.Surname, educator.FullName.Patronymic),
            educator.Gender,
            new Phone(educator.Phone.Value),
            educator.YearsExperience,
            educator.DateEmployment
        );
        
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<Educator, EducatorResponseDto>(educator);
    }
    
    /// <summary>
    /// Асинхронное удаление преподавателя из бд
    /// </summary>
    /// <param name="id">Id преподавателя</param>
    /// <param name="cancellationToken">токен отмены</param>
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        Guard.Against.Default(id);
        var educator = await GetEntityByIdAsync<Educator>(id, "id", cancellationToken);
        
        await _unitOfWork.EducatorRepository.DeleteAsync(educator, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
    
    /// <summary>
    /// Асинхронное получение преподавателей
    /// </summary>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает дто всех преподавателей, которые есть в бд</returns>
    public async Task<List<EducatorResponseDto>> GetListAsync(CancellationToken cancellationToken)
    {
        var educators = await _unitOfWork.EducatorRepository.GetAllAsync(cancellationToken);
        
        return _mapper.Map<List<EducatorResponseDto>>(educators);
    }
    
    /// <summary>
    /// Асинхронное получение преподавателя по id
    /// </summary>
    /// <param name="id">id преподавателя</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращает дто преподавателя, полученного по id</returns>
    public async Task<EducatorResponseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Guard.Against.Default(id);
        var educator = await GetEntityByIdAsync<Educator>(id, "id", cancellationToken);
        
        return _mapper.Map<Educator, EducatorResponseDto>(educator);
    }
}