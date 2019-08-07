using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TripStatePattern.Factories;
using TripStatePattern.Interfaces;
using TripStatePattern.Repositories;
using TripStatePattern.Services;

namespace TripStatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var id = 1;
            var start = new DateTime(2019, 4, 1);
            var end   = new DateTime(2019, 4, 8);

            var builder = new ContainerBuilder();

            builder.RegisterType<UnitTripService>().As<IUnitTripService>();
            builder.RegisterType<SampleEventRepository>().As<IEventRepository>();
            builder.RegisterType<TripFactory>().As<ITripFactory>();
            builder.RegisterType<UnitTripServiceFactory>().As<IUnitTripServiceFactory>();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AssignableTo<ITripProcessor>().AsImplementedInterfaces();

            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var tripService = scope.Resolve<IUnitTripServiceFactory>().CreateUnitTripService(id);
                var trips = tripService.CalculateTrips(start, end).ToList();
                foreach (var trip in trips)
                {
                    Console.WriteLine(trip);
                }
                Console.ReadLine();
            }
        }
    }
}
