using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Mappings
{
    public class CepMap : IEntityTypeConfiguration<CepEntity>
    {
        public void Configure(EntityTypeBuilder<CepEntity> builder)
        {
            builder
                .ToTable("Cep");

            builder
                .HasKey(x => x.Id);

            builder
                .HasIndex(x => x.Cep);

            builder
                .HasOne(x => x.Municipio)
                .WithMany(x => x.Ceps);
        }
    }
}
