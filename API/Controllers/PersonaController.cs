using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    public class PersonaController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public PersonaController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
        {
            var Persona = await _unitOfWork.Personas.GetAllAsync();
            return mapper.Map<List<PersonaDto>>(Persona);
        }

        [HttpGet("Alumnos/1999")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> GetAlumnos1999()
        {
            var Persona = await _unitOfWork.Personas.Alumnos1999();
            return mapper.Map<List<PersonaDto>>(Persona);
        }

        [HttpGet("AlumnasInformatica")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> AlumnasMatriculadasInformatica()
        {
            var Persona = await _unitOfWork.Personas.AlumnasMatriculadasInformatica();
            return mapper.Map<List<PersonaDto>>(Persona);
        }

        [HttpGet("ListarAlumnos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ListarAlumnosDto>>> GetAlumnos()
        {
            var Persona = await _unitOfWork.Personas.ObtenerListadoAlumnosAsync();
            return mapper.Map<List<ListarAlumnosDto>>(Persona);
        }

        [HttpGet("Listar-Alumnos-Sin-Telefono")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ListarAlumnosDto>>> GetAlumnossintelefono()
        {
            var Persona = await _unitOfWork.Personas.AlumnosSinTelefono();
            return mapper.Map<List<ListarAlumnosDto>>(Persona);
        }

        [HttpGet("ListAlumnoAsignaturas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AsignaturaCursoDTO>>> get1()
        {
            var Persona = await _unitOfWork.Personas.ObtenerAsignaturasCursoAlumno("26902806M");
            return mapper.Map<List<AsignaturaCursoDTO>>(Persona);
        }

        [HttpGet("AlumnosMatriculados2018-2019")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> get2()
        {
            var Persona = await _unitOfWork.Personas.AlumnosMatriculados2018_2019();
            return mapper.Map<List<PersonaDto>>(Persona);
        }

        [HttpGet("AlumnoMasJoven")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> AlumnoMasJoven()
        {
            var Persona = await _unitOfWork.Personas.AlumnoMasJoven();
            return mapper.Map<PersonaDto>(Persona);
        }

        [HttpGet("TotalAlumnas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> TotalAlumnas()
        {
            var Persona = await _unitOfWork.Personas.ObtenerNumeroTotalAlumnas();
            return Ok(Persona);
        }

        [HttpGet("Total1999")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Total1999()
        {
            var Persona = await _unitOfWork.Personas.ContarAlumnosNacidosEn1999();
            return Ok(Persona);
        }
 
 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Persona>> Post(PersonaDto PersonaDto)
        {
            var Persona = this.mapper.Map<Persona>(PersonaDto);
            _unitOfWork.Personas.Add(Persona);
            await _unitOfWork.SaveAsync();
 
            if (Persona == null)
            {
                return BadRequest();
            }
            PersonaDto.Id = Persona.Id;
            return CreatedAtAction(nameof(Post), new { id = PersonaDto.Id }, Persona);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> Get(int id)
        {
            var Persona = await _unitOfWork.Personas.GetByIdAsync(id);
            return mapper.Map<PersonaDto>(Persona);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody] PersonaDto PersonaDto)
        {
            if (PersonaDto == null)
                return NotFound();

            var Persona = this.mapper.Map<Persona>(PersonaDto);
            _unitOfWork.Personas.Update(Persona);
            await _unitOfWork.SaveAsync();
            return PersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Persona = await _unitOfWork.Personas.GetByIdAsync(id);
            if (Persona == null)
                return NotFound();

            _unitOfWork.Personas.Remove(Persona);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}