using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class AsignaturaDto : BaseDto
    {
        public string Nombre { get; set; }
        public float Creditos { get; set; }
        public string TipoAsignatura { get; set; }
        public int Curso { get; set; }
        public int Cuatrimestre { get; set; }
        public string Profesor { get; set; }
        public string Grado { get; set; }
    }
}