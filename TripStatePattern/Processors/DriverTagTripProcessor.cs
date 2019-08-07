using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripStatePattern.Interfaces;
using TripStatePattern.Models;

namespace TripStatePattern.Processors
{
    public class DriverTagTripProcessor : ITripProcessor
    {
        public void Process(TripModel trip)
        {
            // Update trip metadata
            trip.InvalidDriver = false;
            trip.DriverTag = 1;
            trip.Driver = "Test";
        }
    }
}
