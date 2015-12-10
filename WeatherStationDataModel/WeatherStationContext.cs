using System.Data.Entity;
using WeatherStationDataModel.Entities;

namespace WeatherStationDataModel
{
    public class WeatherStationContext : DbContext
    {
        public DbSet<TemperatureMeasurement> TemperatureMeasurements { get; set; }
        public DbSet<HumidityMeasurement> HumidityMeasurements { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<MeasurementType> MeasurementTypes { get; set; }
    }
}
