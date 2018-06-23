using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polygon.Domain.Entities;
using Polygon.Domain.Interfaces.Services.FuncionarioService;
using Polygon.Services;
using Polygon.WebServices.Requests;

namespace Polygon.WebServices.Controllers
{
    [Produces("application/json")]
    [Route("api/Funcionarios")]
    public class FuncionariosController : Controller
    {
        private readonly AppFuncionarioService _service;

        public FuncionariosController(AppFuncionarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CriarFuncionario([FromBody] AdicionarFuncionarioRequest request)
        {
            var criacaoResponse = _service.CriarFuncionario(request.Administrador, request.NovoFuncionario);
            if (criacaoResponse.Sucesso)
                return Ok(criacaoResponse);

            return BadRequest(criacaoResponse.Mensagens);
        }
    }
}