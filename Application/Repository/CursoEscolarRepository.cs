using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class CursoEscolarRepository : GenericRepository<CursoEscolar>, ICursoEscolar
    {
        private readonly UniversidadContext _context;
        public CursoEscolarRepository(UniversidadContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<CursoEscolar>> GetAllAsync()
        {
            return await _context.CursosEscolares.ToListAsync();
        }
        public async Task<IEnumerable<object>> AlumnosMatriculados()
        {
            var resultado = await _context.CursosEscolares
                .Select(curso => new
                {
                    AnioInicioCurso = curso.AnhoInicio,
                    NumeroAlumnosMatriculados = curso.AlumnoAsignaturas.Select(aa => aa.Id_alumno).Distinct().Count()
                })
                .ToListAsync();

            return resultado;
        }

    }
}