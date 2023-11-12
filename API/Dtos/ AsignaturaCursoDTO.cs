using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class AsignaturaCursoDTO
    {
        public string NombreAsignatura { get; set; }
        public int AnioInicioCurso { get; set; }
        public int AnioFinCurso { get; set; }
    }
}