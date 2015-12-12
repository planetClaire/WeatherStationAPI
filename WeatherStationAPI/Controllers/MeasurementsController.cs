using System.Linq;
using System.Net;
using System.Net.Http;
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

    }
}