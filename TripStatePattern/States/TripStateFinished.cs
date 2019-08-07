using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripStatePattern.Interfaces;
using TripStatePattern.Models;

namespace TripStatePattern.States
{
    public class TripStateFinished : TripStateBase
    {
        private readonly ITripFactory _tripFactory;

        public TripStateFinished(ITripFactory tripFactory)
        {
            _tripFactory = tripFactory;
        }

        public override void HandleEvent(IUnitTripService tripService, EventDTO evt)
        {
            // No action required if ignition off event and no trip in progress
            if (evt.EventData == IgnitionEvent.IGNITION_ON)
            {
                tripService.CurrentTrip = _tripFactory.CreateNewTrip(tripService.UnitId, evt.DateTime.Value);
                tripService.SetState(TripState.Started);
            }
        }
    }
}
