using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface ICepRepository : IBaseRepository<CepEntity>
    {
        Task<CepEntity> SelectAsync(string cep);
    }
}
