using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripStatePattern.Interfaces;
using TripStatePattern.Models;

namespace TripStatePattern.States
{
    public abstract class TripStateBase
    {
        public abstract void HandleEvent(IUnitTripService tripService, EventDTO evt);
    }
}
