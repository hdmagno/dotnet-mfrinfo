using System;
using System.Threading.Tasks;
using Api.Domain.Dto;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Teste.Usuario
{
    public class QuandoForExecutadoGet : UsuarioTeste
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possível executar o método GET")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetById(IdUsuario)).ReturnsAsync(userDto);
            _service = _serviceMock.Object;

            var result = await _service.GetById(IdUsuario);

            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(EmailUsuario, result.Email);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.GetById(IdUsuario);
            Assert.Null(_record);
        }
    }
}
