using Microsoft.AspNetCore.Mvc;
using LibrosApp.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class AuthorController : Controller
{
    private readonly LibrosContext _context;

    public AuthorController(LibrosContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var authors = _context.Author.ToList();
        return View(authors);
    }

    [HttpGet]
    public IActionResult Create()
    {
        // Obtener la lista de autores desde la base de datos
        var authors = _context.Author.ToList();

        // Asignar la lista de autores a ViewBag.Authors
        ViewBag.Authors = authors;

        return View();
    }


    [HttpPost]
    public IActionResult Create(Author author)
    {
        if (ModelState.IsValid)
        {
            _context.Author.Add(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(author);
    }

    [HttpGet]
    public IActionResult CreateAuthor()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateAuthor(Author author)
    {
        if (ModelState.IsValid)
        {
            _context.Author.Add(author);
            _context.SaveChanges();
            return RedirectToAction("Create", "Book", new { authorId = author.AuthorId });
        }
        return View(author);
    }

    private List<Author> GetAuthors()
    {
        return _context.Author.ToList();
    }

    public IActionResult ListBooksForAuthor(int authorId)
    {
        var author = _context.Author.Include(a => a.Books).FirstOrDefault(a => a.AuthorId == authorId);
        if (author == null)
        {
            return RedirectToAction("Index", "Home");
        }
        return View(author.Books);
    }
}
