using Microsoft.AspNetCore.Mvc;
using LibrosApp.Models;
using Microsoft.EntityFrameworkCore;

public class BookController : Controller
{
    private readonly LibrosContext _context;

    public BookController(LibrosContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Create(int authorId)
    {
        var author = _context.Author.Find(authorId);
        if (author == null)
        {
            return RedirectToAction("Index", "Home");
        }

        ViewBag.AuthorName = author.Name;
        ViewBag.AuthorId = authorId;

        // Obtener la lista de autores y asignarla a ViewBag.Authors
        ViewBag.Authors = _context.Author.ToList();

        return View();
    }


    [HttpPost]
    public IActionResult SaveBook(Book book, int authorId)
    {
        if (ModelState.IsValid)
        {
            book.AuthorId = authorId;
            _context.Book.Add(book);
            _context.SaveChanges();

            return RedirectToAction("ListBooksForAuthor", new { authorId = authorId });
        }

        ViewBag.AuthorName = _context.Author.Find(authorId)?.Name;
        ViewBag.AuthorId = authorId;
        return View("Create", book);
    }


    public IActionResult ListBooksForAuthor(int authorId)
    {
        var author = _context.Author.Include(a => a.Books).FirstOrDefault(a => a.AuthorId == authorId);

        if (author == null)
        {
            return RedirectToAction("Index", "Home");
        }

        ViewBag.AuthorName = author.Name;
        ViewBag.AuthorId = authorId;

        return View(author.Books);
    }
}
