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

        public IQueryable<Sensor> GetAllSensors()
        {
            return _context.Sensors;
        }

        public Sensor GetSensor(int id)
        {
            //_context.Database.Log = message => Trace.WriteLine(message);
            return _context.Sensors.Find(id);
        }
    }
}
