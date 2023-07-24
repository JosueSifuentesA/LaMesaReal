using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using restaurant.Data;
using restaurant.Models;
using restaurant.Services;

namespace restaurant.Controllers
{
    [Route("[controller]")]
    public class AutentificacionController : Controller
    {
        private readonly ILogger<AutentificacionController> _logger;
        private readonly ApplicationDbContext _context;

        public UsuarioServiceImplement _usuarioService;
        public PersonaServiceImplement _personaService;

        public AutentificacionController(ApplicationDbContext context,ILogger<AutentificacionController> logger,UsuarioServiceImplement usuarioService,PersonaServiceImplement personaService)
        {
            _logger = logger;
            _context = context;
            _usuarioService = usuarioService;
            _personaService = personaService;
        }

        [HttpGet("IniciarSesion")]
        public IActionResult IniciarSesion()
        {
            return View("IniciarSesion");
        }

        [HttpGet("Registrarse")]
        public IActionResult Registrarse()
        {
            return View("Registrarse");
        }

        
        [HttpPost]
        public async Task<IActionResult> login(string username, string password)
        {   
            var user = _usuarioService.ObtenerUsuario(username,password);
            
            if(user != null){
                Console.WriteLine("Se encontro un usuario");

                //

                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role,  user.rol_usuario),
                    new Claim("idUser",user.id_usuario.ToString())
                    
                };
                //
                var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity));
                Console.WriteLine(claims[1].ToString());

                String rolUser = User.FindFirstValue(ClaimTypes.Role);

                Console.WriteLine(rolUser);
                switch(user.rol_usuario){
                    case "ADMIN": 
                        return RedirectToAction("Index","Admin",new {userId=user.id_usuario,username=username,userRol=user.rol_usuario});                  
                    case "USUARIO":
                        return RedirectToAction("IndexUsuario","Usuario");                   
                    case "REPARTIDOR":
                        return RedirectToAction("Index","Repartidor");
                    default:
                        return RedirectToAction("Error","Home");                        
                }
            }
            
            

            return View("IniciarSesion");
        }

        [Route("/Logout")]
        public async Task<IActionResult> logout(){
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }


        [HttpPost("register")]
        public async Task<IActionResult> register(string username, string password,string confirmPassword,string Nombre,string apPaterno,string apMaterno,string telefono,char sexo)
        {   

            using(var transaction = _context.Database.BeginTransaction()){

                try{
                    Console.WriteLine("AQUI LAS CREDENCIALES " + username + " " + password+ " " +confirmPassword+ " " +Nombre+ " " +apPaterno+ " " +apMaterno+ " " +telefono+ " " +sexo);
                    
                    if(password==confirmPassword){
                        var persona = new Persona {nombre_persona= Nombre,apellidoPaterno_persona=apPaterno,apellidoMaterno_persona=apMaterno,telefono_persona=telefono,sexo_persona=sexo};
                        await _usuarioService.CrearUsuario(username,password,"USUARIO",persona);
                    }
                    
                    transaction.Commit();

                    return View("IniciarSesion");

                }catch(Exception ex){

                    Console.WriteLine(ex);
                    transaction.Rollback();

                    return RedirectToAction("Error","Home");
                }
            }

        }

        [Route("/Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}