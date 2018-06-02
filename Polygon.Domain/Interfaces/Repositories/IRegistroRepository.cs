using System;
using System.Collections.Generic;
using System.Text;
using Polygon.Domain.Entities;

namespace Polygon.Domain.Interfaces.Repositories
{
    public interface IRegistroRepository
    {
        void Add(Registro registro);
        IEnumerable<Registro> List(int matricula);
    }
}
