using Domain.Entities;
namespace Domain.Interfaces;

public interface IProfesor : IGenericRepository<Profesor>
{
    public Task<IEnumerable<Profesor>> ObtenerProfesoresnoTelefono();
        public  Task<IEnumerable<Profesor>> ObtenerProfesoresconDepto();
        public  Task<IEnumerable<Profesor>> DepartamentosConProfesoresInformatica();
        public  Task<IEnumerable<Profesor>> ListadoProfesoresDepartamentos();
        public  Task<IEnumerable<Profesor>> ObtenerProfesoresSinDepartamento();
        public  Task<IEnumerable<Profesor>> ObtenerProfesoresSinAsignaturas();
        public   Task<IEnumerable<object>> ObtenerProfesoresPorDepartamento();
        public  Task<IEnumerable<object>> NumeroProfesoresPorDepartamento();
        public  Task<IEnumerable<object>> NumeroAsignaturasPorProfesor();
                public  Task<IEnumerable<Profesor>> ProfesoresSinAsignaturas();








}