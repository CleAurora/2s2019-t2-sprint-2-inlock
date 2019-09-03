using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Lista os Jogos
        /// </summary>
        /// <returns>Lista de Jogos</returns>
        [Authorize]
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(jogoRepository.Listar());
        }

        /// <summary>
        /// Cadastra Novo Jogo
        /// </summary>
        /// <param name="jogo"></param>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar (Jogos jogo)
        {
            jogoRepository.Cadastrar(jogo);
            return Ok();
        }

        /// <summary>
        /// Busca um Jogo por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Jogo</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(jogoRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Atualiza Jogo na Lista
        /// </summary>
        /// <param name="jogo"></param>
        /// <param name="id"></param>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(Jogos jogo, int id)
        {
            jogoRepository.Atualizar(jogo, id);
            return Ok();
        }

        /// <summary>
        /// Deleta Jogo na Lista
        /// </summary>
        /// <param name="id"></param>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            jogoRepository.Deletar(id);
            return Ok();
        }
    }
}