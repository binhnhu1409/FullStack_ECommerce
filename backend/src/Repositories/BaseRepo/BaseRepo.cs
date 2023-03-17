namespace backend.src.Repositories.BaseRepo;

public class BaseRepo<T, TUpdateDto> : IBaseRepo<T, TUpdateDto>
{
    public Task<T> CreateAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllAsync(QueryOptions options)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetByIdAsync(string Id)
    {
        throw new NotImplementedException();
    }

    public Task<T> UpdateAsync(string Id, TUpdateDto update)
    {
        throw new NotImplementedException();
    }
}
