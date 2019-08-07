using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripStatePattern.Interfaces;
using TripStatePattern.Models;

namespace TripStatePattern.Processors
{
    public class IdleTimeTripProcessor : ITripProcessor
    {
        public void Process(TripModel trip)
        {
            // Update trip metadata
            var totalDuration = TimeSpan.FromHours(1);
            trip.IdleTime = totalDuration;
            trip.IdleTimeMilliseconds = totalDuration.TotalMilliseconds;
        }
    }
}
