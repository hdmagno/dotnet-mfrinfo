using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dto;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Teste.Usuario
{
    public class QuandoForExecutadoGetAll : UsuarioTeste
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possível executar o método GETALL")]
        public async Task E_Possivel_Executar_Metodo_GetAll()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaUserDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() > 1);

            var _listResult = new List<UserDto>();
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _listResultEmpty = await _service.GetAll();
            Assert.Empty(_listResultEmpty);
            Assert.True(_listResultEmpty.Count() == 0);
        }
    }
}
