using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Lab_5.Models;
using AutoMapper;
using Lab_5.ViewModels;
using Microsoft.Data.Entity;
using Lab_5.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab_5.Controllers.API
{
    [Route("api/[controller]/{tripName}")]
    public class StopsController : Controller
    {
        private TripContext db = new TripContext();
        private StopsRepository repo;
        private CoordinateService service;

        public StopsController(TripContext tp, CoordinateService s)
        {
            db = tp;
            service = s;
        }

        // GET: api/values
        [HttpGet]
        public JsonResult Get(string tripName)
        {
            var stops = db.Trips.Include(a => a.Stops).Where(a => a.Name == tripName);
            var results = Mapper.Map<IEnumerable<StopViewModel>>(stops);
            return Json(results);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        async Task<JsonResult> Post([FromBody]Trip trip, Stop stop)
        {
            var Trip1 = Mapper.Map<Trip>(trip);
            var Stop1 = Mapper.Map<Stop>(stop);
            var longlat = await service.Lookup(Stop1.Name);
            Trip1.Stops.Add(Stop1);
            if (ModelState.IsValid)
            {
                db.Trips.Update(Trip1);
                db.SaveChanges();
            }


            var result = Mapper.Map<TripViewModel>(Trip1);
            return Json(result);
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
