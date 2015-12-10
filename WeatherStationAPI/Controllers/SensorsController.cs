using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WeatherStationAPI.Models;
using WeatherStationDataModel;

namespace WeatherStationAPI.Controllers
{
    public class SensorsController : ApiController
    {
        private readonly IWeatherStationRepository _repo;
        private readonly ModelFactory _modelFactory;

        public SensorsController(IWeatherStationRepository repo)
        {
            _repo = repo;
            _modelFactory = new ModelFactory();
        }

        public IEnumerable<SensorModel> Get()
        {
            return _repo.GetAllSensors()
                .OrderBy(s => s.Name)
                .ToList()
                .Select(s => _modelFactory.CreateSensorModel(s));
        }

        public SensorModel Get(int id)
        {
            return _modelFactory.CreateSensorModel(_repo.GetSensor(id));
        }
    }
}