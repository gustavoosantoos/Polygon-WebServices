using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Polygon.Domain.Entities;
using Polygon.Domain.Interfaces.Repositories;
using Polygon.Domain.Interfaces.Services;
using Polygon.Domain.Interfaces.Services.FuncionarioService;

namespace Polygon.Domain.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _repository;

        public FuncionarioService(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        public BaseServiceResponse<Funcionario> AdicionarFuncionario(Funcionario funcionario)
        {
            try
            {
                _repository.Add(funcionario);
                return new BaseServiceResponse<Funcionario>(funcionario);
            }
            catch (Exception ex)
            {
                return new BaseServiceResponse<Funcionario>("Erro ao adicionar funcionário.");
            }
        }

        public BaseServiceResponse<Funcionario> BuscarPorMatriculaESenha(Funcionario funcionario)
        {
            try
            {
                var funcionarioFromRepository = _repository.FindByMatricula(funcionario.Matricula);
                if (funcionarioFromRepository.Senha == funcionario.Senha)
                    return new BaseServiceResponse<Funcionario>(funcionario);

                return new BaseServiceResponse<Funcionario>("Funcionário não encontrado.");
            }
            catch (Exception ex)
            {
                return new BaseServiceResponse<Funcionario>("Erro ao buscar funcionário.");
            }
        }

        public BaseServiceResponse<Funcionario> BuscarPorMatricula(int matricula)
        {
            try
            {
                var funcionarioFromRepository = _repository.FindByMatricula(matricula);
                if (funcionarioFromRepository == null)
                    return new BaseServiceResponse<Funcionario>("Funcionário não encontrado.");
                
                return new BaseServiceResponse<Funcionario>(funcionarioFromRepository);
            }
            catch (Exception ex)
            {
                return new BaseServiceResponse<Funcionario>("Erro ao buscar funcionário.");
            }
        }

        public BaseServiceResponse<bool> FuncionarioEhAdministrador(Funcionario funcionario)
        {
            var serviceResponse = this.BuscarPorMatriculaESenha(funcionario);
            if (serviceResponse.Sucesso)
                return new BaseServiceResponse<bool>(true);

            return new BaseServiceResponse<bool>(serviceResponse.Mensagens);
        }
    }
}
