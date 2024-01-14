using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_CRM_Blazor.Server.Services;
using Mini_CRM_Blazor.Shared.Dtos;

namespace Mini_CRM_Blazor.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanySubscriberController : ControllerBase
    {
        private readonly CompanySubscribersService _service;

        public CompanySubscriberController(CompanySubscribersService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();

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
        //public async Task<IActionResult> Put(int id, [FromBody] CompanySubscriberUpdateRequest updateModel)
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
