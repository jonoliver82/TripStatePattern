using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripStatePattern.Interfaces;
using TripStatePattern.Models;

namespace TripStatePattern.Factories
{
    public class TripFactory : ITripFactory
    {
        public TripModel CreateNewTrip(int unitId, DateTime ignitionOnTime)
        {
            return new TripModel
            {
                UnitId = unitId,
                IgnitionOnTime = ignitionOnTime,
                IgnitionOnTimeTicks = ignitionOnTime.Ticks,
                DistanceKm = 0.0m
            };
        }
    }
}
