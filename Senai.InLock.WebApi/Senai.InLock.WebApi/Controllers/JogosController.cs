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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        JogoRepository jogoRepository = new JogoRepository();

        //Lista os jogos
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(jogoRepository.Listar());
        }

        //Cadastra um novo jogo na lista
        [HttpPost]
        public IActionResult Cadastrar (Jogos jogo)
        {
            jogoRepository.Cadastrar(jogo);
            return Ok();
        }

        //Busca um jogo na lista
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(jogoRepository.BuscarPorId(id));
        }

        //Atualiza um jogo da lista
        [HttpPut("{id}")]
        public IActionResult Atualizar(Jogos jogo, int id)
        {
            jogoRepository.Atualizar(jogo, id);
            return Ok();
        }

        //Deleta um jogo da lista
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            jogoRepository.Deletar(id);
            return Ok();
        }
    }
}