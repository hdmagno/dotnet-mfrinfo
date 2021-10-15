using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Teste.Usuario
{
    public class QuandoForExecutadoCreate : UsuarioTeste
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possível executar o método Create")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(createUserDto)).ReturnsAsync(createUserDtoResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(createUserDto);
            Assert.NotNull(result);
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(EmailUsuario, result.Email);
        }
    }
}
