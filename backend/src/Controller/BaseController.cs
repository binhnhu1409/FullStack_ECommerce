namespace backend.src.Controller;

using Microsoft.AspNetCore.Mvc;
using backend.src.Services.BaseService;
using backend.src.Repositories.BaseRepo;

[ApiController]
[Route("api/v1/[controller]s")]
public class BaseController<TModel,TReadDto, TCreateDto, TUpdateDto>
    : ControllerBase
{
    protected readonly IBaseService<TModel,TReadDto, TCreateDto, TUpdateDto> _service;
    public BaseController(IBaseService<TModel, TReadDto, TCreateDto, TUpdateDto> service)
    {
        _service = service;
    }

    [HttpGet()]
    public virtual async Task<ActionResult<IEnumerable<TReadDto>>> GetAll([FromQuery]QueryOptions options)
    {
        return Ok(await _service.GetAllAsync(options));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TReadDto?>> GetById([FromRoute]string id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpPost()]
    public virtual async Task<ActionResult<TReadDto?>> CreateOne([FromBody]TCreateDto create)
    {
        var result = await _service.CreateOneAsync(create);
        return Ok(result);
    }

    [HttpPost("{id}")]
    public virtual async Task<ActionResult<TReadDto?>> UpdateOne([FromRoute]string id, [FromBody]TUpdateDto update)
    {
        return Ok(await _service.UpdateOneAsync(id, update));
    }

    [HttpDelete("{id}")]
    public virtual async Task<ActionResult<bool>> DeleteOne([FromRoute]string id)
    {
        return Ok(await _service.DeleteOneAsync(id));
    }
}
