using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class ProfesorConfiguration : IEntityTypeConfiguration<Profesor>
{
    public void Configure(EntityTypeBuilder<Profesor> builder)
    {
        builder.ToTable("Profesor");
        
        
        builder.HasOne(p => p.Departamento)
        .WithMany(p => p.Profesores)
        .HasForeignKey(p => p.Id_departamento);

        builder.HasOne(p => p.Persona)
        .WithMany(p => p.Profesores)
        .HasForeignKey(p => p.IdPersona);
        
    }
}