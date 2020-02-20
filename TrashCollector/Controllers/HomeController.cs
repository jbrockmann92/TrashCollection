using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (User.IsInRole("Customer"))
                {
                    //Check database of customers. If userId doesn't match any of their foreign keys, don't do create, just return view(index);
                    var customerMatchesId = _context.Customer.Where(c => c.IdentityUserId == userId).FirstOrDefault();
                    if (customerMatchesId == null)
                    {
                        return RedirectToAction("Create", "Customers");
                    }
                    return RedirectToAction("Index", "Customers");
                }
                else if (User.IsInRole("Employee"))
                {
                    var employeeMatchesId = _context.Employee.Where(c => c.IdentityUserId == userId).FirstOrDefault();
                    if (employeeMatchesId == null)
                    {
                        return RedirectToAction("Create", "Employees");
                    }
                    return RedirectToAction("Index", "Employees");
                }
                else
                {
                    return View("Index");
                }
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
    }
}
