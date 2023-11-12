using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    public class CursoEscolarController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public CursoEscolarController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CursoEscolarDto>>> Get()
        {
            var CursoEscolar = await _unitOfWork.CursosEscolares.GetAllAsync();
            return mapper.Map<List<CursoEscolarDto>>(CursoEscolar);
        }
          [HttpGet("AlumnosMatriculados")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> AlumnosMatriculados()
        {
            var Profesor = await _unitOfWork.CursosEscolares.AlumnosMatriculados();
            return Ok(Profesor);
        }
 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CursoEscolar>> Post(CursoEscolarDto CursoEscolarDto)
        {
            var CursoEscolar = this.mapper.Map<CursoEscolar>(CursoEscolarDto);
            _unitOfWork.CursosEscolares.Add(CursoEscolar);
            await _unitOfWork.SaveAsync();
 
            if (CursoEscolar == null)
            {
                return BadRequest();
            }
            CursoEscolarDto.Id = CursoEscolar.Id;
            return CreatedAtAction(nameof(Post), new { id = CursoEscolarDto.Id }, CursoEscolar);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CursoEscolarDto>> Get(int id)
        {
            var CursoEscolar = await _unitOfWork.CursosEscolares.GetByIdAsync(id);
            return mapper.Map<CursoEscolarDto>(CursoEscolar);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CursoEscolarDto>> Put(int id, [FromBody] CursoEscolarDto CursoEscolarDto)
        {
            if (CursoEscolarDto == null)
                return NotFound();

            var CursoEscolar = this.mapper.Map<CursoEscolar>(CursoEscolarDto);
            _unitOfWork.CursosEscolares.Update(CursoEscolar);
            await _unitOfWork.SaveAsync();
            return CursoEscolarDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var CursoEscolar = await _unitOfWork.CursosEscolares.GetByIdAsync(id);
            if (CursoEscolar == null)
                return NotFound();

            _unitOfWork.CursosEscolares.Remove(CursoEscolar);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}