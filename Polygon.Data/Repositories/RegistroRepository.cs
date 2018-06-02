using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MySql.Data.MySqlClient;
using Polygon.Data.Factory;
using Polygon.Domain.Entities;
using Polygon.Domain.Interfaces.Repositories;

namespace Polygon.Data.Repositories
{
    public class RegistroRepository : IRegistroRepository
    {
        
        public void Add(Registro registro)
        {
            var query = @"insert into registros (MatriculaFuncionario, DataHora, Latitude, Longitude)
                            values (@Matricula, @DataHora, @Latitude, @Longitude)";

            using (var connection = ConnectionFactory.GetConnection())
            {
                connection.Execute(query, new
                {
                    Matricula = registro.Funcionario.Matricula,
                    DataHora = DateTime.Now,
                    Latitude = registro.Latitude,
                    Longitude = registro.Longitude
                });
            }
        }

        public IEnumerable<Registro> List(int matricula)
        {
            var query = "select * from registros where MatriculaFuncionario = @Matricula";

            using (var connection = ConnectionFactory.GetConnection())
            {
                return connection.Query<Registro>(query);
            }
        }
    }
}
