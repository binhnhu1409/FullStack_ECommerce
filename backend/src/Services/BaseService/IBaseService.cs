namespace backend.src.Services.BaseService;

using backend.src.Models;
using backend.src.Repositories.BaseRepo;

public interface IBaseService<TModel, TReadDto, TCreateDto, TUpdateDto>
{
    Task<TReadDto?> CreateOneAsync(TCreateDto create);
    Task<TReadDto?> GetByIdAsync(string id);
    Task<IEnumerable<TReadDto>> GetAllAsync(QueryOptions options);
    Task<TReadDto?> UpdateOneAsync(string id, TUpdateDto update);
    Task<bool> DeleteOneAsync(string id);
}
