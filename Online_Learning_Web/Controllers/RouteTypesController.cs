using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Learning_Web.Models;

namespace Online_Learning_Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RouteTypesController : Controller
    {
        private readonly MyDbContext _context;

        public RouteTypesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: RouteTypes
        public async Task<IActionResult> List()
        {
              return _context.RouteTypes != null ? 
                          View(await _context.RouteTypes.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.RouteTypes'  is null.");
        }

        // GET: RouteTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RouteTypes == null)
            {
                return NotFound();
            }

            var routeType = await _context.RouteTypes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (routeType == null)
            {
                return NotFound();
            }

            return View(routeType);
        }

        // GET: RouteTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RouteTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Image,Description1,Description2,Status")] RouteType routeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(routeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View(routeType);
          
        }

        // GET: RouteTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RouteTypes == null)
            {
                return NotFound();
            }

            var routeType = await _context.RouteTypes.FindAsync(id);
            if (routeType == null)
            {
                return NotFound();
            }
            return View(routeType);
        }

        // POST: RouteTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Image,Description1,Description2,Status")] RouteType routeType)
        {
            if (id != routeType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(routeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RouteTypeExists(routeType.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(List));
            }
            return View(routeType);
        }

        // GET: RouteTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            RouteType rt = _context.RouteTypes.FirstOrDefault(x => x.ID == id);
            if(rt != null)
            {
                _context.Remove(rt);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(List));
        }

        // POST: RouteTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RouteTypes == null)
            {
                return Problem("Entity set 'MyDbContext.RouteTypes'  is null.");
            }
            var routeType = await _context.RouteTypes.FindAsync(id);
            if (routeType != null)
            {
                _context.RouteTypes.Remove(routeType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RouteTypeExists(int id)
        {
          return (_context.RouteTypes?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
