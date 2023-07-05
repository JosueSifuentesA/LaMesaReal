using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restaurant.Models;

using restaurant.Data;
namespace restaurant.Services
{
    public class UsuarioServiceImplement : IUsuarioService
    {

        private readonly ApplicationDbContext _context;

        public UsuarioServiceImplement(ApplicationDbContext context){
            _context = context;
        }

        public string BuscarRolUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public async Task CrearUsuario(string username, string password, string rol,Persona persona)
        {
            Usuario usuario = new Usuario();

            usuario.rol_usuario = rol;
            usuario.nombre_usuario=username;
            usuario.contraseña_usuario=password;
            usuario.persona=persona;

            _context.DataUsuario.Add(usuario);
            await _context.SaveChangesAsync();
            
        }

        public Usuario ObtenerUsuario(string username, string password)
        {
            Usuario usuario =  _context.DataUsuario.FirstOrDefault(u=>u.nombre_usuario==username&&u.contraseña_usuario==password);
        
            return usuario;
            

        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            Usuario usuario = _context.DataUsuario.Find(id);
            return usuario;
        }

        public bool VerificarUsuario(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}