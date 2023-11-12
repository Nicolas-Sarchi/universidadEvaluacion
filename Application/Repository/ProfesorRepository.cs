using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class ProfesorRepository : GenericRepository<Profesor>, IProfesor
    {
        private readonly UniversidadContext _context;
        public ProfesorRepository(UniversidadContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Profesor>> GetAllAsync()
        {
            return await _context.Profesores.Include(p => p.Persona).ThenInclude(p => p.Sexo).Include(p => p.Persona).ThenInclude(p => p.TipoPersona).Include(p => p.Departamento).ToListAsync();
        }

        public async Task<IEnumerable<Profesor>> ObtenerProfesoresnoTelefono()
        {
            return await _context.Profesores
                .Where(profesor => profesor.Persona.Telefono == null && profesor.Persona.NIF.EndsWith("K"))
                .Include(p => p.Persona)
                .ThenInclude(p => p.Sexo)
                .Include(p => p.Persona)
                .ThenInclude(p => p.TipoPersona)
                .Include(p => p.Departamento)
                .ToListAsync();
        }

        public async Task<IEnumerable<Profesor>> ObtenerProfesoresconDepto()
        {
            return await _context.Profesores
            .Include(p => p.Persona)
            .OrderBy(p => p.Persona.Apellido1)
            .ThenBy(p => p.Persona.Apellido2)
            .ThenBy(p => p.Persona.Nombre)
            .Include(p => p.Departamento)
            .ToListAsync();

        }

        public async Task<IEnumerable<Profesor>> DepartamentosConProfesoresInformatica()
        {
            var departamentos = await _context.Profesores
                .Where(p => p.Asignaturas.Any(a => a.Grado.Id == 4))
                .Include(p => p.Departamento)
                .Distinct()
                .ToListAsync();

            return departamentos;
        }

        public async Task<IEnumerable<Profesor>> ListadoProfesoresDepartamentos()
        {
            var listadoProfesores = await _context.Profesores
                .Include(p => p.Persona)
                .Include(p => p.Departamento)
                .OrderBy(p => p.Departamento.Nombre)
                .ThenBy(p => p.Persona.Apellido1)
                .ThenBy(p => p.Persona.Apellido2)
                .ThenBy(p => p.Persona.Nombre)
                .ToListAsync();

            return listadoProfesores;
        }

        public async Task<IEnumerable<Profesor>> ObtenerProfesoresSinDepartamento()
        {
            var profesoresSinDepartamento = await _context.Profesores
                .Where(p => p.Departamento == null)
                .ToListAsync();

            return profesoresSinDepartamento;
        }

        public async Task<IEnumerable<Profesor>> ObtenerProfesoresSinAsignaturas()
        {
            var profesoresSinAsignaturas = await _context.Profesores
                .Where(p => !p.Asignaturas.Any())
                .Include(p => p.Persona)
                .ThenInclude(p => p.TipoPersona)
                .Include(p => p.Persona)
                .ThenInclude(p => p.Sexo)
                .ToListAsync();

            return profesoresSinAsignaturas;
        }

        public async Task<IEnumerable<object>> ObtenerProfesoresPorDepartamento()
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

        public async Task<IEnumerable<object>> NumeroProfesoresPorDepartamento()
        {
            var resultado = await _context.Departamentos
                .Select(depto => new
                {
                    NombreDepartamento = depto.Nombre,
                    NumeroProfesores = depto.Profesores.Count
                })
                .ToListAsync();

            return resultado;
        }

        public async Task<IEnumerable<object>> NumeroAsignaturasPorProfesor()
        {
            var resultado = await _context.Profesores
                .Select(profesor => new
                {
                    Id = profesor.Id,
                    Nombre = profesor.Persona.Nombre,
                    PrimerApellido = profesor.Persona.Apellido1,
                    SegundoApellido = profesor.Persona.Apellido2,
                    NumeroAsignaturas = profesor.Asignaturas.Count()
                })
                .OrderByDescending(profesor => profesor.NumeroAsignaturas)
                .ToListAsync();

            return resultado;
        }

        public async Task<IEnumerable<Profesor>> ProfesoresSinAsignaturas()
        {
            var profesoresSinAsignaturas = await _context.Profesores
                .Where(profesor => profesor.Id_departamento != null && !profesor.Asignaturas.Any())
                .Include(profesor => profesor.Persona)
                .ThenInclude(profesor => profesor.Sexo)
                .Include(profesor => profesor.Persona)
                .ThenInclude(profesor => profesor.TipoPersona)
                .Include(profesor => profesor.Departamento)
                .ToListAsync();

            return profesoresSinAsignaturas;
        }









    }
}