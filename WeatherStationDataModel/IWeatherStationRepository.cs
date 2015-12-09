using System.Linq;
using WeatherStationDataModel.Entities;

namespace WeatherStationDataModel
{
    public interface IWeatherStationRepository
    {
        // General
        bool SaveAll();

        // Sensor
        IQueryable<Sensor> GetAllSensors();
    }
}
