using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5.Models
{
    public class TripsRepository
    {
        private TripContext dbContext;

        public TripsRepository()
        {

        }

        public TripsRepository(TripContext context)
        {
            dbContext = context;
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            var trips = dbContext.Trips.Include(a => a.Stops);
            return trips;
        }

        public Trip GetTrip(int id)
        {
            var trip = dbContext.Trips.Where(a => a.TripID == id).Single();
            return (trip);
        }

        public void AddTrip(Trip t)
        {
            dbContext.Add(t);
        }
    }
}
