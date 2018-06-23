using Polygon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polygon.WebServices.Requests
{
    public class AdicionarFuncionarioRequest
    {
        public Funcionario Administrador { get; set; }
        public Funcionario NovoFuncionario { get; set; }
    }
}
