using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")] //controller é uma referencia para o nome da sua API.
  public class ProfessorController : ControllerBase
  {
    public ProfessorController() { }

    [HttpGet]
    public IActionResult Get()
    {
      return Ok("Professores: Marta, Lucas, Paulo");
    }
  }
}