using Domain.Models;
using Infrastructure;
using Infrastructure.Interfaces;
using Infrastructure.Repository;
using Service.DTO;
using Service.Interfaces;

namespace Service.Service
{
    public class BrowserService : IBrowserService
    {
        private BrowserContext _context;
        public void SetContext(BrowserContext context) => _context = context;
        public ResponseDTO<IEnumerable<Car>> DispomiblesXLocalidad(int IdLocalidad)
        {
            try
            {
                var repositoryCarStatus = new Repository<CarStatus>(_context);
                var repositoryCar = new Repository<Car>(_context);

                var carStatus = repositoryCarStatus.Get().Where(w => w.IdLocalidadRecogida == IdLocalidad && w.Status == true && w.IdCarService == 1);

                if(!carStatus.Any())
                    return new ResponseDTO<IEnumerable<Car>> { Status = false};

                var cars = repositoryCar.Get().Where(w => carStatus.Any(a => a.IdCar == w.IdCar));

                return new ResponseDTO<IEnumerable<Car>>()
                {
                    Status = true,
                    Data = cars
                };
            }
            catch (Exception)
            {
                return new ResponseDTO<IEnumerable<Car>>()
                {
                    Status = false
                };
            } 
        }

        public ResponseDTO<bool> RecogerCar(int IdCar, int IdLocalidad)
        {
            try
            {
                var repositoryCarStatus = new Repository<CarStatus>(_context);

                var carToUpdate = repositoryCarStatus.Get().Where(w => w.IdCar == IdCar && w.Status == true && w.IdCarService == 1).FirstOrDefault();

                if (carToUpdate == null)
                    return new ResponseDTO<bool> { Status = false, Data = false };


                carToUpdate.IdLocalidadRecogida = IdLocalidad;
                carToUpdate.IdCarService = 2;
                repositoryCarStatus.Update(carToUpdate);
                repositoryCarStatus.Save();
                return new ResponseDTO<bool> { Status = true, Data = true };
            }
            catch (Exception)
            {
                return new ResponseDTO<bool> { Status = false, Data = false };
            }
            
        }

        public ResponseDTO<bool> DevolverCar(int IdCar, int IdLocalidad)
        {
            try
            {
                var repositoryCarStatus = new Repository<CarStatus>(_context);

                var carToUpdate = repositoryCarStatus.Get().Where(w => w.IdCar == IdCar && w.Status == true && (w.IdCarService == 1 || w.IdCarService == 2)).FirstOrDefault();

                if (carToUpdate == null)
                    return new ResponseDTO<bool> { Status = false, Data = false };


                carToUpdate.IdLocalidadDevolucion= IdLocalidad;
                repositoryCarStatus.Update(carToUpdate);
                repositoryCarStatus.Save();
                return new ResponseDTO<bool> { Status = true, Data = true };
            }
            catch (Exception)
            {
                return new ResponseDTO<bool> { Status = false, Data = false };
            }
        }
    }
}
