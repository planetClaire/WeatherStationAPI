﻿using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace WeatherStationAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "Sensor", "api/sensors/{sensorid}", new
                {
                    controller = "sensors",
                    sensorid = RouteParameter.Optional
                });

            config.Routes.MapHttpRoute(
                "MeasurementType", "api/measurementtypes/{measurementtypeid}", new
                {
                    controller = "measurementTypes",
                    measurementtypeid = RouteParameter.Optional
                });

            config.Routes.MapHttpRoute(
                "SensorMeasurementType", "api/sensors/{sensorid}/measurementtypes/{measurementtypeid}", new
                {
                    controller = "sensorMeasurementTypes",
                    measurementtypeid = RouteParameter.Optional
                });

            config.Routes.MapHttpRoute(
                "Measurement", "api/measurements", new
                {
                    controller = "measurements"
                });

            config.Routes.MapHttpRoute(
                "TemperatureMeasurement", "api/temperaturemeasurements", new
                {
                    controller = "temperatureMeasurements"
                });

            config.Routes.MapHttpRoute(
                "HumidityMeasurement", "api/humiditymeasurements", new
                {
                    controller = "humidityMeasurements"
                });

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
