using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Lab_5.Models;
using AutoMapper;
using Lab_5.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab_5.Controllers.API
{
    [Route("api/[controller]")]
    public class TripsController : Controller
    {
        private TripContext db = new TripContext();
        private TripsRepository repo;
                
        
        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            var trips = db.Trips;
            var results = Mapper.Map<IEnumerable<TripViewModel>>(trips);
            return Json(results);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Trip t = repo.GetTrip(id);
            return t.Name;
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]TripViewModel trips)
        {
            var newTrip = Mapper.Map<Trip>(trips);
            newTrip.UserName = "User1";
            repo.AddTrip(newTrip);
            var trip1 = Mapper.Map<TripViewModel>(newTrip);
            return Json(trip1);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
