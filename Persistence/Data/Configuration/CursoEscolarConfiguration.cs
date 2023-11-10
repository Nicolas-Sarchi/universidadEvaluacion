using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class CursoEscolarConfiguration : IEntityTypeConfiguration<CursoEscolar>
{
    public void Configure(EntityTypeBuilder<CursoEscolar> builder)
    {
        builder.ToTable("Curso_Escolar");
        builder.Property(p => p.AnhoInicio)
        .IsRequired()
        .HasColumnType("YEAR(4)");

        builder.Property(p => p.AnhoFin)
        .IsRequired()
        .HasColumnType("YEAR(4)");
    }
}