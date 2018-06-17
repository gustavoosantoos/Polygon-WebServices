using System;
using System.Collections.Generic;
using System.Text;

namespace Polygon.Domain.Entities
{
    public class Funcionario : BaseEntity
    {
        public int Matricula { get; set; }
        public string Senha { get; set; }
        public bool Administrador { get; set; }
        public bool Ativo { get; set; }

        public Funcionario() { }

        public Funcionario(int matricula, string senha)
        {
            Matricula = matricula;
            Senha = senha;

            if (matricula < 0)
                AddNotification("Matrícula inválida.");
            if (string.IsNullOrWhiteSpace(senha))
                AddNotification("Senha em branco.");
            if (senha?.Length < 6) 
                AddNotification("Senha deve ter ao menos 6 caracteres.");
        }
    }
}
