using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("Persona");

        builder.Property(p => p.NIF)
        .IsRequired()
        .HasMaxLength(9);

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(25);

        builder.Property(p => p.Apellido1)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Apellido2)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Ciudad)
        .IsRequired()
        .HasMaxLength(25);

        builder.Property(p => p.Direccion)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Telefono)
        .HasMaxLength(9);

        builder.Property(p => p.FechaNacimiento)
        .IsRequired()
        .HasColumnType("date");

        builder.HasOne(p => p.Sexo)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.Id_Sexo);

        builder.HasOne(p => p.TipoPersona)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.IdTipoPersona);

        


       
        
    }
}