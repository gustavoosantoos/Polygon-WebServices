using Polygon.Domain.Entities;
using Polygon.Domain.Shared.Enumerations;

namespace Polygon.Domain.Interfaces.Services.RegistroService
{
    public interface IRegistroService
    {
        BaseServiceResponse<Registro> RegistrarPonto(Registro registro);
        BaseServiceResponse<Registro[]> RegistrosByMatricula(int matricula, Mes mes);
    }
}
