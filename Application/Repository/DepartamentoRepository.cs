using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
    {
        private readonly UniversidadContext _context;
        public DepartamentoRepository(UniversidadContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Departamento>> GetAllAsync()
        {
            return await _context.Departamentos.ToListAsync();
        }

        public async Task<IEnumerable<Departamento>> ObtenerDepartamentosSinProfesores()
        {
            var departamentosSinProfesores = await _context.Departamentos
                .Where(d => !d.Profesores.Any())
                .ToListAsync();

            return departamentosSinProfesores;
        }

        public async Task<IEnumerable<object>> ObtenerProfesoresPorDepartamentoAsync()
        {
            var resultado = await _context.Departamentos
                .Where(depto => depto.Profesores.Any())
                .Select(depto => new
                {
                    NombreDepartamento = depto.Nombre,
                    NumeroProfesores = depto.Profesores.Count
                })
                .OrderByDescending(depto => depto.NumeroProfesores)
                .ToListAsync();

            return resultado;
        }

        public async Task<IEnumerable<Departamento>> DepartamentosSinAsignaturascurso()
        {
            var departamentosSinAsignaturasImpartidas = await _context.Departamentos
            .Where(d => d.Profesores.Any())
            .Where(d => !d.Profesores.Any(p => p.Asignaturas.Any(a => a.Id_Profesor != null && _context.AlumnoAsignaturas.Any(asm => asm.Id_asignatura == a.Id && asm.Id_curso_escolar != null))))
            .ToListAsync();
            return departamentosSinAsignaturasImpartidas;
        }


    }
}