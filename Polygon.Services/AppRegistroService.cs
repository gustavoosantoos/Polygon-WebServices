using System;
using System.Collections.Generic;
using System.Text;
using Polygon.Domain.Entities;
using Polygon.Domain.Interfaces.Services;
using Polygon.Domain.Interfaces.Services.FuncionarioService;
using Polygon.Domain.Interfaces.Services.RegistroService;
using Polygon.Domain.Shared.Enumerations;

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

        public BaseServiceResponse<Registro[]> FindRegistrosByMatricula(int matricula, Mes mes)
        {
            var funcionarioResponse = _funcionarioService.BuscarPorMatricula(matricula);
            if (funcionarioResponse.Sucesso)
                return _service.RegistrosByMatricula(matricula, mes);

            return new BaseServiceResponse<Registro[]>(funcionarioResponse.Mensagens);
        }
    }
}
