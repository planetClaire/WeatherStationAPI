using System.Linq;
using System.Net;
using System.Net.Http;
using WeatherStationDataModel;

namespace WeatherStationAPI.Controllers
{
    public class SensorsController : BaseApiController
    {
        public SensorsController(IWeatherStationRepository repo) : base(repo)
        {
        }

        public HttpResponseMessage Get()
        {
            var sensors = TheRepository.GetSensors();
            if (sensors != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, sensors
                    .OrderBy(s => s.Name)
                    .ToList()
                    .Select(s => TheModelFactory.CreateSensorModel(s)));
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage Get(int sensorid)
        {
            var sensor = TheRepository.GetSensor(sensorid);
            if (sensor != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                    TheModelFactory.CreateSensorModel(sensor));
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}