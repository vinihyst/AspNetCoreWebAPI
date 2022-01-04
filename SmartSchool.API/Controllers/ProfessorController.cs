using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")] //controller é uma referencia para o nome da sua API.
  public class ProfessorController : ControllerBase
  {
    private readonly SmartContext _context;

    public ProfessorController(SmartContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Ok(_context.Professores);
    }

    [HttpGet("byName")]
    public IActionResult byName(string name, string surname)
    {
      var prof = _context.Professores.FirstOrDefault(a => a.Nome.Contains(name));

      if (prof == null)
      {
        return BadRequest("Professor não ecnontrado.");
      }
      return Ok(prof);
    }

    [HttpGet("byId")]
    public IActionResult byId(int id)
    {
      var prof = _context.Professores.FirstOrDefault(a => a.Id == id);

      if (prof == null)
      {
        return BadRequest("Professor não ecnontrado");
      }
      return Ok(prof);
    }

    [HttpPost]
    public IActionResult Post(Professor professor)
    {
      _context.Add(professor);
      _context.SaveChanges();
      return Ok(professor);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Professor professor)
    {
      var prof = _context.Professores.AsNoTracking().FirstOrDefault(e => e.Id == id);

      if (prof == null)
      {
        return BadRequest("Professor não encontrado");
      }
      _context.Update(professor);
      _context.SaveChanges();
      return Ok(professor);
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, Professor professor)
    {
      var prof = _context.Professores.AsNoTracking().FirstOrDefault(e => e.Id == id);

      if (prof == null)
      {
        return BadRequest("Professor não encontrado");
      }
      _context.Update(professor);
      _context.SaveChanges();
      return Ok(professor);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var prof = _context.Professores.FirstOrDefault(e => e.Id == id);

      if (prof == null)
      {
        return BadRequest("Professor não encontrado");
      }
      _context.Remove(prof);
      _context.SaveChanges();
      return Ok();
    }
  }
}