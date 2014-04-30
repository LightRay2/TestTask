using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask
{
    class Probe
    {
        public Probe()
        {

        }
        public Probe(string place, int day, int month, int year)
        {
            this.Place = place;
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }

        public string Place { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
