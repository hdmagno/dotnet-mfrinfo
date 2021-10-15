using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entity;
using Api.Infra.Contexts;
using Api.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Teste
{
    public class UsuarioCrudCompleto : BaseTeste, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public UsuarioCrudCompleto(DbTeste db)
        {
            _serviceProvider = db.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuario")]
        [Trait("CRUD", "UserEntity")]
        public async Task ShouldCrudUser()
        {
            using (var context = _serviceProvider.GetService<DataContext>())
            {
                UserRepository _repository = new UserRepository(context);
                UserEntity _entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                var _registroCriado = await _repository.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);

                var _buscaPorEmail = await _repository.SelectAsync(_entity.Email);
                Assert.NotNull(_buscaPorEmail);
                Assert.Equal(_entity.Email, _buscaPorEmail.Email);

                _entity.Name = Faker.Name.First();
                var _registroAtualizado = await _repository.UpdateAsync(_entity, _entity.Id);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entity.Email, _registroAtualizado.Email);
                Assert.Equal(_entity.Name, _registroAtualizado.Name);

                var _buscaTodos = await _repository.SelectAsync();
                Assert.NotNull(_registroAtualizado);
                Assert.True(_buscaTodos.Count() > 0);

                var _buscaPorId = await _repository.SelectAsync(_entity.Id);
                Assert.NotNull(_buscaPorId);
                Assert.Equal(_entity.Email, _registroAtualizado.Email);
                Assert.Equal(_entity.Name, _registroAtualizado.Name);

                var _registroRemovido = await _repository.DeleteAsync(_entity.Id);
                Assert.True(_registroRemovido);
            }
        }
    }
}
