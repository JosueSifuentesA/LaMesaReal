using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using restaurant.Models;

namespace restaurant.Services
{
    public interface IUsuarioService
    {
        public Usuario ObtenerUsuario(string username, string password);

        public bool VerificarUsuario(string username,string password);

        public Usuario ObtenerUsuarioPorId(int id);

        public Task CrearUsuario(string username,string password,string rol,Persona persona);

        public String BuscarRolUsuario(int id);

    }
}