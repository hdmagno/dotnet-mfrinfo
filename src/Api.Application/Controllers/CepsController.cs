using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dto.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CepsController : ControllerBase
    {
        private readonly ICepService _cepService;

        public CepsController(ICepService cepService)
        {
            _cepService = cepService;
        }

        [HttpGet]
        [Route("{id}", Name = "GetCepWithId")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _cepService.Get(id);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(new { message = "Id não localizado" });
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("byCep/{cep}")]
        public async Task<IActionResult> Get([FromRoute] string cep)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _cepService.Get(cep);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(new { message = "Id não localizado" });
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CepDtoCreate dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _cepService.Post(dto);

                if (result != null)
                {
                    return StatusCode(201, result);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (ArgumentException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromBody] CepDtoUpdate dto, [FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _cepService.Put(dto, id);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (ArgumentException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _cepService.Delete(id);

                if (result == true)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (ArgumentException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
