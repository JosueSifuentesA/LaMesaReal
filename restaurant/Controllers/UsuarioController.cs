using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

using restaurant.Services;
using restaurant.Models;
namespace restaurant.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles ="USUARIO")]
    public class UsuarioController : Controller
    {
        
        private readonly ProductoServiceImplement _productoService;
        private readonly UsuarioServiceImplement _usuarioService;
        public UsuarioController(UsuarioServiceImplement usuarioService,ProductoServiceImplement productoService)
        { 
            _productoService = productoService;
            _usuarioService = usuarioService ;
        }

        [HttpGet("IndexUsuario")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var productos = await _productoService.BuscarProductos();
            return View("IndexUsuario",productos);
        }

        [HttpPost("IndexUsuario")]
        public IActionResult Index(string nombrePlatillo , int categoria){
            var productos = BuscarProductos(nombrePlatillo,categoria);
            Console.WriteLine("Nombre del platillo : "+nombrePlatillo);
            return View("IndexUsuario",productos);
        }

        [HttpGet]
        [Route("/Usuario/VerPerfil/{idUser}")]
        public IActionResult VerPerfil(string idUser){
            int idUsuario = int.Parse(idUser);
            var usuario = _usuarioService.ObtenerUsuarioPorId(idUsuario);

            return View("VerPerfil",usuario);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            {
                return View("Error!");
            }
        }
}