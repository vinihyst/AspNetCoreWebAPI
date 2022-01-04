using SmartSchool.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SmartSchool.API.Data;
using Microsoft.EntityFrameworkCore;

namespace SmartSchool.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")] //controller é uma referencia para o nome da sua API.
  public class AlunoController : ControllerBase
  {
    private readonly SmartContext _context;

    public AlunoController(SmartContext context)
    {
      _context = context;

    }

    [HttpGet]
    public IActionResult Get()
    {
      return Ok(_context.Alunos);
    }

    [HttpGet("byId")]
    public IActionResult GetById(int id)
    {
      var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
      if (aluno == null) return BadRequest("O aluno não foi encontrado");

      return Ok(aluno);
    }

    [HttpGet("byName")]
    public IActionResult GetByName(string name, string surname)
    {
      var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(name) && a.Sobrenome.Contains(surname)
      );
      if (aluno == null) return BadRequest("O aluno não foi encontrado");

      return Ok(aluno);
    }

    [HttpPost]
    public IActionResult Post(Aluno aluno)
    {
      _context.Add(aluno);
      _context.SaveChanges();
      return Ok(aluno);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Aluno aluno)
    {
      var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);

      if (alu == null)
      {
        return BadRequest("Aluno não encontrado.");
      }

      _context.Update(aluno);
      _context.SaveChanges();
      return Ok(aluno);
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, Aluno aluno)
    {
      var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);

      if (alu == null)
      {
        return BadRequest("Aluno não encontrado.");
      }

      _context.Update(aluno);
      _context.SaveChanges();
      return Ok(aluno);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

      if (aluno == null)
      {
        return BadRequest("Aluno não encontrado.");
      }

      _context.Remove(aluno);
      _context.SaveChanges();
      return Ok();
    }
  }
}