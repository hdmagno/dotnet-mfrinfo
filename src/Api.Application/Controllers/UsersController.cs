using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using Api.Domain.Dto;

namespace Api.Application.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult<CreateUserDtoResult>> Post([FromBody] CreateUserDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _userService.Post(dto);

                    if (result != null)
                    {
                        return Created(new Uri(Url.Link("GetById", new { id = result.Id })), result);
                    }
                    else
                    {
                        return BadRequest();
                    }
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

        [Authorize("Bearer")]
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<UpdateUserDtoResult>> Put([FromBody] UpdateUserDto dto, Guid id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _userService.Put(dto, id);

                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest();
                    }

                }
                catch (ArgumentException ex)
                {
                    return StatusCode(500, ex);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize("Bearer")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            try
            {
                var result = await _userService.Delete(id);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _userService.GetAll();
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

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetById")]
        public async Task<ActionResult<UserDto>> GetById(Guid id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _userService.GetById(id);
                    return Ok(result);
                }
                catch (ArgumentException ex)
                {
                    return StatusCode(500, ex);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
