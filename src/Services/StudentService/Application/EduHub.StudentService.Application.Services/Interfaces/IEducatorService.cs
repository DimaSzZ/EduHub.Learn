using EduHub.StudentService.Application.Services.Dto.Educator;

namespace EduHub.StudentService.Application.Services.Interfaces;

public interface IEducatorService
{
    public Task<EducatorResponseDto> AddNewAsync(EducatorRequestDto educatorDto, CancellationToken cancellationToken);
    
    public Task<EducatorResponseDto> UpdateAsync(EducatorRequestUpdateDto educatorDto, CancellationToken cancellationToken);
    
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    
    public Task<List<(string, string, string)>> GetListAsync(CancellationToken cancellationToken);
    
    public Task<EducatorResponseDto> GetInfoAsync(Guid id, CancellationToken cancellationToken);
}