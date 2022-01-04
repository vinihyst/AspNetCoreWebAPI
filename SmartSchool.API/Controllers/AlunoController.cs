using SmartSchool.API.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SmartSchool.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")] //controller é uma referencia para o nome da sua API.
  public class AlunoController : ControllerBase
  {
    public List<Aluno> Alunos = new List<Aluno>(){
      new Aluno(){
        Id = 1,
        Nome = "Marcos",
        Sobrenome = "Túlio",
        Telefone = "1231547"
      },
      new Aluno(){
        Id = 2,
        Nome = "Marta",
        Sobrenome = "Futebolista",
        Telefone = "1535347"
      },
      new Aluno(){
        Id = 3,
        Nome = "Lucas",
        Sobrenome = "Ferreira",
        Telefone = "1234567"
      },
    };
    public AlunoController() { }

    [HttpGet]
    public IActionResult Get()
    {
      return Ok(Alunos);
    }

    [HttpGet("byId")]
    public IActionResult GetById(int id)
    {
      var aluno = Alunos.FirstOrDefault(a => a.Id == id);
      if (aluno == null) return BadRequest("O aluno não foi encontrado");

      return Ok(aluno);
    }

    [HttpGet("byName")]
    public IActionResult GetByName(string name, string surname)
    {
      var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(name) && a.Sobrenome.Contains(surname)
      );
      if (aluno == null) return BadRequest("O aluno não foi encontrado");

      return Ok(aluno);
    }

    [HttpPost]
    public IActionResult Post(Aluno aluno)
    {
      return Ok(aluno);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Aluno aluno)
    {
      return Ok(aluno);
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, Aluno aluno)
    {
      return Ok(aluno);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      return Ok();
    }
  }
}