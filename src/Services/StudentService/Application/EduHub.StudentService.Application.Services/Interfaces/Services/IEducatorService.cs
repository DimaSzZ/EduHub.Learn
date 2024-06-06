using EduHub.StudentService.Application.Services.Dto.Educator;

namespace EduHub.StudentService.Application.Services.Interfaces.Services;

public interface IEducatorService
{
    public Task<EducatorResponseDto> AddAsync(EducatorCreateDto educatorDto, CancellationToken cancellationToken);
    
    public Task<EducatorResponseDto> UpdateAsync(EducatorUpdateDto educatorDto, CancellationToken cancellationToken);
    
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    
    public Task<List<EducatorResponseDto>> GetListAsync(CancellationToken cancellationToken);
    
    public Task<EducatorResponseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}