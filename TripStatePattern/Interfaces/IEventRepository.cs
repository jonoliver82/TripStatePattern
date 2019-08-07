using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripStatePattern.Models;

namespace TripStatePattern.Interfaces
{
    public interface IEventRepository
    {
        /// <summary>
        /// Returns a list of ignition events for a unit within a date range
        /// </summary>
        /// <param name="unitId">The unit to query</param>
        /// <param name="start">Start date</param>
        /// <param name="end">End date</param>
        /// <returns>List of events</returns>
        IEnumerable<EventDTO> ListUnitIgnitionEventsInDateRange(int unitId, DateTime start, DateTime end);
    }
}
