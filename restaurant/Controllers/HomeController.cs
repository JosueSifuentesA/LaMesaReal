using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using restaurant.Models;
using restaurant.Data;
using Microsoft.EntityFrameworkCore;

namespace restaurant.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context,ILogger<HomeController> logger)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var productos = from o in _context.DataProducto.Include(p=>p.categoriaProducto) select o;
        return View(await productos.ToListAsync());
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
