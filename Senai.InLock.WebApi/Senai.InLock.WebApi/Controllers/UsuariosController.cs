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
    public class UsuariosController : ControllerBase
    {
        UsuarioRepository usuarioRepository = new UsuarioRepository();


        //Lista os usuários
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(usuarioRepository.Listar());
        }
        
        //Cadastra um novo usuário
        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            usuarioRepository.Cadastrar(usuario);
            return Ok();
        }
        
        //Atualiza um usuário da lista
        [HttpPut("{id}")]
        public IActionResult Atualizar (Usuarios usuario, int id)
        {
            usuarioRepository.Atualizar(usuario, id);
            return Ok();
        }

        //Deleta um usuário da lista
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            usuarioRepository.Deletar(id);
            return Ok();
        }

        //Busca um usuário da lista pelo id
        [HttpGet("{id}")]
        public IActionResult BuscarPorId (int id)
        {
            return Ok(usuarioRepository.BuscarPorId(id));
        }
    }
}