namespace backend.src.Repositories.BaseRepo;

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
    public string Sort { get; set; } = string.Empty;
    public string SearchKeyword { get; set; } = string.Empty;
    public SortBy SortBy { get; set; } = SortBy.ASC;
    public string CategoryName { get; set; } = string.Empty;
    public int? Limit { get; set; }
    public int? Skip { get; set; }
}

public enum SortBy 
{
    ASC,
    DESC
}