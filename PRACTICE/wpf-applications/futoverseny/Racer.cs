using System;
using System.Collections.Generic;
using System.Text;

namespace futoverseny
{
    public class Racer
    {
        public int RaceId { get; set; }
        public string Name { get; set; }
        public DateTime Born { get; set; }
        public string Country { get; set; }
        public string TimeResult { get; set; }
        public int Age { get; set; }

        public Racer(
            int raceId,
            string name,
            DateTime born,
            string country,
            string timeResult
        ) 
        {
            this.RaceId = raceId;
            this.Name = name;
            this.Born = born;
            this.Country = country;
            this.TimeResult = timeResult;
            this.Age = DateTime.Today.Year - born.Year;
        }
    }
}
