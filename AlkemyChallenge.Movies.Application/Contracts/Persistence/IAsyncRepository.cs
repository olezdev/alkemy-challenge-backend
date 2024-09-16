using AutoMapper;

namespace AlkemyChallenge.Movies.Application.Contracts.Persistence;

public interface IAsyncRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<TDto?> GetByIdProjectToAsync<TDto>(int id, IConfigurationProvider configuration) where TDto : class;
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<IReadOnlyList<TDto>> ProjectToListAsync<TDto>(
        IConfigurationProvider configuration);
    IQueryable<T> GetQueryable();
    Task<IReadOnlyList<TDto>> ProjectToListAsync<TDto>(
        IQueryable<T> query,
        IConfigurationProvider configuration,
        CancellationToken cancellationToken = default);

    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task SaveChangesAsync();

    Task<int> CountAsync();
    Task<List<T>> GetPagedAsync(int pageNumber, int pageSize);
    Task<List<TDto>> GetPagedAsync<TDto>(int pageNumber, int pageSize, IConfigurationProvider configuration);
}