using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BaconSaleMovies.Models;

namespace BaconSaleMovies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ReccomendationResponseContext rrContext;

        public HomeController(ILogger<HomeController> logger, ReccomendationResponseContext rrCon)
        {
            _logger = logger;
            rrContext = rrCon;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        //I chose to use the home controller for all routing. No razor pages!
        [HttpGet]
        public IActionResult MovieList()
        {
            return View(rrContext.Recommendations);
        }

        //This is the method that deletes an existing reccomendation.
        [HttpPost]
        public IActionResult MovieList(int reccomendId)
        {
            ReccomendationResponse reccomendRes = rrContext.Recommendations.FirstOrDefault(r =>
                r.ReccomendationId == reccomendId);

            rrContext.Recommendations.Remove(reccomendRes);
            rrContext.SaveChanges();

            return View(rrContext.Recommendations);
        }

        //this routes the user to an "edit" page, with the previous values prepopulated in the form
        [HttpGet]
        public IActionResult EditReccomendation(int reccomendId)
        {
            ReccomendationResponse reccomendRes = rrContext.Recommendations.FirstOrDefault(r =>
                r.ReccomendationId == reccomendId);

            return View(reccomendRes);
        }

        //this edits the movie recommendation with the new values from the form, it also updates "edited" to true!
        [HttpPost]
        public IActionResult EditReccomendation(ReccomendationResponse recResponse)
        {
            rrContext.Recommendations.Update(recResponse);
            rrContext.SaveChanges();

            return View("MovieList", rrContext.Recommendations);
        }

        public IActionResult NotThat()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovies()
        {
            return View();
        }

        //this is what is called when someone enters an actual movie reccomendation
        [HttpPost]
        public IActionResult EnterMovies(ReccomendationResponse movResponse)
        {
            if (movResponse.Title == "Independence Day")
            {
                return View("NotThat", movResponse);
            }
            else if (ModelState.IsValid)
            {
                rrContext.Recommendations.Add(movResponse);
                rrContext.SaveChanges();

                return View("Confirmation", movResponse);
            }
            else
            {
                return View();
            }
            
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
