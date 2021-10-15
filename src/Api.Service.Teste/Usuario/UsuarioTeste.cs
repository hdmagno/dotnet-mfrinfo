using System;
using System.Collections.Generic;
using Api.Domain.Dto;

namespace Api.Service.Teste.Usuario
{
    public class UsuarioTeste
    {

        public static Guid IdUsuario { get; set; }
        public static string NomeUsuario { get; set; }
        public static string EmailUsuario { get; set; }
        public static string NomeUsuarioAlterado { get; set; }
        public static string EmailUsuarioAlterado { get; set; }

        public List<UserDto> listaUserDto { get; set; } = new List<UserDto>();
        public UserDto userDto { get; set; }
        public CreateUserDto createUserDto { get; set; }
        public CreateUserDtoResult createUserDtoResult { get; set; }
        public UpdateUserDto updateUserDto { get; set; }
        public UpdateUserDtoResult updateUserDtoResult { get; set; }

        public UsuarioTeste()
        {
            IdUsuario = Guid.NewGuid();
            NomeUsuario = Faker.Name.FullName();
            EmailUsuario = Faker.Internet.Email();
            NomeUsuarioAlterado = Faker.Name.FullName();
            EmailUsuarioAlterado = Faker.Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDto
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };
                listaUserDto.Add(dto);
            }

            userDto = new UserDto
            {
                Id = IdUsuario,
                Name = NomeUsuario,
                Email = EmailUsuario
            };

            createUserDto = new CreateUserDto
            {
                Name = NomeUsuario,
                Email = EmailUsuario
            };

            createUserDtoResult = new CreateUserDtoResult
            {
                Id = IdUsuario,
                Name = NomeUsuario,
                Email = EmailUsuario,
                CreateAt = DateTime.UtcNow
            };

            updateUserDto = new UpdateUserDto
            {
                Id = IdUsuario,
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado
            };

            updateUserDtoResult = new UpdateUserDtoResult
            {
                Id = IdUsuario,
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}
