using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CursoEscolar : BaseEntity
    {
        public int AnhoInicio { get; set; }
        public int AnhoFin { get; set; }
       
        public ICollection<AlumnoAsignatura> AlumnoAsignaturas { get; set; }
    }
}