using System;
using System.Collections.Generic;
using System.Text;
using Polygon.Domain.Entities;
using Polygon.Domain.Interfaces.Services;
using Polygon.Domain.Interfaces.Services.FuncionarioService;
using Polygon.Domain.Interfaces.Services.RegistroService;

namespace Polygon.Services
{
    public class AppRegistroService
    {
        private readonly IRegistroService _service;
        private readonly IFuncionarioService _funcionarioService;

        public AppRegistroService(IRegistroService service, IFuncionarioService funcionarioService)
        {
            _service = service;
            _funcionarioService = funcionarioService;
        }

        public BaseServiceResponse<Registro> RegistrarPonto(Registro registro)
        {
            var funcionarioResponse = _funcionarioService.BuscarPorMatriculaESenha(registro.Funcionario);
            if (funcionarioResponse.Sucesso)
                return _service.RegistrarPonto(registro);
            
            return new BaseServiceResponse<Registro>(funcionarioResponse.Mensagens);
        }
    }
}
