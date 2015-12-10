using System.Linq;
using WeatherStationDataModel.Entities;

namespace WeatherStationDataModel
{
    public interface IWeatherStationRepository
    {
        IQueryable<Sensor> GetSensors();
        Sensor GetSensor(int id);
        IQueryable<MeasurementType> GetMeasurementTypes();
        bool Insert(MeasurementType entity);
        MeasurementType GetMeasurementType(int measurementtypeid);
        bool DeleteMeasurementType(int measurementtypeid);
    }
}
