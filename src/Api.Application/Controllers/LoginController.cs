using System;
using System.Threading.Tasks;
using Api.Domain.Dto;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _service;

        public LoginController(IUserService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<object>> Login([FromBody] LoginDto model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _service.GetByEmail(model.Email);

                    if (result == null)
                        return NotFound(new { message = "Email não localizado" });

                    return Ok(result);
                }
                catch (ArgumentException ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
