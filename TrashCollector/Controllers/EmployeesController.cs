using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? day)
        {
            var applicationDbContext = _context.Customer.Include(c => c.Address).Include(c => c.IdentityUser).Include(c => c.Pickup);
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentEmployee = _context.Employee.Where(e => e.IdentityUserId == userId).FirstOrDefault();
            var customersMatchedByZip = applicationDbContext.Where(c => c.Address.ZipCode == currentEmployee.ZipCode);
            //var customersMatchedByZipDay = customersMatchedByZip.Where(c => c.Pickup.PickupDay == DateTime.Today.DayOfWeek.ToString());
            //This statement isn't working for some reason. Seems like it should, but it's not returning the 3 customers who have Thursday as delivery day

            if (day != null)
            {
                var customersMatchedByZipDay = customersMatchedByZip.Where(c => c.Pickup.PickupDay == day);
                return View(await customersMatchedByZipDay.ToListAsync());
            }

            return View(await customersMatchedByZip.ToListAsync());
            
            //I also want to create a method to sort customers by day of the week
        }

        public async Task<IActionResult> PickupCompleted(int id)
        {
            //Take in the customer id? Then change the bool on their Pickup.IsCompleted
            //Add $10 to their balance.
            //Also remove customer's ability to change their own balance

            //I also want to reset this bool after the week is over?
            var customer = _context.Customer.Where(c => c.Id == id).FirstOrDefault();
            customer.Pickup = _context.Pickup.Where(p => p.Id == customer.PickupId).FirstOrDefault();
            customer.Pickup.IsCompleted = true;
            customer.Balance += 10;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult MapOfPickups(int id)
        {
            //Need to get all addresses here that match the employee's zip code. iqueryable
            var customerForPickup = _context.Customer.Where(c => c.Id == id).FirstOrDefault();
            customerForPickup.Address = _context.Address.Where(a => a.Id == customerForPickup.AddressId).FirstOrDefault();
            //I'm having to reassign address, pickup, etc. Should it be this way? Seems like the customer should hold onto that stuff
            var customerAddress = customerForPickup.Address.StreetAddress + ' ' + customerForPickup.Address.City + ' ' + customerForPickup.Address.ZipCode.ToString();

            return View((object)customerAddress);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ZipCode,IdentityUserId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;

                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
                //Need to get this to edit customers, not employees??
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ZipCode,IdentityUserId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
