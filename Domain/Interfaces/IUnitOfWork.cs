using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAsignatura Asignaturas {get;}
        ICursoEscolar CursosEscolares {get;}
        IDepartamento Departamentos {get;}
        IGrado Grados {get;}
        IPersona Personas {get;}
        IProfesor Profesores {get;}
        ISexo Sexos {get;}
        ITipoAsignatura TiposAsignatura {get;}
        ITipoPersona TiposPersona {get;}
        Task<int> SaveAsync();


    }
}