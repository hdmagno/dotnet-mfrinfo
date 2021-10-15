using Api.Domain.Entities;
using Api.Domain.Entity;
using Api.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<UfEntity>(new UfMap().Configure);
            modelBuilder.Entity<MunicipioEntity>(new MunicipioMap().Configure);
            modelBuilder.Entity<CepEntity>(new CepMap().Configure);
        }
    }
}
