using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_CRM_Blazor.Server.Services;
using Mini_CRM_Blazor.Shared.Dtos;

namespace Mini_CRM_Blazor.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerContactsController : ControllerBase
    {
        private readonly CustomerContactsService _service;

        public CustomerContactsController(CustomerContactsService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAllByCustomerId(Guid id)
        {
            var result = await _service.GetAllByCustomerId(id);

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
        public async Task<IActionResult> Post([FromBody] CustomerContactCreateRequest model)
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
