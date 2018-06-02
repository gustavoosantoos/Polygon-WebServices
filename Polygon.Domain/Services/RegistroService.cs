using System;
using System.Collections.Generic;
using System.Text;
using Polygon.Domain.Entities;
using Polygon.Domain.Interfaces.Repositories;
using Polygon.Domain.Interfaces.Services;
using Polygon.Domain.Interfaces.Services.FuncionarioService;
using Polygon.Domain.Interfaces.Services.RegistroService;

namespace Polygon.Domain.Services
{
    public class RegistroService : IRegistroService
    {
        private readonly IRegistroRepository _repository;

        public RegistroService(IRegistroRepository repository)
        {
            _repository = repository;
        }

        public BaseServiceResponse<Registro> RegistrarPonto(Registro registro)
        {
            try
            {
                _repository.Add(registro);
                return new BaseServiceResponse<Registro>();
            }
            catch (Exception ex)
            {
                var response = new BaseServiceResponse<Registro>("Erro ao salvar registro.");
                return response;
            }
        }
    }
}
