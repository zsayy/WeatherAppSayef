using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAp.Services
{
    public class CurrentCondition
    {
        public int tmp { get; set; }
        public string condition { get; set; }
        // Ajoutez d'autres propriétés au besoin
    }

    public class FcstDay
    {
        public string day_long { get; set; }
        public int tmin { get; set; }
        public int tmax { get; set; }
        public string condition { get; set; }
        // Ajoutez d'autres propriétés au besoin
    }

    public class Root
    {
        public CurrentCondition current_condition { get; set; }
        public FcstDay fcst_day_0 { get; set; }
        public FcstDay fcst_day_1 { get; set; }
        public FcstDay fcst_day_2 { get; set; }
        public FcstDay fcst_day_3 { get; set; }
        // Ajoutez d'autres prévisions (fcst_day_4, fcst_day_5, etc.) au besoin
    }
}
