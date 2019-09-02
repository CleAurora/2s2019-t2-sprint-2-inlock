using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        JogoRepository jogoRepository = new JogoRepository();
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(jogoRepository.Listar());
        }
    }
}