using WeatherStationDataModel.Entities;

namespace WeatherStationAPI.Models
{
    public class ModelFactory
    {
        public SensorModel CreateSensorModel(Sensor sensor)
        {
            return new SensorModel
            {
                Name = sensor.Name,
                Description = sensor.Description,
            };
        }
    }
}