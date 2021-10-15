using System;
using System.Threading.Tasks;
using Api.Domain.Dto;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Teste.Login
{
    public class QuandoForExecutadoLogin
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Quando for executado o Delete")]
        public async Task E_Possivel_Executar_Metodo_FindByEmail()
        {
            var email = Faker.Internet.Email();

            var objRetorno = new
            {
                autenticated = true,
                created = DateTime.UtcNow,
                expiration = DateTime.UtcNow.AddHours(8),
                accessToken = Guid.NewGuid(),
                userName = email,
                name = Faker.Name.FullName(),
                message = "Usuário logado com sucesso"
            };

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetByEmail(email)).ReturnsAsync(objRetorno);
            _service = _serviceMock.Object;

            var result = await _service.GetByEmail(email);
            Assert.NotNull(result);
        }
    }
}
