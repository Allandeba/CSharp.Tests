using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pagination.Models;
using Pagination.Models.DAO;
using X.PagedList;

namespace Pagination.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index(int pagina = 1)
    {
        int numShowingRegisters = 4;

        if (!_context.Usuarios.Any())
        {
            if (!_context.Usuarios.Any())
                for (int i = 0; i < 100; i++)
                    _context.Usuarios.Add(new Usuarios());

            _context.SaveChanges();
        }

        var usuarios = _context.Usuarios
            .OrderBy(p => p.Id)
            .ToPagedList(pagina, numShowingRegisters);

        return View(usuarios);
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
}
