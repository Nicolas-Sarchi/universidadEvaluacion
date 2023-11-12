using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    public class TipoPersonaController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public TipoPersonaController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoPersonaDto>>> Get()
        {
            var TipoPersona = await _unitOfWork.TiposPersona.GetAllAsync();
            return mapper.Map<List<TipoPersonaDto>>(TipoPersona);
        }
 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoPersona>> Post(TipoPersonaDto TipoPersonaDto)
        {
            var TipoPersona = this.mapper.Map<TipoPersona>(TipoPersonaDto);
            _unitOfWork.TiposPersona.Add(TipoPersona);
            await _unitOfWork.SaveAsync();
 
            if (TipoPersona == null)
            {
                return BadRequest();
            }
            TipoPersonaDto.Id = TipoPersona.Id;
            return CreatedAtAction(nameof(Post), new { id = TipoPersonaDto.Id }, TipoPersona);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoPersonaDto>> Get(int id)
        {
            var TipoPersona = await _unitOfWork.TiposPersona.GetByIdAsync(id);
            return mapper.Map<TipoPersonaDto>(TipoPersona);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoPersonaDto>> Put(int id, [FromBody] TipoPersonaDto TipoPersonaDto)
        {
            if (TipoPersonaDto == null)
                return NotFound();

            var TipoPersona = this.mapper.Map<TipoPersona>(TipoPersonaDto);
            _unitOfWork.TiposPersona.Update(TipoPersona);
            await _unitOfWork.SaveAsync();
            return TipoPersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var TipoPersona = await _unitOfWork.TiposPersona.GetByIdAsync(id);
            if (TipoPersona == null)
                return NotFound();

            _unitOfWork.TiposPersona.Remove(TipoPersona);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}