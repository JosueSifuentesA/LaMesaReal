using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using restaurant.Models;
using restaurant.Services;



namespace restaurant.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        private ProductoServiceImplement _productoService;

        public AdminController(ILogger<AdminController> logger,ProductoServiceImplement productoService)
        {
            _logger = logger;
            _productoService = productoService;
        }

        [HttpGet("AdminIndex")]
        public IActionResult Index(int userId,string username,string userRol)
        {
            ViewBag.username = username;
            
            var productos = _productoService.BuscarProductos();
            return View(productos);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}