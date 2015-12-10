using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using WeatherStationAPI.Models;
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
                return Request.CreateResponse(HttpStatusCode.OK, sensors.ToList().Select(s => TheModelFactory.Create(s)));
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage Get(int sensorid)
        {
            var sensor = TheRepository.GetSensor(sensorid);
            if (sensor != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                    TheModelFactory.Create(sensor));
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage Post(SensorModel sensorModel)
        {
            if (TheRepository.GetSensors().FirstOrDefault(s => s.Name == sensorModel.Name) != null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Duplicate sensor");
            }
            try
            {
                if (TheRepository.Insert(TheModelFactory.Parse(sensorModel)))
                {
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}