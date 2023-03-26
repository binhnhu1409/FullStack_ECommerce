namespace backend.src.Repositories.BaseRepo;

using backend.src.Database;
using backend.src.Models;
using Microsoft.EntityFrameworkCore;

public class BaseRepo<TModel, TUpdateDto> : IBaseRepo<TModel, TUpdateDto> 
    where TModel : BaseModel
{
    protected readonly DatabaseContext _context;
    public BaseRepo(DatabaseContext context)
    {
        _context = context;
    }
    public virtual Task<TModel> CreateAsync()
    {
        throw new NotImplementedException();
    }

    public virtual Task<bool> DeleteAsync()
    {
        throw new NotImplementedException();
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

    public virtual Task<TModel> GetByIdAsync(string Id)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TModel> UpdateAsync(string Id, TUpdateDto update)
    {
        throw new NotImplementedException();
    }
}
