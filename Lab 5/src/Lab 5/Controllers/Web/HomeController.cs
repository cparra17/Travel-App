using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Lab_5.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab_5.Controllers
{
    public class HomeController : Controller
    {
        private TripContext db = new TripContext();
        private TripsRepository repo;
        // GET: /<controller>/

        public IActionResult Index()
        {
            //ViewBag.test = db.Trips;
            repo = new TripsRepository(db);
            ViewBag.test = repo.GetAllTrips();
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
