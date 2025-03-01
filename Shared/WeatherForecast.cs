﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Try_Blazor.Shared
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public bool Selected { get; set;}
    }
}
