using System.Web.Http;
using WeatherStationAPI.Models;
using WeatherStationDataModel;

namespace WeatherStationAPI.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        private readonly IWeatherStationRepository _repo;
        private ModelFactory _modelFactory;

        protected ModelFactory TheModelFactory {
            get { return _modelFactory ?? (_modelFactory = new ModelFactory(Request)); }
        }

        protected IWeatherStationRepository TheRepository {
            get { return _repo; }
        }

        protected BaseApiController(IWeatherStationRepository repo)
        {
            _repo = repo;
        }

    }
}