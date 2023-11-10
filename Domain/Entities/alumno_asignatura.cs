using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AlumnoAsignatura
    {
        public int Id_alumno { get; set; }
        public Persona Persona { get; set; }
        public int Id_asignatura { get; set; }
        public Asignatura Asignatura{ get; set; }
        public int Id_curso_escolar { get; set; }
        public CursoEscolar CursoEscolar { get; set; }

    }
    
}