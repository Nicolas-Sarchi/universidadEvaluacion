using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class AsignaturaConfiguration : IEntityTypeConfiguration<Asignatura>
{
    public void Configure(EntityTypeBuilder<Asignatura> builder)
    {
        builder.ToTable("Asignatura");

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(p => p.Curso)
        .IsRequired()
        .HasColumnType("tinyint(3)");

        builder.Property(p => p.Cuatrimestre)
        .IsRequired()
        .HasColumnType("tinyint(3)");

        builder.HasOne(p => p.Grado)
        .WithMany(p => p.Asignaturas)
        .HasForeignKey(p => p.Id_Grado);

        builder.HasOne(p => p.Profesor)
        .WithMany(p => p.Asignaturas)
        .HasForeignKey(p => p.Id_Profesor);
    }
}