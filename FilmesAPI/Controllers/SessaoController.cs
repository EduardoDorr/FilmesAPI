using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Domain.Models;

namespace SessoesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public SessaoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona uma sessão ao banco de dados
        /// </summary>
        /// <param name="sessaoDto">Objeto com os campos necessários para criação de uma sessão</param>
        /// <returns>IActionresult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            var sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { id = sessao.Id }, sessaoDto);
        }

        /// <summary>
        /// Recupera todos as sessões do banco de dados
        /// </summary>
        /// <returns>IActionresult</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        public IEnumerable<ReadSessaoDto> RecuperaSessoes()
        {
            return _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            var sessao = _context.Sessoes.FirstOrDefault(f => f.Id == id);

            if (sessao == null)
                return NotFound();

            var sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

            return Ok(sessaoDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaSessao(int id, [FromBody] UpdateSessaoDto sessaoDto)
        {
            var sessao = _context.Sessoes.FirstOrDefault(f => f.Id == id);

            if (sessao == null)
                return NotFound();

            _mapper.Map(sessaoDto, sessao);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult AtualizaSessaoParcial(int id, JsonPatchDocument<UpdateSessaoDto> patch)
        {
            var sessao = _context.Sessoes.FirstOrDefault(f => f.Id == id);

            if (sessao == null)
                return NotFound();

            var sessaoToUpdate = _mapper.Map<UpdateSessaoDto>(sessao);
            patch.ApplyTo(sessaoToUpdate, ModelState);

            if (!TryValidateModel(sessaoToUpdate))
                return ValidationProblem(ModelState);

            _mapper.Map(sessaoToUpdate, sessao);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaSessao(int id)
        {
            var sessao = _context.Sessoes.FirstOrDefault(f => f.Id == id);

            if (sessao == null)
                return NotFound();

            _context.Remove(sessao);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
