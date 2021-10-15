using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Mappings
{
    public class MunicipioMap : IEntityTypeConfiguration<MunicipioEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MunicipioEntity> builder)
        {
            builder
                .ToTable("Municipio");

            builder
                .HasKey(x => x.Id);

            builder
                .HasIndex(x => x.CodIBGE);

            builder
                 .HasOne(x => x.Uf)
                 .WithMany(x => x.Municipios);

        }
    }
}
