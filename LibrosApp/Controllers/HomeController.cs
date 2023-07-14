using LibrosApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LibrosApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LibrosContext _context; // Agrega el contexto de base de datos

        public HomeController(ILogger<HomeController> logger, LibrosContext context)
        {
            _logger = logger;
            _context = context; // Asigna el contexto de base de datos a la variable local
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Authors()
        {
            var authors = _context.Author.ToList(); // Recupera la lista de autores de la base de datos
            return View(authors); // Pasa la lista de autores a la vista
        }
    }
}
 