using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class PersonaRepository : GenericRepository<Persona>, IPersona
    {
        private readonly UniversidadContext _context;
        public PersonaRepository(UniversidadContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.Personas.Include(p => p.Sexo).Include(p => p.TipoPersona).ToListAsync();
        }
        public async Task<IEnumerable<Persona>> ObtenerListadoAlumnosAsync()
        {
            var listadoAlumnos = await _context.Personas
                .Where(p => p.IdTipoPersona == 1)
                .OrderBy(p => p.Apellido1)
                .ThenBy(p => p.Apellido2)
                .ThenBy(p => p.Nombre)
                .Select(p => new Persona
                {
                    Apellido1 = p.Apellido1,
                    Apellido2 = p.Apellido2,
                    Nombre = p.Nombre,
                    TipoPersona = p.TipoPersona

                })
                .ToListAsync();

            return listadoAlumnos;
        }



        public async Task<IEnumerable<Persona>> AlumnosSinTelefono()
        {
            return await _context.Personas
                .Where(p => p.Telefono == null && p.IdTipoPersona == 1)
                .Include(p => p.TipoPersona)
                .ToListAsync();
        }

        public async Task<IEnumerable<Persona>> Alumnos1999()
        {
            return await _context.Personas
            .Where(p => p.IdTipoPersona == 1 && p.FechaNacimiento.Year == 1999)
            .Include(p => p.TipoPersona)
            .Include(p => p.Sexo)
            .ToListAsync();
        }

        public async Task<IEnumerable<Persona>> AlumnasMatriculadasInformatica()
        {
            return await _context.AlumnoAsignaturas
                   .Where(aa => aa.Asignatura.Grado.Id == 4 && aa.Persona.IdTipoPersona == 1)
                   .Select(aa => new Persona
                   {
                       Id = aa.Persona.Id,
                       Nombre = aa.Persona.Nombre,
                       Apellido1 = aa.Persona.Apellido1,
                       Apellido2 = aa.Persona.Apellido2,
                       NIF = aa.Persona.NIF,
                       TipoPersona = aa.Persona.TipoPersona,
                       Sexo = aa.Persona.Sexo,
                       Ciudad = aa.Persona.Ciudad,
                       Direccion = aa.Persona.Direccion,
                       Telefono = aa.Persona.Telefono,
                       FechaNacimiento = aa.Persona.FechaNacimiento
                   })
                   .Where(p => p.Sexo.Nombre == "M")
                   .Distinct()
                   .ToListAsync();
        }


        public async Task<IEnumerable<AlumnoAsignatura>> ObtenerAsignaturasCursoAlumno(string nif)
        {
            return await _context.AlumnoAsignaturas
                .Include(aa => aa.Asignatura)
                .Include(a => a.CursoEscolar)
                .Where(aa => aa.Persona.NIF == nif)
                .ToListAsync();
        }

        public async Task<IEnumerable<Persona>> AlumnosMatriculados2018_2019()
        {
            var alumnos = await _context.AlumnoAsignaturas
                .Where(aa => aa.CursoEscolar.AnhoInicio == 2018 && aa.CursoEscolar.AnhoFin == 2019)
                .Select(aa => new Persona
                {
                    Id = aa.Persona.Id,
                    Nombre = aa.Persona.Nombre,
                    Apellido1 = aa.Persona.Apellido1,
                    Apellido2 = aa.Persona.Apellido2,
                    NIF = aa.Persona.NIF,
                    TipoPersona = aa.Persona.TipoPersona,
                    Sexo = aa.Persona.Sexo,
                    Ciudad = aa.Persona.Ciudad,
                    Direccion = aa.Persona.Direccion,
                    Telefono = aa.Persona.Telefono,
                    FechaNacimiento = aa.Persona.FechaNacimiento
                })
                .Distinct()
                .ToListAsync();

            return alumnos;
        }

        public async Task<int> ObtenerNumeroTotalAlumnas()
        {
            return await _context.Personas
                .CountAsync(p => p.IdTipoPersona == 1 && p.Sexo.Nombre == "M");
        }

        public async Task<int> ContarAlumnosNacidosEn1999()
        {
            return await _context.Personas
                .Where(p => p.IdTipoPersona == 1 && p.FechaNacimiento.Year == 1999)
                .CountAsync();
        }

        public async Task<Persona> AlumnoMasJoven()
        {
            var alumnoMasJoven = await _context.Personas
                .Where(persona => persona.IdTipoPersona == 1)
                .OrderByDescending(persona => persona.FechaNacimiento)
                .Include(persona => persona.Sexo)
                .Include(persona => persona.TipoPersona)
                .FirstOrDefaultAsync();

            return alumnoMasJoven;
        }











    }
}