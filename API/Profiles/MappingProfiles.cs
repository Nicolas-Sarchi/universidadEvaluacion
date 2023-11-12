using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
      public MappingProfiles(){

        CreateMap<Persona, PersonaDto>().
        ForMember(d => d.Sexo, o => o.MapFrom(s => s.Sexo.Nombre)).
        ForMember(d => d.TipoPersona, o => o.MapFrom(s => s.TipoPersona.Descripcion));

        CreateMap<Profesor, ProfesorDto>().
        ForMember(d => d.Apellido1, o => o.MapFrom(s => s.Persona.Apellido1)).
        ForMember(d => d.Apellido2, o => o.MapFrom(s => s.Persona.Apellido2)).
        ForMember(d => d.Nombre, o => o.MapFrom(s => s.Persona.Nombre)).
        ForMember(d => d.NIF, o => o.MapFrom(s => s.Persona.NIF)).
        ForMember(d => d.Ciudad, o => o.MapFrom(s => s.Persona.Ciudad)).
        ForMember(d => d.Direccion, o => o.MapFrom(s => s.Persona.Direccion)).
        ForMember(d => d.FechaNacimiento, o => o.MapFrom(s => s.Persona.FechaNacimiento)).
        ForMember(d => d.Telefono, o => o.MapFrom(s => s.Persona.Telefono)).
        ForMember(d => d.Departamento, o => o.MapFrom(s => s.Departamento.Nombre)).
        ForMember(d => d.Sexo, o => o.MapFrom(s => s.Persona.Sexo.Nombre)).
        ForMember(d => d.TipoPersona, o => o.MapFrom(s => s.Persona.TipoPersona.Descripcion));

        CreateMap<Persona, ListarAlumnosDto>().
        ForMember(d => d.TipoPersona, o => o.MapFrom(s => s.TipoPersona.Descripcion));


        CreateMap<Asignatura, AsignaturaDto>().
        ForMember(d => d.Grado, o => o.MapFrom(s => s.Grado.Nombre)).
        ForMember(d => d.Profesor, o => o.MapFrom(s => s.Profesor.Persona.Nombre + " " + s.Profesor.Persona.Apellido1 + " " + s.Profesor.Persona.Apellido2)).
        ForMember(d => d.TipoAsignatura, o => o.MapFrom(s => s.TipoAsignatura.Nombre));   

        CreateMap<Profesor, ProfesorDepartamentoDTO>().
        ForMember(d => d.PrimerApellido, o => o.MapFrom(s => s.Persona.Apellido1)).
        ForMember(d => d.SegundoApellido, o => o.MapFrom(s => s.Persona.Apellido2)).
        ForMember(d => d.Nombre, o => o.MapFrom(s => s.Persona.Nombre)).
        ForMember(d => d.NombreDepartamento, o => o.MapFrom(s => s.Departamento.Nombre));

        CreateMap<AlumnoAsignatura, AsignaturaCursoDTO>().
        ForMember(d => d.NombreAsignatura, o => o.MapFrom(s => s.Asignatura.Nombre)).
        ForMember(d => d.AnioInicioCurso, o => o.MapFrom(s => s.CursoEscolar.AnhoInicio)).
        ForMember(d => d.AnioFinCurso, o => o.MapFrom(s => s.CursoEscolar.AnhoFin));

        CreateMap<Profesor, NomDeptoDto>().
        ForMember(d => d.NombreDepartamento, o => o.MapFrom(s => s.Departamento.Nombre));

        CreateMap<Departamento, DepartamentoDto>().ReverseMap();
         CreateMap<object, DeptoAsignaturaNoImpartida>()
            .ForMember(dest => dest.NombreDepartamento, opt => opt.MapFrom(src => src.GetType().GetProperty("NombreDepartamento").GetValue(src)))
            .ForMember(dest => dest.AsignaturaNoImpartida, opt => opt.MapFrom(src => src.GetType().GetProperty("AsignaturaNoImpartida").GetValue(src).ToString()));
       
      }   
    }
}