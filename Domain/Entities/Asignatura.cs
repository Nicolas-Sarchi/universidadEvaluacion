using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Asignatura : BaseEntity
    {
        public string Nombre { get; set; }
        public float Creditos { get; set; }
        public int IdTipoAsignatura { get; set; }
        public TipoAsignatura TipoAsignatura { get; set; }
        public int Curso { get; set; }
        public int Cuatrimestre { get; set; }
        public int? Id_Profesor { get; set; }
        public Profesor Profesor { get; set; }
        public int Id_Grado { get; set; }
        public Grado Grado { get; set; }
        
        public ICollection<AlumnoAsignatura> AlumnoAsignaturas { get; set; } 
    
    }
}