using System;
using System.Collections.Generic;
using System.Text;

namespace Polygon.Domain.Entities
{
    public class Registro : BaseEntity
    {
        public Funcionario Funcionario { get; set; }
        public DateTime DataHora { get; set; }
        public float? Longitude { get; set; }
        public float? Latitude { get; set; }

        protected Registro() { }

        public Registro(Funcionario funcionario)
        {
            Funcionario = funcionario;
            DataHora = DateTime.Now;

            ValidarFuncionario();
        }
        
        public Registro(Funcionario funcionario, float longitude, float latitude)
        {
            Funcionario = funcionario;
            DataHora = DateTime.Now;

            Longitude = longitude;
            Latitude = latitude;

            if (Longitude < -180 || Longitude > 180) 
                AddNotification("A longitude deve ser entre -180 e 180.");
            if (Latitude < -90 || Latitude > 90)
                AddNotification("A latitude deve ser entre -90 e 90.");

            ValidarFuncionario();
        }

        private void ValidarFuncionario()
        {
            if (!Funcionario.IsValid())
                AddNotifications(Funcionario.Notifications.ToArray());
        }
    }
}
