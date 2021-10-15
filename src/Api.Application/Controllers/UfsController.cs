using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Uf;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UfsController : ControllerBase
    {
        private readonly IUfService _ufService;

        public UfsController(IUfService ufService)
        {
            _ufService = ufService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _ufService.GetAll();
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _ufService.Get(id);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(new { message = "Id não localicado" });
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
