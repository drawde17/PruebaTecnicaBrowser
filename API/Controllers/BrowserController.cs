using API.Utils;
using Domain.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Service.DTO;
using Service.Interfaces;

namespace API.Controllers
{
    [Route("[controller]/[action]")]
    public class BrowserController : ControllerBase
    {
        private readonly MyConfig _config;
        private readonly ILogger<BrowserController> _logger;
        private readonly IBrowserService _browserService;

        public BrowserController(ILogger<BrowserController> logger, IOptions<MyConfig> options, BrowserContext context, IBrowserService browserService)
        {
            _logger = logger;
            _config = options.Value;
            _browserService = browserService;
            _browserService.SetContext(context);
        }

        [HttpGet]
        public ResponseDTO<IEnumerable<Car>> DispomiblesXLocalidad(int IdLocalidad)
        {
            return _browserService.DispomiblesXLocalidad(IdLocalidad);
        }

        [HttpPost]
        public ResponseDTO<bool> RecogerCar(int IdCar, int IdLocalidad)
        {
            return _browserService.RecogerCar(IdCar, IdLocalidad);
        }

        [HttpPost]
        public ResponseDTO<bool> DevolverCar(int IdCar, int IdLocalidad)
        {
            return _browserService.DevolverCar(IdCar, IdLocalidad);
        }
    }
}
