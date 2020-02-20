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
            //This might be kind of redundant at this point? Maybe not. Need to join these so they are accessible later?
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentEmployee = _context.Employee.Where(e => e.IdentityUserId == userId).FirstOrDefault();
            //I need to gt into the joint table here and compare? Or something. Grab all the customers and grab their zip codes
            var customersMatchedByZip = applicationDbContext.Where(c => c.Address.ZipCode == currentEmployee.ZipCode);
            var customersMatchedByZipDay = customersMatchedByZip.Where(c => c.Pickup.PickupDay == DateTime.Today.DayOfWeek.ToString());
            
            //if (day != null)
            //{
            //    var customersMatchedByZipDay = customersMatchedByZip.Where(c => c.Pickup.PickupDay == day);
            //    return View(await customersMatchedByZipDay.ToListAsync());
            //    //This may actually work. Need something in the other Index Method (Post?) that will allow the user to choose a day
            //    //Button that allows the user to input into a field, then if they press it, it calls Index method? I need a post method though I think that has this in it?
            //}

            return View(await customersMatchedByZip.ToListAsync());
            
            //I also want to create a method to sort customers by day of the week
        }

        ////Get
        //public IActionResult IndexDaysOfWeek()
        //{
        //    //ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
        //    //Is it here that I want the employee to decide which day they want? Or In Index.cshtml? Or IndexDaysOfWeek.cshtml?
        //    return View();
        //    //I might not even need a separate method for this. What if I create a get Index method, leave the Post as is, and write the 
        //}

        ////Post
        //[HttpPost]
        //public async Task<IActionResult> IndexDaysOfWeek(string day)
        //{
        //    var applicationDbContext = _context.Customer.Include(c => c.Address).Include(c => c.IdentityUser).Include(c => c.Pickup);
        //    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var currentEmployee = _context.Employee.Where(e => e.IdentityUserId == userId).FirstOrDefault();
        //    var customersMatchedByZip = applicationDbContext.Where(c => c.Address.ZipCode == currentEmployee.ZipCode);
        //    var customersZipAndDay = customersMatchedByZip.Where(c => c.Pickup.PickupDay == day);


                

        //    //Need to create a IndexDaysOfWeek.cshtml file that will run when this method returns the View()
        //    //Should look very similar to Index.cshtml
        //    //I want a dropdown menu, then 
        //    //I think I want this as [httpPost] so that I can grab the employee's input on the cshtml page

        //    return View(await customersMatchedByZip.ToListAsync());
        //}

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

            var employee = await _context.Employee
                .Include(e => e.identityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
