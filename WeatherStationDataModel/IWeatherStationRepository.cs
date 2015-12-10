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
        Sensor GetSensor(int id);
        IQueryable<MeasurementType> GetMeasurementTypes();
        bool Insert(MeasurementType entity);
        MeasurementType GetMeasurementType(int measurementtypeid);
        bool DeleteMeasurementType(int measurementtypeid);
    }
}
