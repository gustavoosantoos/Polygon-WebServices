using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polygon.Domain.Entities;
using Polygon.Services;

namespace Polygon.WebServices.Controllers
{
    [Produces("application/json")]
    [Route("api/Registros")]
    [EnableCors("MyPolicy")]
    public class RegistroPontoController : Controller
    {
        private readonly AppRegistroService _service;

        public RegistroPontoController(AppRegistroService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult RegistrarPonto([FromBody] Registro registro)
        {
            var registroResponse = _service.RegistrarPonto(registro);
            if (registroResponse.Sucesso)
                return Ok();

            return BadRequest(registroResponse.Mensagens); 
        }
    }
}