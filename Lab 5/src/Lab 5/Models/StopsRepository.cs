using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5.Models
{
    public class StopsRepository
    {
        private TripContext dbContext;

        public StopsRepository()
        {

        }

        public StopsRepository(TripContext context)
        {
            dbContext = context;
        }

        public IEnumerable<Stop> Get(string trip)
        {
            var trips = dbContext.Trips.Include(a => a.Stops).Where(a => a.Name == trip).Single();
            return trips.Stops;
        }

        public Trip AddTrip(Stop s, Trip t)
        {
            t.Stops.Add(s);
            dbContext.Trips.Update(t);
            dbContext.SaveChanges();

            return t;
        }
    }
}
