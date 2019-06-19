using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Animal.Models;
using Animal.Repository;

namespace Animal.Controllers
{
    public class AnimalSelectionsController : Controller
    {
        private readonly AnimalContext _context;

        public AnimalSelectionsController(AnimalContext context)
        {
            _context = context;
        }

        // GET: AnimalSelections
        public async Task<IActionResult> Index()
        {
            return View(await _context.animalSelections.ToListAsync());
        }

        // GET: AnimalSelections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalSelection = await _context.animalSelections
                .FirstOrDefaultAsync(m => m.id == id);
            if (animalSelection == null)
            {
                return NotFound();
            }

            return View(animalSelection);
        }

        // GET: AnimalSelections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnimalSelections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,animalId,ownerId,farmId,selectionDate,shortNotes")] AnimalSelection animalSelection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animalSelection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animalSelection);
        }

        // GET: AnimalSelections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalSelection = await _context.animalSelections.FindAsync(id);
            if (animalSelection == null)
            {
                return NotFound();
            }
            return View(animalSelection);
        }

        // POST: AnimalSelections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,animalId,ownerId,farmId,selectionDate,shortNotes")] AnimalSelection animalSelection)
        {
            if (id != animalSelection.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animalSelection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalSelectionExists(animalSelection.id))
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
            return View(animalSelection);
        }

        // GET: AnimalSelections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalSelection = await _context.animalSelections
                .FirstOrDefaultAsync(m => m.id == id);
            if (animalSelection == null)
            {
                return NotFound();
            }

            return View(animalSelection);
        }

        // POST: AnimalSelections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animalSelection = await _context.animalSelections.FindAsync(id);
            _context.animalSelections.Remove(animalSelection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalSelectionExists(int id)
        {
            return _context.animalSelections.Any(e => e.id == id);
        }
    }
}
