using BankSystem.Data;
using BankSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace BankSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context= context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var euros = _context.Clients.Where(c => c.Email == User.Identity.Name).Select(c => c.EuroAcc.Funds).FirstOrDefault();
            var dollars = _context.Clients.Where(c => c.Email == User.Identity.Name).Select(c => c.DollarAcc.Funds).FirstOrDefault();
            var pounds = _context.Clients.Where(c => c.Email == User.Identity.Name).Select(c => c.PoundAcc.Funds).FirstOrDefault();
            ViewBag.Euros = euros;
            ViewBag.Dollars = dollars;
            ViewBag.Pounds = pounds;
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult LoanApplications()
        {
            return View();
        }

        public IActionResult CurrencyExchange()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}