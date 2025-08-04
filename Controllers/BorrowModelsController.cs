using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotnetPracticeCrud.Data;
using DotnetPracticeCrud.Models;

namespace DotnetPracticeCrud.Controllers
{
    public class BorrowModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BorrowModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BorrowModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BorrowModel.Include(b => b.Book).Include(b => b.Client);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BorrowModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowModel = await _context.BorrowModel
                .Include(b => b.Book)
                .Include(b => b.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (borrowModel == null)
            {
                return NotFound();
            }

            return View(borrowModel);
        }

        // GET: BorrowModels/Create
        public IActionResult Create()
        {
            ViewBag.ClientId = new SelectList(_context.ClientModel, "Id", "FirstName");
            ViewBag.BookId = new SelectList(_context.BookModel, "Id", "BookName");

            return View(new BorrowModel
            {
                BorrowDate = DateTime.Today
            });

        }

        // POST: BorrowModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,BookId,BorrowDate")] BorrowModel borrowModel)
        {
            // Treat empty/omitted date as invalid
            if (borrowModel.BorrowDate == default)
                ModelState.AddModelError("BorrowDate", "Borrow date is required.");

            // FK existence checks (so you get a clear message instead of a silent fail)
            if (!await _context.ClientModel.AnyAsync(c => c.Id == borrowModel.ClientId))
                ModelState.AddModelError("ClientId", $"Client #{borrowModel.ClientId} does not exist.");
            if (!await _context.BookModel.AnyAsync(b => b.Id == borrowModel.BookId))
                ModelState.AddModelError("BookId", $"Book #{borrowModel.BookId} does not exist.");

            if (!ModelState.IsValid)
            {
                // Show what was posted (already working for you)
                var dump = string.Join("\n", Request.Form.Select(kv => $"{kv.Key} = '{kv.Value}'"));
                ModelState.AddModelError(string.Empty, "DEBUG FORM DUMP:\n" + dump);

                ViewBag.ClientId = new SelectList(_context.ClientModel, "Id", "FirstName", borrowModel.ClientId);
                ViewBag.BookId = new SelectList(_context.BookModel, "Id", "BookName", borrowModel.BookId);
                // return View(borrowModel);
            }

            try
            {
                _context.Add(borrowModel); // Id is identity - do not bind it
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                var msg = ex.InnerException?.Message ?? ex.Message;
                ModelState.AddModelError(string.Empty, "DB ERROR: " + msg);

                ViewBag.ClientId = new SelectList(_context.ClientModel, "Id", "FirstName", borrowModel.ClientId);
                ViewBag.BookId = new SelectList(_context.BookModel, "Id", "BookName", borrowModel.BookId);
                return View(borrowModel);
            }
        }


        // GET: BorrowModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowModel = await _context.BorrowModel.FindAsync(id);
            if (borrowModel == null)
            {
                return NotFound();
            }
            ViewBag.ClientId = new SelectList(_context.ClientModel, "Id", "FirstName", borrowModel.ClientId);
            ViewBag.BookId = new SelectList(_context.BookModel, "Id", "BookName", borrowModel.BookId);
            return View(borrowModel);
        }

        // POST: BorrowModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,BookId,BorrowDate")] BorrowModel borrowModel)
        {
            if (id != borrowModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrowModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowModelExists(borrowModel.Id))
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
            ViewBag.ClientId = new SelectList(_context.ClientModel, "Id", "FirstName", borrowModel.ClientId);
            ViewBag.BookId = new SelectList(_context.BookModel, "Id", "BookName", borrowModel.BookId);
            return View(borrowModel);
        }

        // GET: BorrowModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowModel = await _context.BorrowModel
                .Include(b => b.Book)
                .Include(b => b.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (borrowModel == null)
            {
                return NotFound();
            }

            return View(borrowModel);
        }

        // POST: BorrowModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var borrowModel = await _context.BorrowModel.FindAsync(id);
            if (borrowModel != null)
            {
                _context.BorrowModel.Remove(borrowModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowModelExists(int id)
        {
            return _context.BorrowModel.Any(e => e.Id == id);
        }
    }
}
