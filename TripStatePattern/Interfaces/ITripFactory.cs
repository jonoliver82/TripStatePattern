using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripStatePattern.Models;

namespace TripStatePattern.Interfaces
{
    public interface ITripFactory
    {
        TripModel CreateNewTrip(int unitId, DateTime ignitionOnTime);
    }
}
