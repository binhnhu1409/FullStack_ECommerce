namespace backend.src.Repositories.BaseRepo;

using backend.src.Models;

public interface IBaseRepo<TModel, TUpdateDto>
{
    Task<TModel> CreateAsync();
    Task<TModel> GetByIdAsync(string Id);
    Task<IEnumerable<TModel>> GetAllAsync(QueryOptions options);
    Task<TModel> UpdateAsync(string Id, TUpdateDto update);
    Task<bool> DeleteAsync();
}

public class QueryOptions
{
    public string Sort { get; set; } = null!;
    public string Search { get; set; } = null!;
    public SortBy SortBy { get; set; }
    public int Limit { get; set; } = 50;
    public int Skip { get; set; } = 0;
}

public enum SortBy 
{
    ASC,
    DESC
}