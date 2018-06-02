using System;
using System.Collections.Generic;
using System.Text;
using Polygon.Domain.Entities;

namespace Polygon.Domain.Interfaces.Services.FuncionarioService
{
    public interface IFuncionarioService
    {
        BaseServiceResponse<Funcionario> AdicionarFuncionario(Funcionario funcionario);
        BaseServiceResponse<Funcionario> BuscarPorMatriculaESenha(Funcionario funcionario);
        BaseServiceResponse<Funcionario> BuscarPorMatricula(int matricula);
        BaseServiceResponse<bool> FuncionarioEhAdministrador(Funcionario funcionario);
    }
}
