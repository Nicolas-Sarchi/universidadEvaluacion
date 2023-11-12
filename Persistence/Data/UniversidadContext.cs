using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class UniversidadContext  :DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
        public DbSet<TipoPersona> TipoPersonas { get; set; }
        public DbSet<TipoAsignatura> TipoAsignaturas { get; set; }
        public DbSet<AlumnoAsignatura> AlumnoAsignaturas { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<CursoEscolar> CursosEscolares { get; set; }
         public UniversidadContext(DbContextOptions<UniversidadContext> options) : base(options)
        {

        }

        

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}