using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    public class SexoController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public SexoController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<SexoDto>>> Get()
        {
            var Sexo = await _unitOfWork.Sexos.GetAllAsync();
            return mapper.Map<List<SexoDto>>(Sexo);
        }
 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Sexo>> Post(SexoDto SexoDto)
        {
            var Sexo = this.mapper.Map<Sexo>(SexoDto);
            _unitOfWork.Sexos.Add(Sexo);
            await _unitOfWork.SaveAsync();
 
            if (Sexo == null)
            {
                return BadRequest();
            }
            SexoDto.Id = Sexo.Id;
            return CreatedAtAction(nameof(Post), new { id = SexoDto.Id }, Sexo);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SexoDto>> Get(int id)
        {
            var Sexo = await _unitOfWork.Sexos.GetByIdAsync(id);
            return mapper.Map<SexoDto>(Sexo);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SexoDto>> Put(int id, [FromBody] SexoDto SexoDto)
        {
            if (SexoDto == null)
                return NotFound();

            var Sexo = this.mapper.Map<Sexo>(SexoDto);
            _unitOfWork.Sexos.Update(Sexo);
            await _unitOfWork.SaveAsync();
            return SexoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Sexo = await _unitOfWork.Sexos.GetByIdAsync(id);
            if (Sexo == null)
                return NotFound();

            _unitOfWork.Sexos.Remove(Sexo);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}