using Domain.Entities;
namespace Domain.Interfaces;

public interface IGrado : IGenericRepository<Grado>
{
        public  Task<IEnumerable<object>> NumeroAsignaturasPorGrado();
        public  Task<IEnumerable<object>> GradosConMasDe40Asignaturas();
        public  Task<IEnumerable<object>> SumaCreditos();



}