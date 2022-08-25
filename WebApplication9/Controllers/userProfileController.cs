using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication9.Data;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class userProfileController : Controller
    {
        private readonly WebApplication9Context _context;

        public userProfileController(WebApplication9Context context)
        {
            _context = context;
        }

        // GET: userProfile
        public async Task<IActionResult> Index()
        {
            return View(await _context.userProfile.ToListAsync());
        }

        // GET: userProfile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfile = await _context.userProfile
                .FirstOrDefaultAsync(m => m.id == id);
            if (userProfile == null)
            {
                return NotFound();
            }

            return View(userProfile);
        }

        // GET: userProfile/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: userProfile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,firstname,lastname,username,password")] userProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userProfile);
        }

        // GET: userProfile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfile = await _context.userProfile.FindAsync(id);
            if (userProfile == null)
            {
                return NotFound();
            }
            return View(userProfile);
        }

        // POST: userProfile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,firstname,lastname,username,password")] userProfile userProfile)
        {
            if (id != userProfile.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!userProfileExists(userProfile.id))
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
            return View(userProfile);
        }

        // GET: userProfile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfile = await _context.userProfile
                .FirstOrDefaultAsync(m => m.id == id);
            if (userProfile == null)
            {
                return NotFound();
            }

            return View(userProfile);
        }

        // POST: userProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userProfile = await _context.userProfile.FindAsync(id);
            _context.userProfile.Remove(userProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool userProfileExists(int id)
        {
            return _context.userProfile.Any(e => e.id == id);
        }
    }
}
