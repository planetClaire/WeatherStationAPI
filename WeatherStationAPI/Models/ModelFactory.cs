using System.Net.Http;
using System.Web.Http.Routing;
using WeatherStationDataModel.Entities;

namespace WeatherStationAPI.Models
{
    public class ModelFactory
    {
        private readonly UrlHelper _urlHelper;

        public ModelFactory(HttpRequestMessage request)
        {
            _urlHelper = new UrlHelper(request);
        }

        public SensorModel CreateSensorModel(Sensor sensor)
        {
            return new SensorModel
            {
                Url = _urlHelper.Link("Sensor", new { sensorid = sensor.Id }),
                Name = sensor.Name,
                Description = sensor.Description,
            };
        }
    }
}