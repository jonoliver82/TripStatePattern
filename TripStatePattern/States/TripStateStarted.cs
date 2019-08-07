using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripStatePattern.Interfaces;
using TripStatePattern.Models;

namespace TripStatePattern.States
{
    public class TripStateStarted : TripStateBase
    {
        private readonly ITripFactory _tripFactory;
        private readonly IEnumerable<ITripProcessor> _tripProcessors;

        public TripStateStarted(ITripFactory tripFactory, IEnumerable<ITripProcessor> tripProcessors)
        {
            _tripFactory = tripFactory;
            _tripProcessors = tripProcessors;
        }

        public override void HandleEvent(IUnitTripService tripService, EventDTO evt)
        {
            if (evt.EventData == IgnitionEvent.IGNITION_ON)
            {
                // Ignition on when trip in progress - mark current trip as undetermined
                tripService.CurrentTrip.SetUndetermined();

                // Add the undetermined trip to the list
                tripService.AddCurrentTripToList();

                // Create a new trip from this start date
                tripService.CurrentTrip = _tripFactory.CreateNewTrip(tripService.UnitId, evt.DateTime.Value);
            }
            else
            {
                // Ingition Off - complete the trip
                tripService.CurrentTrip.Complete(evt.DateTime.Value);

                // Perform additional processing on the complete trip
                foreach (var processor in _tripProcessors)
                {
                    processor.Process(tripService.CurrentTrip);
                }

                // Add the undetermined trip to the list
                tripService.AddCurrentTripToList();

                // Finished
                tripService.SetState(TripState.Finished);
            }
        }
    }
}
