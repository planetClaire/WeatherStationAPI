﻿using System.Collections.Generic;

namespace WeatherStationDataModel.Entities
{
    public class MeasurementType
    {
        public int Id { get; set; }
        public string Name { get;set; }
        public List<Sensor> Sensors { get; set; }
    }
}