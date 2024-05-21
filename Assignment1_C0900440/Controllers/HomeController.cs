using Assignment1_C0900440.Models; // Importing the namespace for models
using Microsoft.AspNetCore.Mvc; // Importing the namespace for ASP.NET Core MVC
using System.Diagnostics; // Importing the namespace for diagnostics

namespace Assignment1_C0900440.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // Logger for logging messages

        // Constructor to initialize the logger
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action method to handle GET requests to the Index page
        [HttpGet]
        public IActionResult Index()
        {
            // Initializing ViewBag properties for the view
            ViewBag.Principal = 0;
            ViewBag.YearlyInterestRate = 0;
            ViewBag.NumberOfPaymentsPerYear = 0;
            ViewBag.PaymentPerPeriod = 0;
            return View(); // Returning the view
        }

        // Action method to handle POST requests to the Index page
        [HttpPost]
        public IActionResult Index(LoanPaymentCalModel model)
        {
            // Checking if the model state is valid
            if (ModelState.IsValid)
            {
                // Calculating and setting the PaymentPerPeriod value in ViewBag
                ViewBag.PaymentPerPeriod = model.CalculateLoanPaymentPerPeriod();
            }
            else
            {
                // Setting PaymentPerPeriod to 0 if the model state is invalid
                ViewBag.PaymentPerPeriod = 0;
            }
            return View(model); // Returning the view with the model
        }

        // Action method to handle errors
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Returning the Error view with an ErrorViewModel
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
