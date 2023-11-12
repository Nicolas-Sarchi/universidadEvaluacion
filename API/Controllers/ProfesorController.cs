using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    public class ProfesorController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public ProfesorController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProfesorDto>>> Get()
        {
            var Profesor = await _unitOfWork.Profesores.GetAllAsync();
            return mapper.Map<List<ProfesorDto>>(Profesor);
        }

        [HttpGet("ListarProfesoresSinTelefono")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProfesorDto>>> GetsinTelefono()
        {
            var Profesor = await _unitOfWork.Profesores.ObtenerProfesoresnoTelefono();
            return mapper.Map<List<ProfesorDto>>(Profesor);
        }

        [HttpGet("ListarProfesoresConDepartamento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProfesorDepartamentoDTO>>> GetConDepto()
        {
            var Profesor = await _unitOfWork.Profesores.ObtenerProfesoresconDepto();
            return mapper.Map<List<ProfesorDepartamentoDTO>>(Profesor);
        }

        [HttpGet("ListadoProfesoresDepartamentos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProfesorDepartamentoDTO>>> GetCoListadoProfesoresDepartamentosnDepto()
        {
            var Profesor = await _unitOfWork.Profesores.ObtenerProfesoresconDepto();
            return mapper.Map<List<ProfesorDepartamentoDTO>>(Profesor);
        }

        [HttpGet("sinAsignatura")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProfesorDto>>> sinAsignatura()
        {
            var Profesor = await _unitOfWork.Profesores.ObtenerProfesoresSinAsignaturas();
            return mapper.Map<List<ProfesorDto>>(Profesor);
        }

        [HttpGet("conDeptosinAsignatura")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProfesorDto>>> conDeptosinAsignatura()
        {
            var Profesor = await _unitOfWork.Profesores.ProfesoresSinAsignaturas();
            return mapper.Map<List<ProfesorDto>>(Profesor);
        }

        
         [HttpGet("porDepto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> porDepto()
        {
            var Profesor = await _unitOfWork.Profesores.ObtenerProfesoresPorDepartamento();
            return Ok(Profesor);
        }

          [HttpGet("NumeroporDepto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> NumeroporDepto()
        {
            var Profesor = await _unitOfWork.Profesores.NumeroProfesoresPorDepartamento();
            return Ok(Profesor);
        }

          [HttpGet("AsignaturasPorProfesor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> AsignaturasPorProfesor()
        {
            var Profesor = await _unitOfWork.Profesores.NumeroAsignaturasPorProfesor();
            return Ok(Profesor);
        }
 
 
 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Profesor>> Post(ProfesorDto ProfesorDto)
        {
            var Profesor = this.mapper.Map<Profesor>(ProfesorDto);
            _unitOfWork.Profesores.Add(Profesor);
            await _unitOfWork.SaveAsync();
 
            if (Profesor == null)
            {
                return BadRequest();
            }
            ProfesorDto.Id = Profesor.Id;
            return CreatedAtAction(nameof(Post), new { id = ProfesorDto.Id }, Profesor);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProfesorDto>> Get(int id)
        {
            var Profesor = await _unitOfWork.Profesores.GetByIdAsync(id);
            return mapper.Map<ProfesorDto>(Profesor);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProfesorDto>> Put(int id, [FromBody] ProfesorDto ProfesorDto)
        {
            if (ProfesorDto == null)
                return NotFound();

            var Profesor = this.mapper.Map<Profesor>(ProfesorDto);
            _unitOfWork.Profesores.Update(Profesor);
            await _unitOfWork.SaveAsync();
            return ProfesorDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Profesor = await _unitOfWork.Profesores.GetByIdAsync(id);
            if (Profesor == null)
                return NotFound();

            _unitOfWork.Profesores.Remove(Profesor);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}