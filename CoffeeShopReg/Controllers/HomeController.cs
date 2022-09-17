using CoffeeShopReg.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace CoffeeShopReg.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CoffeeShopRegContext context = new CoffeeShopRegContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult NewCustomer()
        {
            return View();
        }

        public IActionResult AddCustomerToDb(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();

            return RedirectToAction("Welcome");
        }

        public IActionResult Welcome()
        {
            Customer customer = context.Customers.OrderBy(x => x.Id).LastOrDefault();
            return View(customer);
        }

        public IActionResult CustomerInfo()
        {
            List<Customer> customers = context.Customers.ToList();
            return View(customers);
        }

     


    }
}