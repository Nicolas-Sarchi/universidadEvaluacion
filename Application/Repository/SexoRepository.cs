using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class SexoRepository : GenericRepository<Sexo> , ISexo
    {
     private readonly UniversidadContext _context;
        public SexoRepository(UniversidadContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Sexo>> GetAllAsync()
{
 return await _context.Sexos.ToListAsync();
}  
}
}