using Domain.Entities;
namespace Domain.Interfaces;

public interface ICursoEscolar : IGenericRepository<CursoEscolar>
{
        public  Task<IEnumerable<object>> AlumnosMatriculados();

}