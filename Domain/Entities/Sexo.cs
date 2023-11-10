using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Domain.Entities
{
    public class Sexo : BaseEntity
    {
        public string Nombre { get; set; }
        public ICollection<Persona> Personas { get; set; }
        
    }
}