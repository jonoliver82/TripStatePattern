using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripStatePattern.Interfaces;
using TripStatePattern.Services;

namespace TripStatePattern.Factories
{
    public class UnitTripServiceFactory : IUnitTripServiceFactory
    {
        private readonly IEventRepository _eventRepository;
        private readonly ITripFactory _tripFactory;
        private readonly IEnumerable<ITripProcessor> _tripProcessors;

        public UnitTripServiceFactory(IEventRepository eventRepository,
            ITripFactory tripFactory,
            IEnumerable<ITripProcessor> tripProcessors)
        {
            _eventRepository = eventRepository;
            _tripFactory = tripFactory;
            _tripProcessors = tripProcessors;
        }

        public IUnitTripService CreateUnitTripService(int unitId)
        {
            return new UnitTripService(unitId,
                _eventRepository,
                _tripFactory,
                _tripProcessors);
        }
    }
}
