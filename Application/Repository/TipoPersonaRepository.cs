using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class TipoPersonaRepository : GenericRepository<TipoPersona> , ITipoPersona
    {
     private readonly UniversidadContext _context;
        public TipoPersonaRepository(UniversidadContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<TipoPersona>> GetAllAsync()
{
 return await _context.TipoPersonas.ToListAsync();
}  
}
}