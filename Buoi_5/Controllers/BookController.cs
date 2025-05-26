using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
public class BookController : Controller
{
    private readonly BookDBContext _context;

    public BookController(BookDBContext context)
    {
        _context = context;
    }

    public IActionResult Index(string categoryName)
    {
        var books = string.IsNullOrEmpty(categoryName)
            ? _context.Books.Include(b => b.Category).ToList()
            : _context.Books.Include(b => b.Category).Where(b => b.Category.CategoryName == categoryName).ToList();
        ViewBag.Categories = _context.Categories.ToList();
        return View(books);
    }

    public IActionResult Details(int id)
    {
        var book = _context.Books.Include(b => b.Category).FirstOrDefault(b => b.Id == id);
        if (book == null) return NotFound();
        return View(book);
    }

    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Book book)
    {
        if (ModelState.IsValid)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
        return View(book);
    }

    public IActionResult Edit(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null) return NotFound();
        ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
        return View(book);
    }

    [HttpPost]
    public IActionResult Edit(Book book)
    {
        if (ModelState.IsValid)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
        return View(book);
    }

    public IActionResult Delete(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null) return NotFound();
        return View(book);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null) return NotFound();
        _context.Books.Remove(book);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}