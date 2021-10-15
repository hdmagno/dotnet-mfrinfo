using System;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Infra.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Repository
{
    public class CepRepository : BaseRepository<CepEntity>, ICepRepository
    {
        private DbSet<CepEntity> _dataset;
        public CepRepository(DataContext context) : base(context)
        {
            _dataset = context.Set<CepEntity>();
        }

        public async Task<CepEntity> SelectAsync(string cep)
        {
            try
            {
                var result = await _dataset
                .Include(x => x.Municipio)
                .ThenInclude(x => x.Uf)
                .FirstOrDefaultAsync(x => x.Cep.Equals(cep));

                result = result != null ? result : null;

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<CepEntity> SelectAsync(Guid id)
        {
            try
            {
                var result = await _dataset
                .Include(x => x.Municipio)
                .ThenInclude(x => x.Uf)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

                result = result != null ? result : null;

                return result;

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
