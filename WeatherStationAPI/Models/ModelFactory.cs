using System;
using System.Linq;
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

        public SensorModel Create(Sensor sensor)
        {
            return new SensorModel
            {
                Url = _urlHelper.Link("Sensor", new { sensorid = sensor.Id }),
                Name = sensor.Name,
                Description = sensor.Description,
                MeasurementTypes = sensor.MeasurementTypes.Select(Create)
            };
        }

        public MeasurementTypeModel Create(MeasurementType measurementType)
        {
            return new MeasurementTypeModel
            {
                Id = measurementType.Id,
                Url = _urlHelper.Link("MeasurementType", new { measurementtypeid = measurementType.Id }),
                Name = measurementType.Name
            };
        }

        public MeasurementType Parse(MeasurementTypeModel measurementTypeModel)
        {
            try
            {
                return new MeasurementType { Name = measurementTypeModel.Name };
            }
            catch
            {
                return null;
            }
        }

        public Sensor Parse(SensorModel sensorModel)
        {
            try
            {
                return new Sensor
                {
                    Name = sensorModel.Name,
                    Description = sensorModel.Description
                };
            }
            catch
            {
                return null;
            }
        }
    }
}