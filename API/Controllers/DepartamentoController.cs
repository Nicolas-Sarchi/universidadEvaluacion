using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    public class DepartamentoController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public DepartamentoController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> Get()
        {
            var Departamento = await _unitOfWork.Departamentos.GetAllAsync();
            return mapper.Map<List<DepartamentoDto>>(Departamento);
        }

        [HttpGet("DepartamentosConProfesoresInformatica")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<NomDeptoDto>>> GetDepartamentosConProfesoresInformatica()
        {
            var Departamento = await _unitOfWork.Profesores.DepartamentosConProfesoresInformatica();
            return mapper.Map<List<NomDeptoDto>>(Departamento);
        }
        [HttpGet("sinProfesores")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> sinProfesores()
        {
            var Departamento = await _unitOfWork.Departamentos.ObtenerDepartamentosSinProfesores();
            return mapper.Map<List<DepartamentoDto>>(Departamento);
        }

        [HttpGet("sinMateriasImpartidas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> sinMateriasImpartidas()
        {
            var Departamento = await _unitOfWork.Departamentos.DepartamentosSinAsignaturascurso();
            return mapper.Map<List<DepartamentoDto>>(Departamento);
        }
 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Departamento>> Post(DepartamentoDto DepartamentoDto)
        {
            var Departamento = this.mapper.Map<Departamento>(DepartamentoDto);
            _unitOfWork.Departamentos.Add(Departamento);
            await _unitOfWork.SaveAsync();
 
            if (Departamento == null)
            {
                return BadRequest();
            }
            DepartamentoDto.Id = Departamento.Id;
            return CreatedAtAction(nameof(Post), new { id = DepartamentoDto.Id }, Departamento);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DepartamentoDto>> Get(int id)
        {
            var Departamento = await _unitOfWork.Departamentos.GetByIdAsync(id);
            return mapper.Map<DepartamentoDto>(Departamento);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DepartamentoDto>> Put(int id, [FromBody] DepartamentoDto DepartamentoDto)
        {
            if (DepartamentoDto == null)
                return NotFound();

            var Departamento = this.mapper.Map<Departamento>(DepartamentoDto);
            _unitOfWork.Departamentos.Update(Departamento);
            await _unitOfWork.SaveAsync();
            return DepartamentoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Departamento = await _unitOfWork.Departamentos.GetByIdAsync(id);
            if (Departamento == null)
                return NotFound();

            _unitOfWork.Departamentos.Remove(Departamento);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}