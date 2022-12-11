﻿using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class FilmeController : ControllerBase
  {
    private static List<Filme> _filmes = new List<Filme>();
    private static int _id = 0;

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] Filme filme)
    {
      filme.Id = _id++;
      _filmes.Add(filme);
      
      return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery]int skip = 0, [FromQuery]int take = 50)
    {
      return _filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
      var filme = _filmes.FirstOrDefault(f => f.Id == id);

      return filme == null ? NotFound() : Ok(filme);
    }
  }
}
