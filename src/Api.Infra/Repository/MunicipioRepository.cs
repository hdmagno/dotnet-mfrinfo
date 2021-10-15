using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Repository
{
    public class MunicipioRepository : BaseRepository<MunicipioEntity>, IMunicipioRepository
    {
        private DbSet<MunicipioEntity> _dataset;
        public MunicipioRepository(DataContext context) : base(context)
        {
            _dataset = context.Set<MunicipioEntity>();
        }

        public async Task<MunicipioEntity> GetCompleteByIBGE(int codIBGE)
        {
            try
            {
                var result = await _dataset
                    .Include(x => x.Uf)
                    .FirstOrDefaultAsync(x => x.CodIBGE.Equals(codIBGE));

                result = result != null ? result : null;

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MunicipioEntity> GetCompleteById(Guid id)
        {
            try
            {
                var result = await _dataset
                    .Include(x => x.Uf)
                    .FirstOrDefaultAsync(x => x.Id.Equals(id));

                result = result != null ? result : null;

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<UfEntity> InsertAsync(UfEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<UfEntity> UpdateAsync(UfEntity entity, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
