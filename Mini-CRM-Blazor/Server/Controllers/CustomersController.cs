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

        //[HttpPut("{id}")]
        //[Authorize(Roles = "1, 3")]
        //public async Task<IActionResult> Put(int id, [FromBody] CustomerUpdateRequest updateModel)
        //{
        //    if (!ModelState.IsValid)
        //        return UnprocessableEntity(ModelState);
             
        //    var result = await _service.Update(id, updateModel);

        //    try
        //    {
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
