using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using WeatherStationDataModel;

namespace WeatherStationAPI.Controllers
{
    public class SensorMeasurementTypesController : BaseApiController
    {
        public SensorMeasurementTypesController(IWeatherStationRepository repo) : base(repo)
        {
        }

        public HttpResponseMessage Post(int sensorid, int measurementtypeid)
        {
            try
            {
                var sensor = TheRepository.GetSensor(sensorid);
                if (sensor == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Sensor not found");
                }
                if (sensor.MeasurementTypes.Exists(mt => mt.Id == measurementtypeid))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Duplicate measurement type");
                }
                var measurementType = TheRepository.GetMeasurementType(measurementtypeid);
                if (measurementType == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Measurement type not found");
                }
                sensor.MeasurementTypes.Add(measurementType);
                if (TheRepository.SaveChanges())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(sensor));
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int sensorid, int measurementtypeid)
        {
            try
            {
                var sensor = TheRepository.GetSensor(sensorid);
                if (sensor == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Sensor not found");
                }
                var sensorMeasurementType = sensor.MeasurementTypes.FirstOrDefault(mt => mt.Id == measurementtypeid);
                if (sensorMeasurementType == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Sensor measurement type not found");
                }
                if (TheRepository.DeleteSensorMeasurementType(sensor, sensorMeasurementType))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}