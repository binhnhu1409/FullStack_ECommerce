namespace backend.src.Repositories.BaseRepo;

public interface IBaseRepo<TModel>
{
    Task<TModel> CreateAsync(TModel request);
    Task<TModel?> GetByIdAsync(string id);
    Task<IEnumerable<TModel>> GetAllAsync(QueryOptions options);
    Task<TModel?> UpdateOneAsync(string id, TModel request);
    Task<bool> DeleteOneAsync(string id);
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