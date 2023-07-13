using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using restaurant.Models;
using restaurant.Data;
using Microsoft.EntityFrameworkCore;
using restaurant.Services;
namespace restaurant.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly ProductoServiceImplement _productoService;

    public HomeController(ApplicationDbContext context,ILogger<HomeController> logger,ProductoServiceImplement productoService)
    {
        _logger = logger;
        _context = context;
        _productoService = productoService;
    }

    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var productos = from o in _context.DataProducto.Include(p=>p.categoriaProducto) select o;
        return View(await productos.ToListAsync());
    }

    [HttpPost]
    public IActionResult Index(string nombrePlatillo , int categoria){
        var productos = BuscarProductos(nombrePlatillo,categoria);
        Console.WriteLine("Nombre del platillo : "+nombrePlatillo);
        return View(productos);
    }

    public List<Producto> BuscarProductos(string nombre , int categoria = 0){
        

        if(nombre == null && categoria != 0){
            return _productoService.BuscarProductos(categoria).Result;
        }else if(nombre != null && categoria == 0){
            return _productoService.BuscarProductos(nombre).Result;
        }else{
            return _productoService.BuscarProductos().Result;
        }

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
