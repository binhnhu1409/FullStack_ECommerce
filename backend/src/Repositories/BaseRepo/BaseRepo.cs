namespace backend.src.Repositories.BaseRepo;

using backend.src.Database;
using backend.src.Models;
using Microsoft.EntityFrameworkCore;

public class BaseRepo<TModel> : IBaseRepo<TModel> 
    where TModel : BaseModel
{
    protected readonly DatabaseContext _context;

    public BaseRepo(DatabaseContext context)
    {
        _context = context;
    }

    public virtual async Task<TModel> CreateAsync(TModel request)
    {
        await _context.Set<TModel>().AddAsync(request);
        await _context.SaveChangesAsync();
        return request;
    }

    public virtual async Task<bool> DeleteOneAsync(string id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null)
        {
            return false;
        } else
        {
            _context.Set<TModel>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }

    public virtual async Task<IEnumerable<TModel>> GetAllAsync(QueryOptions options)
    {
        var query = _context.Set<TModel>().AsNoTracking();
        if(options.GetType().GetProperty(options.Sort) != null) 
        {
            query.OrderBy(e => e.GetType().GetProperty(options.Sort));
        }
        if (options.Limit.HasValue && options.Skip.HasValue)
        {
            query = query.Take(options.Limit.Value).Skip(options.Limit.Value);
        }
        return await query.ToArrayAsync();
    }

    public virtual async Task<TModel?> GetByIdAsync(string id)
    {
        return await _context.Set<TModel>().FindAsync();
    }

    public virtual async Task<TModel?> UpdateOneAsync(string id, TModel request)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null)
        {
            return null;
        }
        entity = request;
        await _context.SaveChangesAsync();
        return entity;
    }
}
