using Polygon.Domain.Entities;

namespace Polygon.Domain.Interfaces.Services.RegistroService
{
    public interface IRegistroService
    {
        BaseServiceResponse<Registro> RegistrarPonto(Registro registro);
    }
}
