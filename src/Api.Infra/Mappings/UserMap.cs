using Api.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
                .ToTable("User");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(60);

            builder
                .Property(x => x.Email)
                .HasMaxLength(100);

            builder
                .HasIndex(x => x.Email)
                .IsUnique();
        }
    }
}
