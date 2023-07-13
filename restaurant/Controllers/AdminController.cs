using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

using restaurant.Models;
using restaurant.Services;


namespace restaurant.Controllers
{
    [Authorize(Roles="ADMIN")]
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
            
            var productos = _productoService.BuscarProductos().Result;
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
                    if(ModelState.IsValid){
                        await fileImage.imgSubida.CopyToAsync(ms);
                        var imgSubidaByte = ms.ToArray();
                        await _productoService.CrearProducto(nombrePlatillo,precioPlatillo,descripcionPlatillo,"FakeUrl",categoriaId,imgSubidaByte);
                    }
                }
                else
                {
                    Console.WriteLine("No se proporcionó ninguna imagen");
                }
            }

            return View("Index");
        }

        //[Authorize(Roles="ADMIN")]
        [HttpGet]
        [Route("/RegistrarProducto")]
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