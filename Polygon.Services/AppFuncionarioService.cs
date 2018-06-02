using System;
using System.Collections.Generic;
using System.Text;
using Polygon.Domain.Entities;
using Polygon.Domain.Interfaces.Services;
using Polygon.Domain.Interfaces.Services.FuncionarioService;

namespace Polygon.Services
{
    public class AppFuncionarioService
    {
        private readonly IFuncionarioService _service;

        public AppFuncionarioService(IFuncionarioService service)
        {
            _service = service;
        }

        public BaseServiceResponse<Funcionario> CriarFuncionario(Funcionario administrador, Funcionario novoFuncionario)
        {
            var isAdmin = _service.FuncionarioEhAdministrador(administrador);
            if (isAdmin.Sucesso)
            {
                var adicaoResponse = _service.AdicionarFuncionario(novoFuncionario);
                if (adicaoResponse.Sucesso)
                {
                    return new BaseServiceResponse<Funcionario>(novoFuncionario);
                }

                return new BaseServiceResponse<Funcionario>(adicaoResponse.Mensagens);
            }

            return new BaseServiceResponse<Funcionario>("O funcionário passado como administrador não possui as permissões necessárias.");
        }

    }
}
