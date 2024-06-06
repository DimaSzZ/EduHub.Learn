using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.UoW;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Application.Services.Interfaces.Services
{
    /// <summary>
    /// Базовый класс сервисов, созданный для удобного пользования
    /// </summary>
    public abstract class ServiceBase
    {
        private readonly IStudentUnitOfWork _unitOfWork;
        
        protected ServiceBase(IStudentUnitOfWork unitOfWork)
        {
            _unitOfWork = Guard.Against.Null(unitOfWork);
        }
        
        /// <summary>
        /// Универсальнй метод для получения id, в зависимости от типа репозитория
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="field">названия поля, с возможным исключением</param>
        /// <param name="cancellationToken"> токен отмены</param>
        /// <typeparam name="TEntity">Дженерик типа</typeparam>
        /// <returns>При валидных данных и наличии модели в бд, возвращает эту модель</returns>
        /// <exception cref="EntityNotFoundException{TEntity}"></exception>
        protected async Task<TEntity> GetEntityByIdAsync<TEntity>(Guid id, string field, CancellationToken cancellationToken) where TEntity : BaseEntity
        {
            var repository = _unitOfWork.GetRepository<TEntity>();
            var entity = await repository.GetByIdAsync(id, cancellationToken);
            if (entity == null)
            {
                throw new EntityNotFoundException<TEntity>(field, id);
            }
            
            return entity;
        }
    }
}
