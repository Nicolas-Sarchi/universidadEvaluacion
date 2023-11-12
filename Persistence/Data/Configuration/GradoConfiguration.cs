using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class GradoConfiguration : IEntityTypeConfiguration<Grado>
{
    public void Configure(EntityTypeBuilder<Grado> builder)
    {
        builder.ToTable("Grado");

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(100);
    }
}