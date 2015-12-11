using WeatherStationDataModel.Entities;

namespace WeatherStationAPI.Models
{
    public class HumidityMeasurementModel : MeasurementModel
    {
        public float Humidity { get; set; }

        public override Measurement CreateMeasurement()
        {
            var humidityMeasurement = new HumidityMeasurement
            {
                Humidity = Humidity
            };
            SetMeasurementProperties(humidityMeasurement);
            return humidityMeasurement;
        }
    }
}