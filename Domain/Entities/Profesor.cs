using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Profesor : BaseEntity
    {
        public int IdPersona { get; set; }
        public Persona Persona{ get; set; }
        public int Id_departamento { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<Asignatura> Asignaturas { get; set; }
    }
}