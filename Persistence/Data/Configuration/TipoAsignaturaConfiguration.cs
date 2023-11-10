using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class TipoAsignaturaConfiguration : IEntityTypeConfiguration<TipoAsignatura>
  {
     public void Configure(EntityTypeBuilder<TipoAsignatura> builder)
    {
        builder.ToTable("Tipo_Asignatura");

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(25);
  }
  }