using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using WeatherStationAPI.Models;
using WeatherStationDataModel;

namespace WeatherStationAPI.Controllers
{
    public class MeasurementTypesController : BaseApiController
    {
        public MeasurementTypesController(IWeatherStationRepository repo) : base(repo)
        {
        }

        public HttpResponseMessage Get()
        {
            var measurementTypes = TheRepository.GetMeasurementTypes();
            if (measurementTypes != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                    measurementTypes.OrderBy(m => m.Name).ToList().Select(m => TheModelFactory.Create(m)));
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage Get(int measurementtypeid)
        {
            var measurementType = TheRepository.GetMeasurementType(measurementtypeid);
            if (measurementType != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, measurementType);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage Post(MeasurementTypeModel measurementTypeModel)
        {
            try
            {
                var entity = TheModelFactory.Parse(measurementTypeModel);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not create measurement type from data given");
                }
                var existingEntity = TheRepository.GetMeasurementTypes().FirstOrDefault(m => m.Name.Equals(entity.Name));
                if (existingEntity != null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Duplicates not allowed");
                }
                if (TheRepository.Insert(entity))
                {
                    return Request.CreateResponse(HttpStatusCode.Created, TheModelFactory.Create(entity));
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int measurementtypeid)
        {
            try
            {
                if (TheRepository.GetMeasurementType(measurementtypeid) == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                if (TheRepository.DeleteMeasurementType(measurementtypeid))
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
