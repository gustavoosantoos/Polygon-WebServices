using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Polygon.Data.Factory;
using Polygon.Domain.Entities;
using Polygon.Domain.Interfaces.Repositories;

namespace Polygon.Data.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        public void Add(Funcionario funcionario)
        {
            var query = "insert into funcionarios values (@Matricula, @Senha, @Administrador, @Ativo)";

            using (var connection = ConnectionFactory.GetConnection())
            {
                connection.Execute(query, funcionario);
            }
        }

        public void Update(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public void List()
        {
            var query = "select * from funcionarios";
            using (var connection = ConnectionFactory.GetConnection())
            {
                connection.Query<Funcionario>(query);
            }
        }

        public void Remove(int matricula)
        {
            var query = "update funcionarios set ativo = false where matricula = @Matricula";
            using (var connecion = ConnectionFactory.GetConnection())
            {
                connecion.Execute(query, new { Matricula = matricula });
            }
        }

        public Funcionario FindByMatricula(int matricula)
        {
            var query = "select * from funcionarios where matricula = @Matricula";
            using (var connection = ConnectionFactory.GetConnection())
            {
                return connection.Query<Funcionario>(query, new { Matricula = matricula }).FirstOrDefault();
            }
        }
    }
}
