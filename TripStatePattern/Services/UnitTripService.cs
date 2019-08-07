using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripStatePattern.Interfaces;
using TripStatePattern.Models;
using TripStatePattern.States;

namespace TripStatePattern.Services
{
    public class UnitTripService : IUnitTripService
    {
        private readonly IEventRepository _eventRepository;
        private readonly ITripFactory _tripFactory;
        private readonly IEnumerable<ITripProcessor> _tripProcessors;

        private TripStateBase _tripState;
        private List<TripModel> _trips;
        private TripModel _currentTrip;
        private int _unitId;

        public List<TripModel> Trips
        {
            get { return _trips; }
            set { _trips = value; }
        }

        public TripModel CurrentTrip
        {
            get { return _currentTrip; }
            set { _currentTrip = value; }
        }

        public int UnitId
        {
            get { return _unitId; }
            set { _unitId = value; }
        }

        public TripStateBase State
        {
            get { return _tripState; }
            set { _tripState = value; }
        }

        public UnitTripService(int unitId,
            IEventRepository eventRepository,
            ITripFactory tripFactory,
            IEnumerable<ITripProcessor> tripProcessors)
        {
            _unitId = unitId;
            _eventRepository = eventRepository;
            _tripFactory = tripFactory;
            _tripProcessors = tripProcessors;

            // Set state to finished, ie not in progress
            _tripState = new TripStateFinished(_tripFactory);
            _trips = new List<TripModel>();
        }

        /// <summary>
        /// Calculates trips for the unit within a date range
        /// </summary>
        /// <param name="start">Start of range</param>
        /// <param name="end">End of range</param>
        /// <returns>List of trips</returns>
        public IEnumerable<TripModel> CalculateTrips(DateTime start, DateTime end)
        {
            // Handle the events, taking the appropriate action for each depending on state
            var events = _eventRepository.ListUnitIgnitionEventsInDateRange(_unitId, start, end);
            foreach (var evt in events)
            {
                _tripState.HandleEvent(this, evt);
            }

            return _trips;
        }

        public void AddCurrentTripToList()
        {
            _trips.Add(_currentTrip);
        }

        public void SetState(TripState state)
        {
            if (state == TripState.Started)
            {
                _tripState = new TripStateStarted(_tripFactory, _tripProcessors);
            }
            else
            {
                _tripState = new TripStateFinished(_tripFactory);
            }
        }
    }
}
