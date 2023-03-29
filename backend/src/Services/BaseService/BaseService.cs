namespace backend.src.Services.BaseService;

using AutoMapper;
using backend.src.Repositories.BaseRepo;
using backend.src.Helpers;

public class BaseService<TModel, TReadDto, TCreateDto, TUpdateDto>
    : IBaseService<TModel, TReadDto, TCreateDto, TUpdateDto>
{
    protected readonly IMapper _mapper;
    protected readonly IBaseRepo<TModel> _repository;

    public BaseService(IMapper mapper, IBaseRepo<TModel> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<TReadDto?> CreateOneAsync(TCreateDto create)
    {
        var entity = _mapper.Map<TCreateDto, TModel>(create);
        var result = await _repository.CreateOneAsync(entity);
        if(result is null)
        {
            throw CustomizedException.BadRequest("Invalid data!") ;
        }
        return _mapper.Map<TModel, TReadDto>(result);
    }

    public async Task<bool> DeleteOneAsync(string id)
    {
        return await _repository.DeleteOneAsync(id);
    }

    public async Task<IEnumerable<TReadDto>> GetAllAsync(QueryOptions options)
    {
        var data = await _repository.GetAllAsync(options);
        return _mapper.Map<IEnumerable<TModel>, IEnumerable<TReadDto>>(data);
    }

    public async Task<TReadDto?> GetByIdAsync(string id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if(entity is null)
        {
            throw CustomizedException.NotFound();
        }
        return _mapper.Map<TModel, TReadDto>(entity);
    }

    public async Task<TReadDto?> UpdateOneAsync(string id, TUpdateDto update)
    {
        var entity = await _repository.GetByIdAsync(id);
        if(entity is null)
        {
            throw CustomizedException.NotFound();
        }
        var result = await _repository.UpdateOneAsync(id, _mapper.Map<TUpdateDto, TModel>(update));
        if(result is null)
        {
            throw new Exception($"Cannot update the item with id={id}");
        }
        return _mapper.Map<TModel, TReadDto>(entity);
    }
}
