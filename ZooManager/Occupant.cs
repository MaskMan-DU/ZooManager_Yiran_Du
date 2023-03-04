using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    public class Occupant
    {
        public string emoji;
        public string species;

        public Point location;

        public void ReportLocation()
        {
            Console.WriteLine($"I am at {location.x},{location.y}");
        }
    }
}
