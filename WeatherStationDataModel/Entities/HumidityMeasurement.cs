namespace WeatherStationDataModel.Entities
{
    public class HumidityMeasurement
    {
        public Measurement Measurement { get; set; }

        public int Id
        {
            get { return Measurement.Id; }
            set { Measurement.Id = value; }
        }
        
        public float Humidity { get; set; }

        public HumidityMeasurement()
        {
            Measurement = new Measurement();
        }
    }
}