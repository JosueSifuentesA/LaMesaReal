using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private readonly CategoriaServiceImplement _categoriaService;

        public AdminController(ILogger<AdminController> logger,CategoriaServiceImplement categoriaService,ProductoServiceImplement productoService)
        {
            _logger = logger;
            _productoService = productoService;
            _categoriaService = categoriaService;
        }

        [HttpGet("AdminIndex")]
        public IActionResult Index(int userId,string username,string userRol)
        {
            ViewBag.username = username;
            
            var productos = _productoService.BuscarProductos();
            return View(productos);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarProductoPost(string nombrePlatillo, double precioPlatillo, string descripcionPlatillo, UploadImgModel fileImage, int categoriaId)
        {
            var categorias = _categoriaService.ListarCategorias();

            using (var ms = new MemoryStream())
            {
                if (fileImage != null && fileImage.imgSubida != null)
                {
                    await fileImage.imgSubida.CopyToAsync(ms);
                    var imgSubidaByte = ms.ToArray();
                    Console.WriteLine(nombrePlatillo + " " + precioPlatillo + " " + imgSubidaByte + " " + categoriaId + " " + descripcionPlatillo);

                    await _productoService.CrearProducto(nombrePlatillo,precioPlatillo,descripcionPlatillo,"FakeUrl",categoriaId,imgSubidaByte);
                }
                else
                {
                    Console.WriteLine("No se proporcionó ninguna imagen");
                }
            }

            return View("Index");
        }

        [HttpGet]
        public IActionResult RegistrarProducto(){
            
            var categorias = _categoriaService.ListarCategorias();
            return View("RegistrarProducto",categorias);

        }


        [HttpGet("Error")]


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}