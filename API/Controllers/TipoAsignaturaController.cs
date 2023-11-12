using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    public class TipoAsignaturaController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public TipoAsignaturaController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoAsignaturaDto>>> Get()
        {
            var TipoAsignatura = await _unitOfWork.TiposAsignatura.GetAllAsync();
            return mapper.Map<List<TipoAsignaturaDto>>(TipoAsignatura);
        }
 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoAsignatura>> Post(TipoAsignaturaDto TipoAsignaturaDto)
        {
            var TipoAsignatura = this.mapper.Map<TipoAsignatura>(TipoAsignaturaDto);
            _unitOfWork.TiposAsignatura.Add(TipoAsignatura);
            await _unitOfWork.SaveAsync();
 
            if (TipoAsignatura == null)
            {
                return BadRequest();
            }
            TipoAsignaturaDto.Id = TipoAsignatura.Id;
            return CreatedAtAction(nameof(Post), new { id = TipoAsignaturaDto.Id }, TipoAsignatura);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoAsignaturaDto>> Get(int id)
        {
            var TipoAsignatura = await _unitOfWork.TiposAsignatura.GetByIdAsync(id);
            return mapper.Map<TipoAsignaturaDto>(TipoAsignatura);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoAsignaturaDto>> Put(int id, [FromBody] TipoAsignaturaDto TipoAsignaturaDto)
        {
            if (TipoAsignaturaDto == null)
                return NotFound();

            var TipoAsignatura = this.mapper.Map<TipoAsignatura>(TipoAsignaturaDto);
            _unitOfWork.TiposAsignatura.Update(TipoAsignatura);
            await _unitOfWork.SaveAsync();
            return TipoAsignaturaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var TipoAsignatura = await _unitOfWork.TiposAsignatura.GetByIdAsync(id);
            if (TipoAsignatura == null)
                return NotFound();

            _unitOfWork.TiposAsignatura.Remove(TipoAsignatura);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}