using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class TipoAsignaturaRepository : GenericRepository<TipoAsignatura> , ITipoAsignatura
    {
     private readonly UniversidadContext _context;
        public TipoAsignaturaRepository(UniversidadContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<TipoAsignatura>> GetAllAsync()
{
 return await _context.TipoAsignaturas.ToListAsync();
}  
}
}