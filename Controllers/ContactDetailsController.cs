using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MatrixUsersManagement.Data;
using MatrixUsersManagement.Models;

namespace MatrixUsersManagement.Controllers
{
    public class ContactDetailsController : Controller
    {
        private readonly ManagementContext _context;

        public ContactDetailsController(ManagementContext context)
        {
            _context = context;    
        }

        // GET: ContactDetails
        public async Task<IActionResult> Index()
        {
            var managementContext = _context.ContactDetails.Include(c => c.Owner);
            return View(await managementContext.ToListAsync());
        }

        // GET: ContactDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDetails = await _context.ContactDetails
                .Include(c => c.Owner)
                .SingleOrDefaultAsync(m => m.ContactDetailsID == id);
            if (contactDetails == null)
            {
                return NotFound();
            }

            return View(contactDetails);
        }

        // GET: ContactDetails/Create
        public IActionResult Create()
        {
            ViewData["OwnerUserID"] = new SelectList(_context.Users, "UserID", "UserID");
            return View();
        }

        // POST: ContactDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactDetailsID,OwnerUserID,method,details")] ContactDetails contactDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["OwnerUserID"] = new SelectList(_context.Users, "UserID", "UserID", contactDetails.OwnerUserID);
            return View(contactDetails);
        }

        // GET: ContactDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDetails = await _context.ContactDetails.SingleOrDefaultAsync(m => m.ContactDetailsID == id);
            if (contactDetails == null)
            {
                return NotFound();
            }
            ViewData["OwnerUserID"] = new SelectList(_context.Users, "UserID", "UserID", contactDetails.OwnerUserID);
            return View(contactDetails);
        }

        // POST: ContactDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactDetailsID,OwnerUserID,method,details")] ContactDetails contactDetails)
        {
            if (id != contactDetails.ContactDetailsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactDetailsExists(contactDetails.ContactDetailsID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["OwnerUserID"] = new SelectList(_context.Users, "UserID", "UserID", contactDetails.OwnerUserID);
            return View(contactDetails);
        }

        // GET: ContactDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDetails = await _context.ContactDetails
                .Include(c => c.Owner)
                .SingleOrDefaultAsync(m => m.ContactDetailsID == id);
            if (contactDetails == null)
            {
                return NotFound();
            }

            return View(contactDetails);
        }

        // POST: ContactDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactDetails = await _context.ContactDetails.SingleOrDefaultAsync(m => m.ContactDetailsID == id);
            _context.ContactDetails.Remove(contactDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ContactDetailsExists(int id)
        {
            return _context.ContactDetails.Any(e => e.ContactDetailsID == id);
        }
    }
}
