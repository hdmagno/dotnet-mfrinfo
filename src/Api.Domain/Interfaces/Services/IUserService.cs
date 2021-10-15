using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dto;
using Api.Domain.Entity;

namespace Api.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<CreateUserDtoResult> Post(CreateUserDto dto);
        Task<UpdateUserDtoResult> Put(UpdateUserDto dto, Guid id);
        Task<bool> Delete(Guid id);
        Task<UserDto> GetById(Guid id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<object> GetByEmail(string email);
    }
}
