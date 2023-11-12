using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    public class GradoController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public GradoController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<GradoDto>>> Get()
        {
            var Grado = await _unitOfWork.Grados.GetAllAsync();
            return mapper.Map<List<GradoDto>>(Grado);
        }
          [HttpGet("NumeroAsignaturas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> NumeroAsignaturas()
        {
            var Profesor = await _unitOfWork.Grados.NumeroAsignaturasPorGrado();
            return Ok(Profesor);
        }

         [HttpGet("mas40Asignaturas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> mas40Asignaturas()
        {
            var Profesor = await _unitOfWork.Grados.GradosConMasDe40Asignaturas();
            return Ok(Profesor);
        }
          [HttpGet("SumaCreditos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> SumaCreditos()
        {
            var Profesor = await _unitOfWork.Grados.SumaCreditos();
            return Ok(Profesor);
        }
 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Grado>> Post(GradoDto GradoDto)
        {
            var Grado = this.mapper.Map<Grado>(GradoDto);
            _unitOfWork.Grados.Add(Grado);
            await _unitOfWork.SaveAsync();
 
            if (Grado == null)
            {
                return BadRequest();
            }
            GradoDto.Id = Grado.Id;
            return CreatedAtAction(nameof(Post), new { id = GradoDto.Id }, Grado);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GradoDto>> Get(int id)
        {
            var Grado = await _unitOfWork.Grados.GetByIdAsync(id);
            return mapper.Map<GradoDto>(Grado);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GradoDto>> Put(int id, [FromBody] GradoDto GradoDto)
        {
            if (GradoDto == null)
                return NotFound();

            var Grado = this.mapper.Map<Grado>(GradoDto);
            _unitOfWork.Grados.Update(Grado);
            await _unitOfWork.SaveAsync();
            return GradoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Grado = await _unitOfWork.Grados.GetByIdAsync(id);
            if (Grado == null)
                return NotFound();

            _unitOfWork.Grados.Remove(Grado);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}