using System.Diagnostics;
using System.Linq;
using WeatherStationDataModel.Entities;

namespace WeatherStationDataModel
{
    public class WeatherStationRepository : IWeatherStationRepository
    {
        private readonly WeatherStationContext _context;

        public WeatherStationRepository(WeatherStationContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public IQueryable<Sensor> GetSensors()
        {
            return _context.Sensors.Include("MeasurementTypes");
        }

        public Sensor GetSensor(int id)
        {
            return _context.Sensors.Include("MeasurementTypes").FirstOrDefault(s => s.Id == id);
        }

        public bool Insert(Sensor entity)
        {
            _context.Sensors.Add(entity);
            return SaveChanges();
        }

        public IQueryable<MeasurementType> GetMeasurementTypes()
        {
            return _context.MeasurementTypes;
        }

        public bool Insert(MeasurementType entity)
        {
            _context.MeasurementTypes.Add(entity);
            return SaveChanges();
        }

        public MeasurementType GetMeasurementType(int measurementtypeid)
        {
            return _context.MeasurementTypes.Find(measurementtypeid);
        }

        public bool DeleteMeasurementType(int measurementtypeid)
        {
            var measurementType = _context.MeasurementTypes.Find(measurementtypeid);
            if (measurementType == null) return false;
            _context.MeasurementTypes.Remove(measurementType);
            return SaveChanges();
        }

        public bool DeleteSensorMeasurementType(Sensor sensor, MeasurementType sensorMeasurementType)
        {
            _context.Database.Log = message => Trace.WriteLine(message);
            return sensor.MeasurementTypes.Remove(sensorMeasurementType) && SaveChanges();
        }

        public IQueryable<Measurement> GetMeasurements()
        {
            return _context.Measurements;
        }

        public bool Insert(Measurement entity)
        {
            _context.Measurements.Add(entity);
            return SaveChanges();
        }
    }
}
