using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_CRM_Blazor.Server.Services;
using Mini_CRM_Blazor.Shared.Dtos;

namespace Mini_CRM_Blazor.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomersService _service;

        public CustomersController(CustomersService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAllByCompanySubscriberId(Guid id)
        {
            var result = await _service.GetAllByCompanySubscriberId(id);

            try
            {
                return Ok(result.Content);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetById(id);

            try
            {
                return Ok(result.Content);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] CustomerCreateRequest model)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            try
            {
                var result = await _service.Add(model);
                if (!result.Sucess)
                    return BadRequest(result.Message);

                return Ok(result.Content);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
