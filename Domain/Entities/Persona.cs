using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Persona : BaseEntity
    {
        public string NIF { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public int Id_Sexo { get; set; }
        public Sexo Sexo { get; set; }
        public int IdTipoPersona { get; set; }
        public TipoPersona TipoPersona { get; set; }
        public int IdProfesor { get; set; }
        public Profesor Profesor { get; set; }

        public ICollection<AlumnoAsignatura> AlumnoAsignaturas { get; set; }
        public ICollection<Asignatura> Asignaturas { get; set; }
        // public ICollection<CursoEscolar> CursosEscolares { get; set; }

    }
}