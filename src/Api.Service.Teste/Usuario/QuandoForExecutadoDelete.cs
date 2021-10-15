using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Teste.Usuario
{
    public class QuandoForExecutadoDelete : UsuarioTeste
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Quando for executado o Delete")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(createUserDto)).ReturnsAsync(createUserDtoResult);
            _service = _serviceMock.Object;

            var resultCreate = await _service.Post(createUserDto);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(resultCreate.Id)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var _deletado = await _service.Delete(resultCreate.Id);
            Assert.True(_deletado);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            var _naoDeletado = await _service.Delete(resultCreate.Id);
            Assert.False(_naoDeletado);
        }
    }
}
