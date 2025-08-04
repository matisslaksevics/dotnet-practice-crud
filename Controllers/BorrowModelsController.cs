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
        private bool IsBorrowOverdue(DateTime borrowDate)
        {
            return borrowDate < DateTime.Today.AddMonths(-3);
        }

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,BookId,BorrowDate,BorrowOverdue")] BorrowModel borrowModel)
        {
            if (borrowModel.BorrowDate == default)
                ModelState.AddModelError("BorrowDate", "Borrow date is required.");

            borrowModel.BorrowOverdue = IsBorrowOverdue(borrowModel.BorrowDate);

            if (!ModelState.IsValid)
            {
                var dump = string.Join("\n", Request.Form.Select(kv => $"{kv.Key} = '{kv.Value}'"));
                ModelState.AddModelError(string.Empty, "DEBUG FORM DUMP:\n" + dump);

                ViewBag.ClientId = new SelectList(_context.ClientModel, "Id", "FirstName", borrowModel.ClientId);
                ViewBag.BookId = new SelectList(_context.BookModel, "Id", "BookName", borrowModel.BookId);
            }

            try
            {
                _context.Add(borrowModel);
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
            if (id == null) return NotFound();

            var borrowModel = await _context.BorrowModel.FindAsync(id);
            if (borrowModel == null) return NotFound();

            ViewBag.ClientId = new SelectList(_context.ClientModel, "Id", "FirstName", borrowModel.ClientId);
            ViewBag.BookId = new SelectList(_context.BookModel, "Id", "BookName", borrowModel.BookId);
            return View(borrowModel);
        }

        // POST: BorrowModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,BookId,BorrowDate, BorrowOverdue")] BorrowModel borrowModel)
        {
            borrowModel.BorrowOverdue = false;
            if (id != borrowModel.Id) return NotFound();

            if (borrowModel.BorrowDate == default)
                ModelState.AddModelError("BorrowDate", "Borrow date is required.");

            borrowModel.BorrowOverdue = IsBorrowOverdue(borrowModel.BorrowDate);

            if (!ModelState.IsValid)
            {
               
                ViewBag.ClientId = new SelectList(_context.ClientModel, "Id", "FirstName", borrowModel.ClientId);
                ViewBag.BookId = new SelectList(_context.BookModel, "Id", "BookName", borrowModel.BookId);
            }

            try
            {
                _context.Update(borrowModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.BorrowModel.Any(e => e.Id == borrowModel.Id)) return NotFound();
                throw;
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(string.Empty, "DB ERROR: " + (ex.InnerException?.Message ?? ex.Message));
                ViewBag.ClientId = new SelectList(_context.ClientModel, "Id", "FirstName", borrowModel.ClientId);
                ViewBag.BookId = new SelectList(_context.BookModel, "Id", "BookName", borrowModel.BookId);
                return View(borrowModel);
            }
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
