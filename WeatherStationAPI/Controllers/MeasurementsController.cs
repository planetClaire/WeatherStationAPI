using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using WeatherStationAPI.Models;
using WeatherStationDataModel;

namespace WeatherStationAPI.Controllers
{
    public class MeasurementsController : BaseApiController
    {
        public MeasurementsController(IWeatherStationRepository repo) : base(repo)
        {
        }

        public HttpResponseMessage Get()
        {
            var measurements = TheRepository.GetMeasurements();
            if (measurements != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, measurements.ToList().Select(m => TheModelFactory.Create(m)));
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage Post(MeasurementModel measurementModel)
        {
            try
            {
                if (TheRepository.Insert(TheModelFactory.Parse(measurementModel)))
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