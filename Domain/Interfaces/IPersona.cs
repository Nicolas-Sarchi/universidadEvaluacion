using Domain.Entities;
namespace Domain.Interfaces;

public interface IPersona : IGenericRepository<Persona>
{
    public Task<IEnumerable<Persona>> ObtenerListadoAlumnosAsync();
    public Task<IEnumerable<Persona>> AlumnosSinTelefono();
    public Task<IEnumerable<Persona>> Alumnos1999();
    public Task<IEnumerable<Persona>> AlumnasMatriculadasInformatica();
    public Task<IEnumerable<AlumnoAsignatura>> ObtenerAsignaturasCursoAlumno(string nif);
    public Task<IEnumerable<Persona>> AlumnosMatriculados2018_2019();
        public  Task<int> ObtenerNumeroTotalAlumnas();
        public  Task<int> ContarAlumnosNacidosEn1999();
        public  Task<Persona> AlumnoMasJoven();




}