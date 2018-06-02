using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polygon.Domain.Interfaces.Services
{
    public class BaseServiceResponse<T>
    {
        public bool Sucesso => Mensagens.Count == 0;
        public List<string> Mensagens { get; }
        public T Response { get; set; }


        public BaseServiceResponse()
        {
            Mensagens = new List<string>();
        }

        public BaseServiceResponse(T response) : this()
        {
            Response = response;
        }


        public BaseServiceResponse(params string[] messages) : this()
        {
            Mensagens = messages.ToList();
        }

        public BaseServiceResponse(IEnumerable<string> messages) : this(messages.ToArray())
        {

        }


        public void AddMensagem(string mensagem) =>
            Mensagens.Add(mensagem);

        public void AddMensagens(params string[] mensagens) =>
            Mensagens.AddRange(mensagens);
    }
}
