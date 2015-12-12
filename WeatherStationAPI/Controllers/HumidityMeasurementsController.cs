using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using WeatherStationAPI.Models;
using WeatherStationDataModel;

namespace WeatherStationAPI.Controllers
{
    public class HumidityMeasurementsController : BaseApiController
    {
        public HumidityMeasurementsController(IWeatherStationRepository repo) : base(repo)
        {
        }

        public HttpResponseMessage Get()
        {
            var measurements = TheRepository.GetHumidityMeasurements();
            if (measurements != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, measurements.ToList().Select(m => TheModelFactory.Create(m)));
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage Post(HumidityMeasurementModel humidityMeasurementModel)
        {
            try
            {
                if (TheRepository.Insert(TheModelFactory.Parse(humidityMeasurementModel)))
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