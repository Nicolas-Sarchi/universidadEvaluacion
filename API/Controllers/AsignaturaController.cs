using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    public class AsignaturaController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public AsignaturaController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AsignaturaDto>>> Get()
        {
            var Asignatura = await _unitOfWork.Asignaturas.GetAllAsync();
            return mapper.Map<List<AsignaturaDto>>(Asignatura);
        }

        [HttpGet("ListarAsignaturas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AsignaturaDto>>> GetAsignatura()
        {
            var Asignatura = await _unitOfWork.Asignaturas.ObtenerAsignaturas();
            return mapper.Map<List<AsignaturaDto>>(Asignatura);
        }

        [HttpGet("ListarAsignaturasInformatica")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AsignaturaDto>>> GetAsignaturaInformatica()
        {
            var Asignatura = await _unitOfWork.Asignaturas.ObtenerAsignaturasInformatica();
            return mapper.Map<List<AsignaturaDto>>(Asignatura);
        }

        [HttpGet("sinProfesor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AsignaturaDto>>> getsinProfesor()
        {
            var Asignatura = await _unitOfWork.Asignaturas.ObtenerAsignaturasSinProfesor();
            return mapper.Map<List<AsignaturaDto>>(Asignatura);
        }

        [HttpGet("noImpartida")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DeptoAsignaturaNoImpartida>>> noimpartida()
        {
            var Asignatura = await _unitOfWork.Asignaturas.ObtenerAsignaturasNoImpartidas();
            return mapper.Map<List<DeptoAsignaturaNoImpartida>>(Asignatura);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Asignatura>> Post(AsignaturaDto AsignaturaDto)
        {
            var Asignatura = this.mapper.Map<Asignatura>(AsignaturaDto);
            _unitOfWork.Asignaturas.Add(Asignatura);
            await _unitOfWork.SaveAsync();

            if (Asignatura == null)
            {
                return BadRequest();
            }
            AsignaturaDto.Id = Asignatura.Id;
            return CreatedAtAction(nameof(Post), new { id = AsignaturaDto.Id }, Asignatura);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AsignaturaDto>> Get(int id)
        {
            var Asignatura = await _unitOfWork.Asignaturas.GetByIdAsync(id);
            return mapper.Map<AsignaturaDto>(Asignatura);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AsignaturaDto>> Put(int id, [FromBody] AsignaturaDto AsignaturaDto)
        {
            if (AsignaturaDto == null)
                return NotFound();

            var Asignatura = this.mapper.Map<Asignatura>(AsignaturaDto);
            _unitOfWork.Asignaturas.Update(Asignatura);
            await _unitOfWork.SaveAsync();
            return AsignaturaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Asignatura = await _unitOfWork.Asignaturas.GetByIdAsync(id);
            if (Asignatura == null)
                return NotFound();

            _unitOfWork.Asignaturas.Remove(Asignatura);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}