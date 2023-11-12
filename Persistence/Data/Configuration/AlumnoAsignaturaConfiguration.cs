using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
namespace Persistence.Data.Configurations;
  public class AlumnoAsignaturaConfiguration : IEntityTypeConfiguration<AlumnoAsignatura>
  {
     public void Configure(EntityTypeBuilder<AlumnoAsignatura> builder)
    {
        builder.ToTable("Alumno_se_matricula_Asignatura");

        builder
                .HasKey(urrt => new { urrt.Id_alumno, urrt.Id_curso_escolar, urrt.Id_asignatura });

            builder
                .HasOne(urrt => urrt.CursoEscolar)
                .WithMany(u => u.AlumnoAsignaturas)
                .HasForeignKey(urrt => urrt.Id_curso_escolar);

            builder
                .HasOne(urrt => urrt.Asignatura)
                .WithMany(r => r.AlumnoAsignaturas)
                .HasForeignKey(urrt => urrt.Id_asignatura);

            builder
                .HasOne(urrt => urrt.Persona)
                .WithMany(rt => rt.AlumnoAsignaturas)
                .HasForeignKey(urrt => urrt.Id_alumno);
  }

  }