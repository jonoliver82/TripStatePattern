using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripStatePattern.Interfaces;
using TripStatePattern.Models;

namespace TripStatePattern.Repositories
{
    public class SampleEventRepository : IEventRepository
    {
        public IEnumerable<EventDTO> ListUnitIgnitionEventsInDateRange(int unitId, DateTime start, DateTime end)
        {
            // Normal implementation would query the respository for matching events
            return new List<EventDTO>()
            {
                new EventDTO { EventData = IgnitionEvent.IGNITION_ON, DateTime = new DateTime(2018,4,1,7,0,0) },
                new EventDTO { EventData = IgnitionEvent.IGNITION_OFF, DateTime = new DateTime(2018,4,1,17,0,0) },

                new EventDTO { EventData = IgnitionEvent.IGNITION_ON, DateTime = new DateTime(2018,4,2,8,0,0) },
                new EventDTO { EventData = IgnitionEvent.IGNITION_OFF, DateTime = new DateTime(2018,4,2,12,0,0) },
            };
        }
    }
}
