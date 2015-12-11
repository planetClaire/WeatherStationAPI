using WeatherStationDataModel.Entities;

namespace WeatherStationAPI.Models
{
    public class TemperatureMeasurementModel : MeasurementModel
    {
        public float Temperature { get; set; }

        public override Measurement CreateMeasurement()
        {
            var temperatureMeasurement = new TemperatureMeasurement
            {
                Temperature = Temperature
            };
            SetMeasurementProperties(temperatureMeasurement);
            return temperatureMeasurement;
        }
    }
}