﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryIMS.Models;

namespace LibraryIMS.Controllers
{
    public class MagazinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MagazinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Magazines
        public async Task<IActionResult> Index()
        {
            return View(await _context.Magazines.ToListAsync());
        }

        // GET: Magazines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazine = await _context.Magazines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (magazine == null)
            {
                return NotFound();
            }

            return View(magazine);
        }

        // GET: Magazines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Magazines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Publishar")] Magazine magazine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(magazine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(magazine);
        }

        // GET: Magazines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazine = await _context.Magazines.FindAsync(id);
            if (magazine == null)
            {
                return NotFound();
            }
            return View(magazine);
        }

        // POST: Magazines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Publishar")] Magazine magazine)
        {
            if (id != magazine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(magazine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MagazineExists(magazine.Id))
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
            return View(magazine);
        }

        // GET: Magazines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazine = await _context.Magazines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (magazine == null)
            {
                return NotFound();
            }

            return View(magazine);
        }

        // POST: Magazines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var magazine = await _context.Magazines.FindAsync(id);
            if (magazine != null)
            {
                _context.Magazines.Remove(magazine);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MagazineExists(int id)
        {
            return _context.Magazines.Any(e => e.Id == id);
        }
    }
}
