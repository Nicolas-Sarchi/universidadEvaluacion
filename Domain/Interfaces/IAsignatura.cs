using Domain.Entities;
namespace Domain.Interfaces;

public interface IAsignatura : IGenericRepository<Asignatura>
{
    public Task<IEnumerable<Asignatura>> ObtenerAsignaturas();
    public Task<IEnumerable<Asignatura>> ObtenerAsignaturasInformatica();
    public Task<IEnumerable<Asignatura>> ObtenerAsignaturasSinProfesor();
        public  Task<IEnumerable<object>> ObtenerAsignaturasNoImpartidas();




}