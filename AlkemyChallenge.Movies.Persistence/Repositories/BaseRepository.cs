using AlkemyChallenge.Movies.Application.Contracts.Persistence;
using AlkemyChallenge.Movies.Domain.Common;
using AlkemyChallenge.Movies.Persistence.Data;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AlkemyChallenge.Movies.Persistence.Repositories;

public class BaseRepository<T> : IAsyncRepository<T> where T : class, IEntity
{
    protected readonly MoviesDbContext _dbContext;
    private readonly IMapper _mapper;

    public BaseRepository(MoviesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public BaseRepository(MoviesDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<TDto?> GetByIdProjectToAsync<TDto>(int id, IConfigurationProvider configuration) where TDto : class
    {
        return await _dbContext.Set<T>()
            .Where(x => x.Id == id)
            .ProjectTo<TDto>(configuration)
            .FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<IReadOnlyList<TDto>> ProjectToListAsync<TDto>(IConfigurationProvider configuration)
    {
        return await _dbContext.Set<T>()
            .ProjectTo<TDto>(configuration)
            .ToListAsync();
    }

    public IQueryable<T> GetQueryable()
    {
        return _dbContext.Set<T>().AsQueryable();
    }

    public async Task<IReadOnlyList<TDto>> ProjectToListAsync<TDto>(
        IQueryable<T> query,
        IConfigurationProvider configuration,
        CancellationToken cancellationToken = default)
    {
        return await query
            .ProjectTo<TDto>(configuration)
            .ToListAsync(cancellationToken);
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task<int> CountAsync()
    {
        return await _dbContext.Set<T>().CountAsync();
    }

    public async Task<List<T>> GetPagedAsync(int pageNumber, int pageSize)
    {
        return await _dbContext.Set<T>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<TDto>> GetPagedAsync<TDto>(int pageNumber, int pageSize, IConfigurationProvider configuration)
    {
        return await _dbContext.Set<T>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ProjectTo<TDto>(configuration)
            .ToListAsync();
    }
}
