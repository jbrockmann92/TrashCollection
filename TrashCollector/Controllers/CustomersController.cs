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
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var applicationDbContext = _context.Customer.Include(c => c.Address).Include(c => c.IdentityUser).Include(c => c.Pickup);
            var singleUser = applicationDbContext.Where(c => c.IdentityUserId == userId);
            return View(await singleUser.ToListAsync());
            //Should be working now. Should only return the current user

            //Maybe want to include buttons on the homepage that allow the user to do things, but not necessary

            //Must be something going on with the create method. It's only if it hits the create method that the list of other customers comes up
            //Create method goes to index after. Need to default to Index after login I think
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

        public IActionResult SuspendService(int id)
        {
            //Grab customer from db. Bring up the delivery info associated with that customer. Tell them to enter the dates
            var customer = _context.Customer.Where(c => c.Id == id).FirstOrDefault();

            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> SuspendService(Customer customer)
        {
            //Take the customer's inputs and change the days of suspension
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = _context.Customer.Where(c => c.IdentityUserId == userId).FirstOrDefault();
            currentUser.Pickup = customer.Pickup;

            currentUser.Pickup.IsSuspended = true;


            return RedirectToAction("Index");
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
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                customer.Pickup = new Pickup();

                _context.Customer.Add(customer);
                _context.SaveChanges();
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
            var customer = _context.Customer.Where(c=>c.Id == id).FirstOrDefault();
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            var pickup = _context.Pickup.Where(p => p.Id == customer.PickupId).FirstOrDefault();
            pickup.PickupDay = customer.Pickup.PickupDay;
            var address = _context.Address.Where(a => a.Id == customer.AddressId).FirstOrDefault();
            var idUser = _context.Users.Where(u=>u.Id == customer.IdentityUserId).FirstOrDefault();

            customer.Pickup = pickup;
            //This overwrites any updates they have made to the pickup day
            customer.Address = address;
            customer.IdentityUser = idUser;
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
