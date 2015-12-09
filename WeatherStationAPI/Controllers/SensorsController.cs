using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WeatherStationDataModel;
using WeatherStationDataModel.Entities;

namespace WeatherStationAPI.Controllers
{
    public class SensorsController : ApiController
    {
        private IWeatherStationRepository _repo;

        public SensorsController(IWeatherStationRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Sensor> Get()
        {
            return _repo.GetAllSensors()
                .OrderBy(s => s.Name)
                .ToList();
        }
    }
}