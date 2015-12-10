using System.Collections.Generic;

namespace WeatherStationDataModel.Entities
{
    public class Sensor
    {
        public Sensor()
        {
            MeasurementTypes = new List<MeasurementType>();    
            Measurements = new List<Measurement>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MeasurementType> MeasurementTypes { get; set; }
        public List<Measurement> Measurements { get; set; }
    }
}