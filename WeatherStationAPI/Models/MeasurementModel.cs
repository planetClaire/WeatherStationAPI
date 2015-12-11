using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeatherStationDataModel.Entities;

namespace WeatherStationAPI.Models
{
    [JsonConverter(typeof (MeasurementConverter))]
    public class MeasurementModel
    {
        public DateTime MeasurementDateTime { get; set; }
        public int SensorId { get; set; }
        public int MeasurementTypeId { get; set; }

        public MeasurementModel() { }

        public MeasurementModel(Measurement measurement)
        {
            MeasurementDateTime = measurement.MeasurementDateTime;
            SensorId = measurement.SensorId;
            MeasurementTypeId = measurement.MeasurementTypeId;
        }

        public virtual Measurement CreateMeasurement()
        {
            return null;
        }

        protected void SetMeasurementProperties(Measurement measurement)
        {
            measurement.MeasurementDateTime = MeasurementDateTime;
            measurement.SensorId = SensorId;
            measurement.MeasurementTypeId = MeasurementTypeId;
        }

        private class MeasurementConverter : JsonCreationConverter<MeasurementModel>
        {
            protected override MeasurementModel Create(Type objectType, JObject jObject)
            {
                switch (jObject.Value<string>("measurementType"))
                {
                    case "Temperature":
                        return new TemperatureMeasurementModel();
                    case "Humidity":
                        return new HumidityMeasurementModel();
                    default:
                        return null;
                }
            }
        }

    }
}