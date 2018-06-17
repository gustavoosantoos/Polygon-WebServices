using System;
using System.Collections.Generic;
using System.Text;
using Polygon.Domain.Entities;
using Polygon.Domain.Shared.Enumerations;

namespace Polygon.Domain.Interfaces.Repositories
{
    public interface IRegistroRepository
    {
        void Add(Registro registro);

        IEnumerable<Registro> List(int matricula);

        IEnumerable<Registro> FindRegistrosByMatricula(int matricula, Mes mes);
    }
}
