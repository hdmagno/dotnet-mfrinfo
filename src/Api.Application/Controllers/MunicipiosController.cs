using System;
using System.Threading.Tasks;
using Api.Domain.Dto.Municipio;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipiosController : ControllerBase
    {
        private readonly IMunicipioService _municipioService;

        public MunicipiosController(IMunicipioService municipioService)
        {
            _municipioService = municipioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _municipioService.GetAll();
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _municipioService.Get(id);

                if (result == null)
                    return NotFound(new { message = "Id não localizado" });

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("completo/{id}")]
        public async Task<IActionResult> GetCompleteById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _municipioService.GetCompleteById(id);

                if (result == null)
                    return NotFound(new { message = "Id não localizado" });

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("byIbge/{codIBGE}")]
        public async Task<IActionResult> GetCompleteByIBGE([FromRoute] int codIBGE)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _municipioService.GetCompleteByIBGE(codIBGE);

                if (result == null)
                    return NotFound(new { message = "Código não localizado" });

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MunicipioDtoCreate dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _municipioService.Post(dto);

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
        public async Task<IActionResult> Put([FromBody] MunicipioDtoUpdate dto, [FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _municipioService.Put(dto, id);

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
                var result = await _municipioService.Delete(id);

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
