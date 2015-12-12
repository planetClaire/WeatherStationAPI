using System.Linq;
using WeatherStationDataModel.Entities;

namespace WeatherStationDataModel
{
    public interface IWeatherStationRepository
    {
        bool SaveChanges();
        IQueryable<Sensor> GetSensors();
        Sensor GetSensor(int id);
        bool Insert(Sensor entity);

        IQueryable<MeasurementType> GetMeasurementTypes();
        bool Insert(MeasurementType entity);
        MeasurementType GetMeasurementType(int measurementtypeid);
        bool DeleteMeasurementType(int measurementtypeid);
        
        bool DeleteSensorMeasurementType(Sensor sensor, MeasurementType sensorMeasurementType);
        
        IQueryable<Measurement> GetMeasurements();
        bool Insert(TemperatureMeasurement entity);
        bool Insert(HumidityMeasurement entity);
        IQueryable<TemperatureMeasurement> GetTemperatureMeasurements();
        IQueryable<HumidityMeasurement> GetHumidityMeasurements();
    }
}
