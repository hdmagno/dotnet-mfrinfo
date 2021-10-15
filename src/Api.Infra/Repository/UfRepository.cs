using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Api.Infra.Repository
{
    public class UfRepository : BaseRepository<UfEntity>, IUfRepository
    {
        private DbSet<UfEntity> _dataset;
        public UfRepository(DataContext context) : base(context)
        {
            _dataset = context.Set<UfEntity>();
        }

        public override async Task<IEnumerable<UfEntity>> SelectAsync()
        {
            return await _dataset.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
