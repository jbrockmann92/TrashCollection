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
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Customer.Include(c => c.Address).Include(c => c.IdentityUser).Include(c => c.Pickup);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .Include(c => c.Address)
                .Include(c => c.IdentityUser)
                .Include(c => c.Pickup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            //This creates a list of addresses, etc. I want to input a new one
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            //var userId = _context.UserRoles.Select(a => a).LastOrDefault(e => e.RoleId != null);
            ////This doesn't work because it tries to grab the null row at the bottom?
            //Customer customer = new Customer();
            //customer.IdentityUserId = userId.UserId;

            //I don't think any of this is going to work. The table doesn't update at the top or bottom. Weird. Need to grab most recent item

            //Somewhere around here I need to assign the most recently created userid, or grab the identityUser and assign them to the customer I'm going to create
            //I need that long string of gibberish that's already put into the AspNetUserRoles table so I can grab the user and put them into the IdentityUser column in the Customer table???
            return View();
            //I want to require an address when they are created
            //How to attach the user.Id to the customer.Id??

            //Could have them create an address during registration, then choose that address from a dropdown list
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Balance,AddressId,PickupId,IdentityUserId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var orderedUsers = _context.Users.OrderByDescending(u => u);
                customer.IdentityUser = orderedUsers.First(); //What here? How do I grab the most recently created user from the db? Or do I want just the Id to match?
                //And this may not assign a key automatically to the IdentityUser that I assign to the Customer?
                _context.Customer.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Addresses");
            }
            ViewData["AddressId"] = new SelectList(_context.Set<Address>(), "Id", "Id", customer.AddressId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            ViewData["PickupId"] = new SelectList(_context.Set<Pickup>(), "Id", "Id", customer.PickupId);

            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Set<Address>(), "Id", "Id", customer.AddressId);
            ViewData["PickupId"] = new SelectList(_context.Set<Pickup>(), "Id", "Id", customer.PickupId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Balance,AddressId,PickupId,IdentityUserId")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            ViewData["AddressId"] = new SelectList(_context.Set<Address>(), "Id", "Id", customer.AddressId);
            ViewData["PickupId"] = new SelectList(_context.Set<Pickup>(), "Id", "Id", customer.PickupId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .Include(c => c.Address)
                .Include(c => c.IdentityUser)
                .Include(c => c.Pickup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
