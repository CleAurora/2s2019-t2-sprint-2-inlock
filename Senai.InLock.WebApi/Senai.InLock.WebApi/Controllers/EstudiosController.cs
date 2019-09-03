using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        EstudioRepository EstudioRepository = new EstudioRepository();


        //Lista os estúdios
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(EstudioRepository.Listar());
        }

        //Cadastra um novo estúdio
        [HttpPost]
        public IActionResult Cadastrar(Estudios estudio)
        {
            try
            {
                EstudioRepository.Cadastrar(estudio);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { mensagem = "Oops... Tem erro aqui..." + ex.Message });
            }
        }

        //Busca um estúdio da lista
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(EstudioRepository.BuscarPorId(id));
        }

        //Atualiza um estúdio da lista
        [HttpPut("{id}")]
        public IActionResult Atualizar(Estudios estudio, int id)
        {
            EstudioRepository.Atualizar(estudio, id);
            return Ok();
        }

        //Deleta um estúdio da lista
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            EstudioRepository.Deletar(id);
            return Ok();
        }
    }
}