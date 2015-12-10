using System;
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

        public bool SaveAll()
        {
            throw new System.NotImplementedException();
        }
        public IQueryable<Sensor> GetSensors()
        {
            return _context.Sensors;
        }

        public Sensor GetSensor(int id)
        {
            //_context.Database.Log = message => Trace.WriteLine(message);
            return _context.Sensors.Find(id);
        }

        public IQueryable<MeasurementType> GetMeasurementTypes()
        {
            return _context.MeasurementTypes;
        }

        public bool Insert(MeasurementType entity)
        {
            _context.Database.Log = message => Trace.WriteLine(message);
            _context.MeasurementTypes.Add(entity);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
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
            return _context.SaveChanges() > 0;
        }
    }
}
