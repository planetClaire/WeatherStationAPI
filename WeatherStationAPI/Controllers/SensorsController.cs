using System.Linq;
using System.Web.Http;
using WeatherStationDataModel;

namespace WeatherStationAPI.Controllers
{
    public class SensorsController : ApiController
    {
        public object Get()
        {
            var repo = new WeatherStationRepository(new WeatherStationContext());
            return repo.GetAllSensors()
                .OrderBy(s => s.Name)
                .ToList();
        }
    }
}