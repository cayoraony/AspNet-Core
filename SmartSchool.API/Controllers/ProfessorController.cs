using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        public List<Professor> Professores = new List<Professor>()
        {
            new Professor()
            {
                Id = 1,
                Nome = "Jão",
                Sobrenome = "AAAA"
            },
            new Professor()
            {
                Id = 2,
                Nome = "Cayo",
                Sobrenome = "BBBB"
            },
            new Professor()
            {
                Id = 3,
                Nome = "Derek",
                Sobrenome = "DDDD"
            },
        };

        public ProfessorController() { }
        [HttpGet]
        public IActionResult Get() { return Ok(Professores); }
        //api/professor/byId/1
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id) {
            var professor = Professores.FirstOrDefault(p => p.Id == id);
            if (professor == null) return BadRequest("Professor não encontrado");
            return Ok(professor);
        }

        //api/professor/byId/1
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var professor = Professores.FirstOrDefault(
                p => p.Nome.Contains(nome) && p.Sobrenome.Contains(sobrenome));
            if (professor == null) return BadRequest("Professor não encontrado");
            return Ok(professor);
        }
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            return Ok(professor);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
