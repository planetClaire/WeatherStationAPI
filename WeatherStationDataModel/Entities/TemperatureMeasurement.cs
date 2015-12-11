namespace WeatherStationDataModel.Entities
{
    public class TemperatureMeasurement
    {
        public Measurement Measurement { get; set; }

        public int Id
        {
            get { return Measurement.Id; }
            set { Measurement.Id = value; }
        }

        public float Temperature { get; set; }
    }
}