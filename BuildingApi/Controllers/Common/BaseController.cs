using BusinessRules.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilities.Objects;

namespace BuildingApi.Controllers.Common
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public abstract partial class BaseController<T, TService> : ControllerBase
        where T : class, new()
        where TService : class, IBaseBusinessRules<T>
    {
        protected readonly TService service;

        public BaseController(TService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await ExecutionAsync(async () =>
            {
                var result = await service.GetAllAsync();
                return Ok(result);
            });
        }

        [HttpGet("ById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            return await ExecutionAsync(async () =>
            {
                var result = await service.GetByIdAsync(id);
                return Ok(result);
            });
        }

        [HttpPost("Query")]
        public async Task<IActionResult> Query([FromBody] Query query)
        {
            return await ExecutionAsync(async () =>
            {
                var result = await service.Query(query);
                return Ok(result);
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] T entity)
        {
            return await ExecutionAsync(async () =>
            {
                var result = await service.CreateAsync(entity);
                return Ok(result);
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] T entity)
        {
            return await ExecutionAsync(async () =>
            {
                var result = await service.UpdateAsync(entity);
                return Ok(result);
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            return await ExecutionAsync(async () =>
            {
                var result = await service.DeleteAsync(id);
                return Ok(result);
            });
        }
    }
}
