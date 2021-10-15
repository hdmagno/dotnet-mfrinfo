using System;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IMunicipioRepository : IBaseRepository<MunicipioEntity>
    {
        Task<MunicipioEntity> GetCompleteById(Guid id);
        Task<MunicipioEntity> GetCompleteByIBGE(int codIBGE);
    }
}
