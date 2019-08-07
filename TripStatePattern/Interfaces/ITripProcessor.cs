using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripStatePattern.Models;

namespace TripStatePattern.Interfaces
{
    /// <summary>
    /// An interface to be implemented by classes that perform operations on trips
    /// </summary>
    public interface ITripProcessor
    {
        /// <summary>
        /// Performs the required processing
        /// </summary>
        /// <param name="trip">The trip to process</param>
        void Process(TripModel trip);
    }
}
