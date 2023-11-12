using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork;
    public class UnitOfWork : IUnitOfWork

    {
        private readonly UniversidadContext context;
        private AsignaturaRepository _Asignaturas;
        private CursoEscolarRepository _CursosEscolares;
        private DepartamentoRepository _Departamentos;
        private GradoRepository _Grados;
        private PersonaRepository _Personas;
        private ProfesorRepository _Profesores;
        private SexoRepository _Sexos;
        private TipoPersonaRepository _TiposPersona;
        private TipoAsignaturaRepository _TiposAsignatura;
        



        public UnitOfWork(UniversidadContext _context)
        {
            context = _context;
        }

        public IAsignatura Asignaturas
        {
            get
            {
                if (_Asignaturas == null)
                {
                    _Asignaturas = new AsignaturaRepository(context);
                }
                return _Asignaturas;
            }
        }
        public ICursoEscolar CursosEscolares
        {
            get
            {
                if (_CursosEscolares == null)
                {
                    _CursosEscolares = new CursoEscolarRepository(context);
                }
                return _CursosEscolares;
            }
        }
        public IDepartamento Departamentos
        {
            get
            {
                if (_Departamentos == null)
                {
                    _Departamentos = new DepartamentoRepository(context);
                }
                return _Departamentos;
            }
        }
        public IGrado Grados
        {
            get
            {
                if (_Grados == null)
                {
                    _Grados = new GradoRepository(context);
                }
                return _Grados;
            }
        }
        public IPersona Personas
        {
            get
            {
                if (_Personas == null)
                {
                    _Personas = new PersonaRepository(context);
                }
                return _Personas;
            }
        }
        public IProfesor Profesores
        {
            get
            {
                if (_Profesores == null)
                {
                    _Profesores = new ProfesorRepository(context);
                }
                return _Profesores;
            }
        }
        public ISexo Sexos
        {
            get
            {
                if (_Sexos == null)
                {
                    _Sexos = new SexoRepository(context);
                }
                return _Sexos;
            }
        }

        public ITipoAsignatura TiposAsignatura
        {
            get
            {
                if (_TiposAsignatura == null)
                {
                    _TiposAsignatura = new TipoAsignaturaRepository(context);
                }
                return _TiposAsignatura;
            }
        }

        public ITipoPersona TiposPersona
        {
            get
            {
                if (_TiposPersona == null)
                {
                    _TiposPersona = new TipoPersonaRepository(context);
                }
                return _TiposPersona;
            }
        }

        public int Save()
        {
            return context.SaveChanges();
        }
        public Task<int> SaveAsync()
        {
            return context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }