using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Dtos;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        
        private readonly IRepository _repo;
        public readonly IMapper _mapper;
        public AlunoController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repo.GetAllAlunos(true);

            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }



        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAllAlunosByDisciplinaId(id, false);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }




        // POST api/<AlunoController>
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges()) { return Ok(aluno); }
            return BadRequest("Não deu certo.");
        }




        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno não encontrado");
            _repo.Update(aluno);
            if (_repo.SaveChanges()) { return Ok(aluno); }
            return BadRequest("Não deu certo.");
        }




        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno não encontrado");
            _repo.Update(aluno);
            if (_repo.SaveChanges()) { return Ok(aluno); }
            return BadRequest("Não deu certo.");
        }



        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _repo.Delete(aluno);
            if (_repo.SaveChanges()) { return Ok("Aluno deletado"); }
            return BadRequest("Não deu para deletar.");
        }
    }
}
