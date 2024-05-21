using Assignment1_C0900440.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment1_C0900440.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Principal = 0;
            ViewBag.YearlyInterestRate = 0;
            ViewBag.NumberOfPaymentsPerYear = 0;
            ViewBag.PaymentPerPeriod = 0;
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoanPaymentCalModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.PaymentPerPeriod = model.CalculateLoanPaymentPerPeriod();
            }
            else
            {
                ViewBag.PaymentPerPeriod = 0;
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}