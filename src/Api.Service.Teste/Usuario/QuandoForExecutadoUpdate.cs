using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Teste.Usuario
{
    public class QuandoForExecutadoUpdate : UsuarioTeste
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possível executar o método Create")]
        public async Task E_Possivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(createUserDto)).ReturnsAsync(createUserDtoResult);
            _service = _serviceMock.Object;

            var resultCreate = await _service.Post(createUserDto);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Put(updateUserDto, resultCreate.Id)).ReturnsAsync(updateUserDtoResult);
            _service = _serviceMock.Object;

            var _resultUpdate = await _service.Put(updateUserDto, resultCreate.Id);
            Assert.NotNull(_resultUpdate);
            Assert.Equal(NomeUsuarioAlterado, _resultUpdate.Name);
            Assert.Equal(EmailUsuarioAlterado, _resultUpdate.Email);
        }
    }
}
