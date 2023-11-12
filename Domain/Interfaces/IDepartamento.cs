using Domain.Entities;
namespace Domain.Interfaces;

public interface IDepartamento : IGenericRepository<Departamento>
{
    public Task<IEnumerable<Departamento>> ObtenerDepartamentosSinProfesores();
      public  Task<IEnumerable<object>> ObtenerProfesoresPorDepartamentoAsync();
        public  Task<IEnumerable<Departamento>> DepartamentosSinAsignaturascurso();



}