using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class AsignaturaRepository : GenericRepository<Asignatura>, IAsignatura
    {
        private readonly UniversidadContext _context;
        public AsignaturaRepository(UniversidadContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Asignatura>> GetAllAsync()
        {
            return await _context.Asignaturas
            .Include(a => a.Profesor)
                .ThenInclude(a => a.Persona)
                .Include(a => a.TipoAsignatura)
                .Include(a => a.Grado)
            .ToListAsync();
        }

        public async Task<IEnumerable<Asignatura>> ObtenerAsignaturas()
        {
            return await _context.Asignaturas
                .Where(a => a.Cuatrimestre == 1 && a.Curso == 3 && a.Id_Grado == 7)
                .Include(a => a.Profesor)
                .ThenInclude(a => a.Persona)
                .Include(a => a.TipoAsignatura)
                .Include(a => a.Grado)
                .ToListAsync();
        }

        public async Task<IEnumerable<Asignatura>> ObtenerAsignaturasInformatica()
        {
            return await _context.Asignaturas
                .Include(a => a.Grado)
                .Include(a => a.Profesor)
                .ThenInclude(a => a.Persona)
                .Include(a => a.TipoAsignatura)
                .Where(a => a.Grado.Id == 4)
                .ToListAsync();
        }

        public async Task<IEnumerable<Asignatura>> ObtenerAsignaturasSinProfesor()
        {
            var asignaturasSinProfesor = await _context.Asignaturas
                .Where(a => a.Profesor == null)
                .Include(a => a.Grado)
                .Include(a => a.TipoAsignatura)
                .ToListAsync();

            return asignaturasSinProfesor;
        }

        public async Task<IEnumerable<object>> ObtenerAsignaturasNoImpartidas()
        {
            var resultado = await _context.Asignaturas
                .Where(asignatura => !asignatura.AlumnoAsignaturas.Any())
                .Select(asignatura => new
                {
                    NombreDepartamento = asignatura.Profesor.Departamento.Nombre,
                    AsignaturaNoImpartida = asignatura.Nombre
                })
                .ToListAsync();

            return resultado.Cast<object>();
        }






    }







}
