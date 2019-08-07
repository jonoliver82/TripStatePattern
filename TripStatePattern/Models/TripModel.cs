using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripStatePattern.Models
{
    public class TripModel
    {
        public int UnitId { get; set; }
        public DateTime IgnitionOnTime { get; set; }
        public long IgnitionOnTimeTicks { get; set; }
        public DateTime? IgnitionOffTime { get; set; }
        public TimeSpan? Duration { get; set; }
        public double? DurationMilliseconds { get; set; }
        public int? DriverTag { get; set; }
        public string Driver { get; set; }
        public int? UserId { get; set; }
        public bool SpeedLimitExceeded { get; set; }
        public bool InvalidDriver { get; set; }
        public decimal DistanceKm { get; set; }
        public TimeSpan IdleTime { get; set; }
        public double? IdleTimeMilliseconds { get; set; }

        public void SetUndetermined()
        {
            Duration = null;
            IgnitionOffTime = null;
        }

        public void Complete(DateTime ignitionOffTime)
        {
            IgnitionOffTime = ignitionOffTime;
            Duration = ignitionOffTime - IgnitionOnTime;
            DurationMilliseconds = Duration.Value.TotalMilliseconds;
            Driver = string.Empty;
            DriverTag = null;
        }

        public override string ToString()
        {
            return $"Unit {UnitId} Duration {Duration} Driver {Driver} Distance {DistanceKm} Speed Limit Exceeded {SpeedLimitExceeded}";
        }
    }
}
