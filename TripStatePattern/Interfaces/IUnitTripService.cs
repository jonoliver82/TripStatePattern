using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripStatePattern.Models;
using TripStatePattern.States;

namespace TripStatePattern.Interfaces
{
    public interface IUnitTripService
    {
        /// <summary>
        /// Obtains the trips state
        /// </summary>
        TripStateBase State { get; set; }

        /// <summary>
        /// The current list of calculated trips
        /// </summary>
        List<TripModel> Trips { get; set; }

        /// <summary>
        /// The current trip being calculated
        /// </summary>
        TripModel CurrentTrip { get; set; }

        /// <summary>
        /// The Unit identifier for the trips
        /// </summary>
        int UnitId { get; set; }

        void SetState(TripState state);

        /// <summary>
        /// Obtains a list of trips made for a unit between the given dates
        /// </summary>
        /// <param name="unitId">The unit identifier</param>
        /// <param name="start">Start date time of the range</param>
        /// <param name="end">End date time of the range</param>
        /// <returns>List of trips undertaken</returns>
        IEnumerable<TripModel> CalculateTrips(DateTime start, DateTime end);

        /// <summary>
        /// Adds the current Trip to the list in its current state
        /// </summary>
        void AddCurrentTripToList();
    }
}
