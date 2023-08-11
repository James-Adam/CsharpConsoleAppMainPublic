using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Controllers;

public class CategoriesTempController : Controller
{
    private readonly ApplicationDbContext _context;

    public CategoriesTempController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: CategoriesTemp
    public async Task<IActionResult> Index()
    {
        return _context.Categories != null
            ? View(await _context.Categories.ToListAsync())
            : Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
    }

    // GET: CategoriesTemp/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Categories == null) return NotFound();

        var category = await _context.Categories
            .FirstOrDefaultAsync(m => m.Id == id);
        return category == null ? NotFound() : View(category);
    }

    // GET: CategoriesTemp/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CategoriesTemp/Create To protect from overposting attacks, enable the specific
    // properties you want to bind to. For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,DisplayOrder,CreatedDateTime")] Category category)
    {
        if (ModelState.IsValid)
        {
            _ = _context.Add(category);
            _ = await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }

    // GET: CategoriesTemp/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Categories == null) return NotFound();

        var category = await _context.Categories.FindAsync(id);
        return category == null ? NotFound() : View(category);
    }

    // POST: CategoriesTemp/Edit/5 To protect from overposting attacks, enable the specific
    // properties you want to bind to. For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DisplayOrder,CreatedDateTime")] Category category)
    {
        if (id != category.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _ = _context.Update(category);
                _ = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(category.Id))
                    return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }

    // GET: CategoriesTemp/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Categories == null) return NotFound();

        var category = await _context.Categories
            .FirstOrDefaultAsync(m => m.Id == id);
        return category == null ? NotFound() : View(category);
    }

    // POST: CategoriesTemp/Delete/5
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Categories == null) return Problem("Entity set 'ApplicationDbContext.Categories'  is null.");

        var category = await _context.Categories.FindAsync(id);
        if (category != null) _ = _context.Categories.Remove(category);

        _ = await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CategoryExists(int id)
    {
        return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}