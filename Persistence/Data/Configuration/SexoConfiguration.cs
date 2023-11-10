using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class SexoConfiguration : IEntityTypeConfiguration<Sexo>
{
    public void Configure(EntityTypeBuilder<Sexo> builder)
    {
        builder.ToTable("Sexo");

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(25);
    }
}