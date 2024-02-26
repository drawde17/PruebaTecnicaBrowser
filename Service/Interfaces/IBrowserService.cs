using Domain.Models;
using Infrastructure;
using Service.DTO;

namespace Service.Interfaces
{
    public interface IBrowserService
    {
        void SetContext(BrowserContext context);
        ResponseDTO<bool> RecogerCar(int IdCar, int IdLocalidad);
        ResponseDTO<bool> DevolverCar(int IdCar, int IdLocalidad);

        ResponseDTO<IEnumerable<Car>> DispomiblesXLocalidad(int IdLocalidad);
    }
}
