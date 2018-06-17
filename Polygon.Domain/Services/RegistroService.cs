using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Polygon.Domain.Entities;
using Polygon.Domain.Interfaces.Repositories;
using Polygon.Domain.Interfaces.Services;
using Polygon.Domain.Interfaces.Services.FuncionarioService;
using Polygon.Domain.Interfaces.Services.RegistroService;
using Polygon.Domain.Shared.Enumerations;

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

        public BaseServiceResponse<Registro[]> RegistrosByMatricula(int matricula, Mes mes)
        {
            try
            {
                Registro[] registros = _repository.FindRegistrosByMatricula(matricula, mes).ToArray();
                return new BaseServiceResponse<Registro[]>(registros);
            }
            catch (Exception ex)
            {
                return new BaseServiceResponse<Registro[]>("Erro ao buscar registros.");
            }
        }
    }
}
