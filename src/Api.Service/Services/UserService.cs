using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using Api.Domain.Entity;
using Api.Domain.Security;
using Microsoft.IdentityModel.JsonWebTokens;
using Api.Domain.Dto;
using AutoMapper;
using System.Linq;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private IBaseRepository<UserEntity> _repository;
        private IUserRepository _userRepository;

        private SigningConfiguration _signingConfiguration;
        private TokenConfiguration _tokenConfiguration;
        private readonly IMapper _mapper;

        public UserService(
            IBaseRepository<UserEntity> repository,
            IUserRepository userRepository,
            SigningConfiguration signingConfiguration,
            TokenConfiguration tokenConfiguration, IMapper mapper)
        {
            _repository = repository;
            _userRepository = userRepository;
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
            _mapper = mapper;
        }

        public async Task<CreateUserDtoResult> Post(CreateUserDto dto)
        {
            var entity = _mapper.Map<UserEntity>(dto);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<CreateUserDtoResult>(result);
        }

        public async Task<UpdateUserDtoResult> Put(UpdateUserDto dto, Guid id)
        {
            var entity = _mapper.Map<UserEntity>(dto);
            var result = await _repository.UpdateAsync(entity, id);
            return _mapper.Map<UpdateUserDtoResult>(result);
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var entities = await _repository.SelectAsync();
            var users = entities.Select(s => _mapper.Map<UserDto>(s));

            return users;
        }

        public async Task<UserDto> GetById(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            var dto = _mapper.Map<UserDto>(entity);

            return dto;
        }

        public async Task<object> GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
            else
            {
                var user = await _userRepository.SelectAsync(email);

                if (user == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };
                }
                else
                {
                    var identity = new ClaimsIdentity(new GenericIdentity(user.Email), new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
                    });

                    var createDate = DateTime.Now;
                    var expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                    var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

                    var token = CreateToken(identity, createDate, expirationDate, handler);

                    return SuccessObject(createDate, expirationDate, token, email);
                }
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);

            return token;
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, string email)
        {
            return new
            {
                autenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                userName = email,
                message = "Usuário logado com sucesso"
            };
        }
    }
}
