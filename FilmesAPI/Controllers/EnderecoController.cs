using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Domain.Models;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public EnderecoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona um endereço ao banco de dados
        /// </summary>
        /// <param name="enderecoDto">Objeto com os campos necessários para criação de um endereço</param>
        /// <returns>IActionresult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { id = endereco.Id }, enderecoDto);
        }

        /// <summary>
        /// Recupera todos os endereços do banco de dados
        /// </summary>
        /// <returns>IActionresult</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        public IEnumerable<ReadEnderecoDto> RecuperaEnderecos()
        {
            return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(c => c.Id == id);

            if (endereco == null)
                return NotFound();

            var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

            return Ok(enderecoDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            var endereco = _context.Enderecos.FirstOrDefault(c => c.Id == id);

            if (endereco == null)
                return NotFound();

            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult AtualizaEnderecoParcial(int id, JsonPatchDocument<UpdateEnderecoDto> patch)
        {
            var endereco = _context.Enderecos.FirstOrDefault(c => c.Id == id);

            if (endereco == null)
                return NotFound();

            var enderecoToUpdate = _mapper.Map<UpdateEnderecoDto>(endereco);
            patch.ApplyTo(enderecoToUpdate, ModelState);

            if (!TryValidateModel(enderecoToUpdate))
                return ValidationProblem(ModelState);

            _mapper.Map(enderecoToUpdate, endereco);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(c => c.Id == id);

            if (endereco == null)
                return NotFound();

            _context.Remove(endereco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
