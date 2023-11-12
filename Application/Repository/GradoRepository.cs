using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class GradoRepository : GenericRepository<Grado>, IGrado
    {
        private readonly UniversidadContext _context;
        public GradoRepository(UniversidadContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Grado>> GetAllAsync()
        {
            return await _context.Grados.ToListAsync();
        }

        public async Task<IEnumerable<object>> NumeroAsignaturasPorGrado()
        {
            var resultado = await _context.Grados
                .Select(grado => new
                {
                    NombreGrado = grado.Nombre,
                    NumeroAsignaturas = grado.Asignaturas.Count
                })
                .OrderByDescending(x => x.NumeroAsignaturas)
                .ToListAsync();

            return resultado;
        }

        public async Task<IEnumerable<object>> GradosConMasDe40Asignaturas()
        {
            var resultado = await _context.Grados
                .Where(grado => grado.Asignaturas.Count > 40)
                .Select(grado => new
                {
                    NombreGrado = grado.Nombre,
                    NumeroAsignaturas = grado.Asignaturas.Count
                })
                .ToListAsync();

            return resultado;
        }

        public async Task<IEnumerable<object>> SumaCreditos()
        {
            var resultado = await _context.Grados
                .SelectMany(grado => grado.Asignaturas
                    .GroupBy(asignatura => asignatura.TipoAsignatura.Nombre)
                    .Select(grupo => new
                    {
                        NombreGrado = grado.Nombre,
                        TipoAsignatura = grupo.Key,
                        SumaCreditos = grupo.Sum(asignatura => asignatura.Creditos)
                    }))
                .OrderByDescending(item => item.SumaCreditos)
                .ToListAsync();

            return resultado;
        }



    }
}