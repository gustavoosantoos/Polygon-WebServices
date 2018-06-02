using System;
using System.Collections.Generic;
using System.Text;
using Polygon.Domain.Entities;

namespace Polygon.Domain.Interfaces.Repositories
{
    public interface IFuncionarioRepository
    {
        void Add(Funcionario funcionario);
        void Update(Funcionario funcionario);
        void List();
        void Remove(int matricula);
        Funcionario FindByMatricula(int matricula);
    }
}
