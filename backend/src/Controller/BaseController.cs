namespace backend.src.Controller;

using Microsoft.AspNetCore.Mvc;
using backend.src.Services.BaseService;
using backend.src.Repositories.BaseRepo;
using Microsoft.AspNetCore.Authorization;

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
    public async Task<ActionResult<IEnumerable<TReadDto>>> GetAll([FromQuery]QueryOptions options)
    {
        return Ok(await _service.GetAllAsync(options));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TReadDto?>> GetById([FromRoute]string id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpPost()]
    public async Task<ActionResult<TReadDto?>> CreateOne([FromBody]TCreateDto create)
    {
        var result = await _service.CreateOneAsync(create);
        return Ok(result);
    }

    [HttpPost("{id}")]
    public async Task<ActionResult<TReadDto?>> UpdateOne([FromRoute]string id, [FromBody]TUpdateDto update)
    {
        return Ok(await _service.UpdateOneAsync(id, update));
    }

    // [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteOne([FromRoute]string id)
    {
        return Ok(await _service.DeleteOneAsync(id));
    }
}
