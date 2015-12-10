using System.Collections.Generic;
using System.Linq;
using WeatherStationAPI.Models;
using WeatherStationDataModel;

namespace WeatherStationAPI.Controllers
{
    public class SensorsController : BaseApiController
    {
        public SensorsController(IWeatherStationRepository repo) : base(repo)
        {
        }

        public IEnumerable<SensorModel> Get()
        {
            return TheRepository.GetAllSensors()
                .OrderBy(s => s.Name)
                .ToList()
                .Select(s => TheModelFactory.CreateSensorModel(s));
        }

        public SensorModel Get(int id)
        {
            return TheModelFactory.CreateSensorModel(TheRepository.GetSensor(id));
        }
    }
}