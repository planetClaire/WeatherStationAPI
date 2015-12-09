using System;

namespace WeatherStationDataModel.Entities
{
    public abstract class Measurement
    {
        public int Id { get; set; }
        public MeasurementType MeasurementType { get; set; }
        public int MeasurementTypeId { get; set; }
        public Sensor Sensor { get; set; }
        public int SensorId { get; set; }
        public DateTime MeasurementDateTime { get; set; }
    }
}